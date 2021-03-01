using EyeGaze.Engine;
using EyeGaze.Logger;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;

namespace EyeGaze.SpeechToText
{
    class SpeechToText
    {
        private InterfaceSpeechToText speechToText;
        public event TriggerWordHandler triggerHandler;
        public event TriggerHandlerMessage sendMessageToEngine;
        private bool terminate;
        private string className;
        private bool stopToSwitchCloud = false;
        string[] actions;
        private bool isReplaceAll = false;
        private string lastTriggerWord;

        public SpeechToText(string className)
        {
            this.className = className;
            Type speechToTextType = Type.GetType(className);
            speechToText = (InterfaceSpeechToText)Activator.CreateInstance(speechToTextType);
            actions = new string[] { "fix", "change", "add", "move", "replace", "done", "more", "delete", "delete from", "to","too","two","do", "1", "2", "3", "4", "5" };


            this.terminate = false;
        }
        public void FindActionFromSpeech(string key, string keyInfo)
        {
            try
            {
                speechToText.connect(key, keyInfo);
                while (!this.terminate && !stopToSwitchCloud)
                {
                    string result = speechToText.listen();
                    Debug.WriteLine("Enter while loop " + DateTime.Now.ToString("h:mm:ss tt") + "word " + result);
                    if (result != "")
                    {
                        result = result.Trim().ToLower();
                        Console.WriteLine(result);
                        string[] text = result.Split(' ');
                        TriggerWordEvent message = parseResult(text);
                        if (triggerHandler != null && message != null)
                        {
                            triggerHandler(this, message);
                        }
                    }
                }
            }
            catch (ConnectionFailedException e)
            {
                MessageEvent message = new MessageEvent();
                message.message = e.Message + " switch to system lib";
                message.type = MessageEvent.messageType.ConnectionFail;
                sendMessageToEngine(this, message);
                switchToSystemLib();
                Thread thread = new Thread(() => {
                    changeBackToCloud(key, keyInfo);
                });
                thread.Start();
                FindActionFromSpeech(key, keyInfo);
                if (stopToSwitchCloud && !this.terminate)
                {
                    this.stopToSwitchCloud = false;
                    this.speechToText.disconnect();
                    Type speechToTextType = Type.GetType(this.className);
                    this.speechToText = (InterfaceSpeechToText)Activator.CreateInstance(speechToTextType);
                    MessageEvent message2 = new MessageEvent();
                    message2.message = "Internet connection is back, switch to cloud speech to text";
                    message2.type = MessageEvent.messageType.ConnectionFail;
                    sendMessageToEngine(this, message2);
                    FindActionFromSpeech(key, keyInfo);
                }

                return;
            }
            catch (WrongAuthenticationException e)
            {
                MessageEvent message = new MessageEvent();
                message.message = e.Message;
                message.type = MessageEvent.messageType.WrongAuthentication;
                sendMessageToEngine(this, message);
                return;
            }
        }

        public TriggerWordEvent parseResult(string[] text)
        {
            try
            {
                if (text.Length > 0 && actions.Contains(text[0]))
                {
                    string triggerWord = text[0];
                    if (triggerWord == "add" && text.Length < 3)            // Add with less then two words after
                        return null;
                    if (triggerWord == "replace" && text.Length < 3)            // Replace with less then two words after
                        return null;
                    if (triggerWord == "replace" && text[1] == "all" && text.Length != 4)            // Replace with less then two words after
                        return null;
                    bool prevReplaceAll = isReplaceAll;
                    if (triggerWord == "done")
                    {
                        isReplaceAll = false;
                    }
                    if (triggerWord == "fix" && text.Length > 1)
                        triggerWord = "fix word";
                    if(triggerWord=="delete" && (text[1] == "form" || text[1] == "from"))
                    {
                        triggerWord = "delete from";
                    }

                    //in case of "delete from word1 to word2"
                    string[] toOptionsArray ={ "to", "2", "two", "do", "too" };
                    if(toOptionsArray.Contains(triggerWord) && lastTriggerWord == "delete from")
                        triggerWord = "to (delete)";

                    lastTriggerWord = triggerWord;

                    TriggerWordEvent message = new TriggerWordEvent();
                    message.triggerWord = triggerWord;
                    string[] content = new string[text.Length - 1];
                    Array.Copy(text, 1, content, 0, text.Length - 1);
                    if (triggerWord == "delete from")
                    {
                        string[] tmpContent = new string[content.Length - 1];
                        Array.Copy(content, 1, tmpContent, 0, content.Length - 1);
                        content = tmpContent;
                    }
                    message.content = content;
                    if (!(triggerWord == "done" && !prevReplaceAll))
                        sendMessage(triggerWord, content);
                    return message;
                }
                return null;
            }
            catch(Exception e)
            {
                SystemLogger.getErrorLog().Error("Error in parse result" + e.Message);
                return null;
            }
            
        }

        private void sendMessage(String triggerWord, String[] content)
        {
            try
            {
                string sentence = String.Join(" ", content);
                if (triggerWord.Equals("fix word"))
                    triggerWord = "fix";
                MessageEvent message = new MessageEvent();
                message.message = triggerWord + " " + sentence;
                if (triggerWord == "move" || triggerWord == "change")
                    message.message = triggerWord;
                if (triggerWord == "fix" && content.Length > 1)
                    message.message = "fix " + content[0];
                if (triggerWord == "replace" && (content[0] == "all" || content[0] == "all,") && content.Length > 3)
                    message.message = "replace all " + content[1] + " " + content[2];
                else if (triggerWord == "replace" && content[0] != "all" && content.Length > 2)
                    message.message = "replace " + content[0] + " " + content[1];
                if (isReplaceAll)
                {
                    message.message = "Waiting for done trigger word";
                }
                message.type = MessageEvent.messageType.TriggerWord;
                sendMessageToEngine(this, message);
                if (triggerWord == "replace" && (content[0] == "all" || content[0] == "all,"))
                    isReplaceAll = true;
            }
            catch(Exception e)
            {
                SystemLogger.getErrorLog().Error("Exception in send message " + e.Message);
            }
        }

        public virtual void switchToSystemLib()
        {
            this.speechToText.disconnect();
            SystemLogger.getEventLog().Info("connect to system lib speech to text");
            Type speechToTextType = Type.GetType("EyeGaze.SpeechToText.SystemLibSpeechToText");
            speechToText = (InterfaceSpeechToText)Activator.CreateInstance(speechToTextType);
        }

        private bool checkConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void changeBackToCloud(string key, string keyInfo)
        {
            while (!checkConnection())
            {
                Thread.Sleep(5000);
            }
            if (!this.terminate)
                stopToSwitchCloud = true;
        }


        public void disconnect()
        {
            speechToText.disconnect();
        }

        public void finishListen()
        {
            this.terminate = true;
        }

    }


}

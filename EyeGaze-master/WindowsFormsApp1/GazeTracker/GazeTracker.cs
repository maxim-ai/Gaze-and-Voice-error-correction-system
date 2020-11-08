using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;



namespace EyeGaze.GazeTracker
{
    class GazeTracker : InterfaceGazeToCoords
    {
        bool exit_state = false;
        int startindex, endindex;
        TcpClient gp3_client;
        NetworkStream data_feed;
        StreamWriter data_write;
        String incoming_data = "";
        public void connect(string key, string keyInfo)
        {

            const int ServerPort = 4242;
            const string ServerAddr = "127.0.0.1";
            ConsoleKeyInfo keybinput;

            // Try to create client object, return if no server found
            try
            {
                gp3_client = new TcpClient(ServerAddr, ServerPort);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to connect with error: {0}", e);
                return;
            }

        }

        public void disconnect()
        {
            throw new NotImplementedException();
        }

        public string listen()
        {
            try
            {
                Task<string> text = Task.Run(async () => await ConvertGazeAsync());
                text.Wait();
                // Task<string> text = RecognizeSpeechAsync();
                string result = text.Result;
                if (result != "")
                    result = result.Substring(0, result.Length - 1);    //remove the dot at the end of a sentence
                //SystemLogger.getEventLog().Info("Microsoft cloud found : " + result);
                return result;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        public async Task<string> ConvertGazeAsync() 
        {

            return "";
        }
    }
}

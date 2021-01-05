using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
//using System.Windows.Forms;
using System.Windows.Forms;

//namespace System.Windows.Forms
//{
//    public class ScreenSize
//    {
//        public static float size()
//        {
//            /*System.Windows.Forms.Screen.Bounds();*/
//        }
//    }
//}


namespace EyeAPI
{
    class Program : EyeGazeInterface
    {
        const int ServerPort = 4242;
        const string ServerAddr = "127.0.0.1";


        static void Main(string[] args)
        {

            debugger l = new debugger();
            l.Show();
            l.Refresh();

            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(1000);
                l.MoveCircle(l.x + 50, l.y + 50);

            }

            Thread.Sleep(3000);
            l.MoveCircle(500, 500);
            Thread.Sleep(5000);


            bool exit_state = false;
            int startindex, endindex;
            TcpClient gp3_client;
            NetworkStream data_feed;
            StreamWriter data_write;
            String incoming_data = "";

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

            // Load the read and write streams
            data_feed = gp3_client.GetStream();
            data_write = new StreamWriter(data_feed);

            // Setup the data records
            data_write.Write("<SET ID=\"ENABLE_SEND_POG_FIX\" STATE=\"1\" />\r\n");
            data_write.Write("<SET ID=\"ENABLE_SEND_DATA\" STATE=\"1\" />\r\n");

            // Flush the buffer out the socket
            data_write.Flush();

            do
            {

                int ch = data_feed.ReadByte();
                if (ch != -1)
                {
                    incoming_data += (char)ch;

                    // find string terminator ("\r\n") 
                    if (incoming_data.IndexOf("\r\n") != -1)
                    {
                        // only process DATA RECORDS, ie <REC .... />
                        if (incoming_data.IndexOf("<REC") != -1)
                        {
                            double time_val;
                            double fpogx;
                            double fpogy;
                            int fpog_valid;

                            // Process incoming_data string to extract FPOGX, FPOGY, etc...

                            startindex = incoming_data.IndexOf("FPOGX=\"") + "FPOGX=\"".Length;
                            endindex = incoming_data.IndexOf("\"", startindex);
                            fpogx = Double.Parse(incoming_data.Substring(startindex, endindex - startindex));

                            startindex = incoming_data.IndexOf("FPOGY=\"") + "FPOGY=\"".Length;
                            endindex = incoming_data.IndexOf("\"", startindex);
                            fpogy = Double.Parse(incoming_data.Substring(startindex, endindex - startindex));

                            //startindex = incoming_data.IndexOf("FPOGV=\"") + "FPOGV=\"".Length;
                            //endindex = incoming_data.IndexOf("\"", startindex);
                            //fpog_valid = Int32.Parse(incoming_data.Substring(startindex, endindex - startindex));
                            ////Thread.Sleep(2000);
                            Console.WriteLine("Raw data: {0}", incoming_data);
                            Console.WriteLine("Processed data: Gaze ({0},{1})", fpogx, fpogy);
                        }

                        incoming_data = "";
                    }
                }

                if (Console.KeyAvailable == true)
                {
                    keybinput = Console.ReadKey(true);
                    if (keybinput.Key != ConsoleKey.Q)
                    {
                        exit_state = true;
                    }
                }
            }
            while (exit_state == false);

            data_write.Close();
            data_feed.Close();
            gp3_client.Close();
        }

        public override Point GetEyeGazePosition()
        {
            throw new NotImplementedException();
        }
    }
}

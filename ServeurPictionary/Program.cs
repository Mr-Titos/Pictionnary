using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServeurPictionary
{
    class Program
    {
        const string SERVER_IP = "127.0.0.1";
        byte[] bytes = new byte[1024];
        static List<Socket> readList = new List<Socket>();
        static Socket ServerSocket = new Socket(AddressFamily.InterNetwork,
                      SocketType.Stream,
                      ProtocolType.Tcp);

        static int port = 0;
        static IPAddress localAdd = IPAddress.Parse(SERVER_IP);

        static List<Byte[]> cpseudo = new List<byte[]>();
        static String limg ="n";

        static Socket clitest;



        static void Main(string[] args)
        {
            Console.Write("Port : ");
            port = Convert.ToInt32(Console.ReadLine());

            Thread start;
            start = new Thread(Start);
            start.Start();

            Thread list;
            list = new Thread(Listen);
            list.Start();

            Thread allo;
            allo = new Thread(Pseudo_Send);
            allo.Start();

            Thread timg;
            timg = new Thread(Img_Send);
            timg.Start();
        }

        public static void Img_Send()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                if (limg.Length > 1)
                {
                    List<Socket> temp = readList;
                    String temp2 = limg;
                    byte[] salt = Encoding.UTF8.GetBytes(temp2);
                    foreach (Socket so in temp)
                    {
                        if(so != clitest)
                            so.Send(salt, salt.Length, SocketFlags.None);
                    }
                    limg = "";

                    /*foreach (Byte[] byt in temp2)
                    {
                        if (byt != null)
                        {
                            foreach (Socket so in temp)
                            {
                                //if(so != clitest.Get_Client())
                                so.Send(byt, byt.Length, SocketFlags.None);
                                Console.WriteLine("Test");
                                Thread.Sleep(20);
                            }
                        }
                    }*/
                }
            }
        }

        public static void Pseudo_Send()
        {
            /*while (Thread.CurrentThread.IsAlive)
            {
                List<Socket> temp = readList;
                Thread.Sleep(2000);
                foreach (Byte[] byt in cpseudo)
                {
                    foreach (Socket so in temp)
                        so.Send(byt, byt.Length, SocketFlags.None);
                }
            }*/
        }

        public static void Listen()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                List<Socket> temp = readList;
                Thread.Sleep(10);
                foreach (Socket client in temp)
                {
                    try
                    {
                        if (!client.Connected)
                            continue;

                        string txt = "";
                        while (client.Available > 0)
                        {
                            byte[] bytes = new byte[client.ReceiveBufferSize];
                            int byteRec = client.Receive(bytes);
                            if (byteRec > 0)
                                txt += Encoding.UTF8.GetString(bytes, 0, byteRec);

                            if (!string.IsNullOrEmpty(txt))
                            {
                                String choix = txt.Substring(0, 6);
                                if (choix == "00000,")
                                {

                                    txt = txt.Substring(6);
                                    Console.WriteLine(client.RemoteEndPoint + " : " + txt);
                                    byte[] salt = Encoding.UTF8.GetBytes("11111," + txt);
                                    foreach (Socket so in readList)
                                        so.Send(salt, salt.Length, SocketFlags.None);
                                }
                                else if(choix == "0SPSP,")
                                {
                                    Console.WriteLine(txt);
                                    txt = txt.Substring(6);
                                    byte[] salt = Encoding.UTF8.GetBytes("1SPSP," + txt);
                                    cpseudo.Add(salt);
                                }
                                else if(choix == "0IMGW,")
                                {
                                    txt = txt.Substring(6);
                                    limg = "1IMGW," + txt;
                                    clitest = client;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }


        public static void Start()
        {
            IPHostEntry ipHostEntry = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostEntry.AddressList[0];
            Console.WriteLine("Server IP = " + ipAddress.ToString());
            Socket CurrentClient = null;

            try
            {
                ServerSocket.Bind(new IPEndPoint(localAdd, port));
                //Le 10 veut dire 10 clients max
                ServerSocket.Listen(10);

                while (true)
                {
                    CurrentClient = ServerSocket.Accept();
                    Console.WriteLine("New client:" + CurrentClient.RemoteEndPoint);
                    readList.Add(CurrentClient);
                }
            }
            catch (SocketException E)
            {
                Console.WriteLine(E.Message);
            }
        }
    }
}

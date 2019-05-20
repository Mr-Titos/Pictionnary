using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace Pictionnary
{
    public partial class Pictionnary : Form
    {

        Conx form2 = new Conx();

        Pen pen = new Pen(Color.Black, 4);

        Point mouseDownLocation = new Point();
        Point p1 = new Point();
        static Point p2 = new Point();


        static bool reset = true;

        static List<Point> lpoints = new List<Point>();
        static List<Point> sendlpoints = new List<Point>();

        IPAddress ipAd = IPAddress.Parse("127.0.0.1");

        static Socket ClientSocket = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Timer Timer2;
        private System.Windows.Forms.Timer Timer3;


        static int port;
        static string ipa;
        static string pseudo;

        private int compteurpseudo = 1;

        List<string> msgchat = new List<string>();
        List<string> msgpseudo = new List<string>();
        string pospoint = "";
        Point Oldpoint;

        static int x1 = 0;
        static int y1 = 0;
        static int x2 = 0;
        static int y2 = 0;

        static bool imgtest2 = false;
        static bool imgtest = false;

        static Bitmap imagep;

        public Pictionnary()
        {
            InitializeComponent();
            port = form2.Get_Port();
            ipa = form2.Get_IpAdress();
            pseudo = form2.Get_Pseudo();

            try
            {
                IPAddress ipa2 = IPAddress.Parse(ipa);
                ClientSocket.Connect(ipa2, port);
                byte[] bytesToSend = Encoding.ASCII.GetBytes("0SPSP," + pseudo);
                ClientSocket.Send(bytesToSend, bytesToSend.Length, SocketFlags.None);
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur a eu lieu lors de la connexion au serveur \r\n" +
                                    "Veuillez redemarrez l'application", "Erreur");
                Environment.Exit(1);
            }

            Thread Listen;
            Listen = new Thread(Receive);
            Listen.Start();

            Timer = new System.Windows.Forms.Timer();
            Timer.Interval = 200;
            Timer.Tick += new EventHandler(Chat_Update);
            Timer.Start();

            /*Timer2 = new System.Windows.Forms.Timer();
            Timer2.Interval = 3000;
            Timer2.Tick += new EventHandler(Pseudo_Update);
            Timer2.Start();*/

            Timer3 = new System.Windows.Forms.Timer();
            Timer3.Interval = 100;
            Timer3.Tick += new EventHandler(Img_Update);
            Timer3.Start();
        }


        private void Receive()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                try
                {
                    if (!ClientSocket.Connected)
                        continue;

                    byte[] bytesToRead = new byte[ClientSocket.ReceiveBufferSize];

                    byte[] msg = new Byte[ClientSocket.Available];
                    ClientSocket.Receive(msg, 0, ClientSocket.Available, SocketFlags.None);

                    String messageReceived = Encoding.UTF8.GetString(msg);
                    if (messageReceived.Length > 0)
                    {
                        if (messageReceived.Substring(0, 6) == "11111,")
                        {
                            msgchat.Add(pseudo + " : " + messageReceived.Substring(6));
                        }

                        else if (messageReceived.Substring(0, 6) == "1SPSP,")
                        {
                            msgpseudo.Add(messageReceived.Substring(6));
                        }
                        else if (messageReceived.Substring(0, 6) == "1IMGW,")
                        {
                            pospoint = messageReceived.Substring(6);
                        }
                    }
                }
                catch (SocketException) { Environment.Exit(1); }
                catch (Exception)  {  }
            }
        }

        private void Img_Update(Object ob, EventArgs e)
        {
            if (pospoint != "")
            {
                String[] temp = pospoint.Split(',');


                if (reset == true)
                {
                    try { Oldpoint = new Point(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1])); } catch (FormatException) { }
                    reset = false;
                }
                else
                {
                    try
                    {
                        Point temp2 = new Point(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]));
                        Graphics g = pictureBox13.CreateGraphics();
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.DrawLine(pen, Oldpoint.X, Oldpoint.Y, temp2.X, temp2.Y);
                        g.Dispose();
                       //if(  )
                            Oldpoint = temp2;
                        /*else
                        {
                            reset = true;  
                        }*/
                    }
                    catch (FormatException) { }
                }
                if (temp[0] == "reset" && temp[1] == "true")
                    reset = true;
            }


        }

        private static void Img_Send(Point p)
        {
            /*while (Thread.CurrentThread.IsAlive)
            {
                try
                {
                    Thread.Sleep(1000);
                    if (sendlpoints.Count() > 0)
                    {
                        //byte[] bytesToSend = Encoding.ASCII.GetBytes("0IMGW," + "/" + Convert.ToString(x1) + "/" + Convert.ToString(y1)
                         //   + "/" + Convert.ToString(x2) + "/" + Convert.ToString(y2));
                        String txt = "0IMGW,";
                        foreach (Point p in sendlpoints)
                            txt += Convert.ToString(p.X) + '/' + Convert.ToString(p.Y) + '/';
                        byte[] bytesToSend = Encoding.ASCII.GetBytes(txt);
                        ClientSocket.Send(bytesToSend, bytesToSend.Length, SocketFlags.None);
                        sendlpoints.Clear();
                    }

                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
            }*/
            String temp = p.X + "," + p.Y;
            byte[] bytesToSend = Encoding.ASCII.GetBytes("0IMGW," + temp);
            ClientSocket.Send(bytesToSend, bytesToSend.Length, SocketFlags.None);
            p2 = new Point(p.X, p.Y);
        }

        private void Chat_Update(Object ob, EventArgs e)
        {
            try
            {
                if (msgchat.Count > 0)
                {
                    List<string> temp = msgchat;
                    foreach (String m in temp)
                        chat.AppendText("\r\n" + m);

                    temp.Clear();
                    msgchat.Clear();
                }
            }
            catch (Exception) { }
        }

        private void Pseudo_Update(Object obj, EventArgs e)
        {
            List<string> temp = msgpseudo;
            foreach (String m in temp)
            {
                if (labuser1.Text == "user1" && m != labuser2.Text && m != labuser3.Text && compteurpseudo == 1)
                {
                    compteurpseudo = 2;
                    labuser1.Text = m;
                }
                else if (labuser2.Text == "user2" && m != labuser1.Text && m != labuser3.Text && compteurpseudo == 2)
                {
                    compteurpseudo = 3;
                    labuser2.Text = m;
                }
                else if (labuser3.Text == "user3" && m != labuser2.Text && m != labuser1.Text && compteurpseudo == 3)
                {
                    compteurpseudo = 9999;
                    labuser3.Text = m;
                }
            }
            temp.Clear();
            msgpseudo.Clear();
        }


        private void pictureBox13_MouseUp(object sender, MouseEventArgs e)
        {
            lpoints.Clear();
            byte[] bytesToSend = Encoding.ASCII.GetBytes("0IMGW,reset,true");
            ClientSocket.Send(bytesToSend, bytesToSend.Length, SocketFlags.None);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox13.Image = null;
        }


        private void LastPos(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point temp = new Point(e.X, e.Y);
                p1 = temp;
                Img_Send(p1);
            }
        }

        private void Refreshpos(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                Graphics g = pictureBox13.CreateGraphics();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                foreach (Point p in lpoints)
                {
                    g.DrawLine(pen, p1.X, p1.Y, p.X, p.Y);
                }
                g.Dispose();
                lpoints.Clear();
                Point ptemp = new Point(e.X, e.Y);
                lpoints.Add(ptemp);
            }
        }

        private void pictureBox13_MouseMove(object sender, MouseEventArgs e)
        {
            LastPos(e);
            Thread.Sleep(50);
            Refreshpos(e);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Black;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Red;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Gray;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Blue;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Green;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Orange;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Maroon;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Pink;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Purple;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Yellow;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pen.Width = 4;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pen.Width = 8;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "Enter your text here";
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == motdessin.Text)
                {
                    chat.Text = " a trouvé le mot qui était  " + motdessin.Text + "! \r\n";

                }
                else if (textBox1.Text != null && textBox1.Text != "Enter your text here")
                {
                    try
                    {
                        byte[] bytesToSend = Encoding.ASCII.GetBytes("00000," + textBox1.Text);
                        ClientSocket.Send(bytesToSend, bytesToSend.Length, SocketFlags.None);
                    }

                    catch (Exception exc)
                    {
                        Console.WriteLine("Error..... " + exc.StackTrace);
                    }
                }
                Thread.Sleep(15);
                textBox1.Clear();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictionnary
{
    public partial class Conx : Form
    {

        private static string ip;
        private static int port;
        private static string pseudo;

        public Conx()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Moche();
        }

        private void pseudobox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Moche();
        }

        private void Moche()
        {
            if (pseudobox.Text != "")
            {
                //try
                //{
                    if (ipbox.Text != "" && portbox.Text != "")
                    {
                        ip = ipbox.Text;
                    try { port = Convert.ToInt32(portbox.Text); } catch (FormatException) { labelerror.Visible = true; ipbox.Focus(); } 
                        pseudo = pseudobox.Text;

                        Pictionnary p = new Pictionnary();
                        Hide();
                        p.ShowDialog();
                        Close();
                    }
                //}

                //catch(Exception e) { labelerror.Visible = true; ipbox.Focus(); ipbox.Text = e.ToString(); };



            }
            if (pseudobox.Text == "")
            {
                label2.Visible = true;
                ipbox.Focus();
            }
        }

        public int Get_Port()
        {
            return port;
        }

        public string Get_IpAdress()
        {
            return ip;
        }

        public string Get_Pseudo()
        {
            return pseudo;
        }

        private void ipbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Moche();
        }

        private void portbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Moche();
        }


    }
}

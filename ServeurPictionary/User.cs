using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServeurPictionary
{
    class User
    {
        private String pseudo;
        private Socket client;

        public User(String p, Socket cli)
        {
            pseudo = p;
            client = cli;
        }

        public Socket Get_Client()
        {
            return client;
        }

        public String Get_Pseudo()
        {
            return pseudo;
        }

        public void Set_Pseudo(String p)
        {
            pseudo = p;
        }
    }
}

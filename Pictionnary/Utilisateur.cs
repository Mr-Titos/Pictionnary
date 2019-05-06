using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictionnary
{
    class Utilisateur
    {
        private String pseudonyme;
        private int Idtemp = 0;
        private static int Id = 0;


        public int GetId()
        {
            return this.Idtemp;
        }

        public string GetPseudo()
        {
            return this.pseudonyme;
        }

        public void SetPseudo(String Ps)
        {
            this.pseudonyme = Ps;
        }

        public Utilisateur(String Ps)
        {
            this.pseudonyme = Ps;
            Utilisateur.Id++;
            this.Idtemp = Utilisateur.Id;
        }
    }
}

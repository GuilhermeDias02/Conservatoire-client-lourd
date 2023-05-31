using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.modele
{
    public class Login
    {
        private string id;
        private string indentifiant;
        private string mdp;

        public string Id { get => id; set => id = value; }
        public string Indentifiant { get => indentifiant; set => indentifiant = value; }
        public string Mdp { get => mdp; set => mdp = value; }
    }
}

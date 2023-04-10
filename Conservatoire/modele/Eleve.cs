using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.modele
{
    internal class Eleve : Personnes
    {
        private int niveau;
        private bool bourse;

        public Eleve(int unId, string unNom, string unPrenom, string unTel, string unMail, string uneAdresse, int unNiveau, bool uneBourse) : base(unId, unNom, unPrenom, unTel, unMail, uneAdresse)
        {
            this.niveau = unNiveau;
            this.bourse = uneBourse;
        }

        public override string Description
        {
            get => (base.Description + " Niveau: " + this.niveau + " Bourse: " + this.bourse);
        }
    }
}

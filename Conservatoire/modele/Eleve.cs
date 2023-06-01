using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.modele
{
    public class Eleve : Personnes
    {
        private int niveau;
        private int bourse;

        /// <summary>
        /// Crée un élève
        /// </summary>
        /// <param name="unId"></param>
        /// <param name="unNom"></param>
        /// <param name="unPrenom"></param>
        /// <param name="unTel"></param>
        /// <param name="unMail"></param>
        /// <param name="uneAdresse"></param>
        /// <param name="unNiveau"></param>
        /// <param name="uneBourse"></param>
        public Eleve(int unId, string unNom, string unPrenom, string unTel, string unMail, string uneAdresse, int unNiveau, int uneBourse) : base(unId, unNom, unPrenom, unTel, unMail, uneAdresse)
        {
            this.niveau = unNiveau;
            this.bourse = uneBourse;
        }

        /// <summary>
        /// Défini comment va être affiché l'élève dans une list box
        /// </summary>
        public override string Description
        {
            get => (base.Description + " Niveau: " + this.niveau + " Bourse: " + this.bourse);
        }
    }
}

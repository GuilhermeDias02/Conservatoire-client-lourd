using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.modele
{
    public class Personnes
    {

        private int id;
        private string nom;
        private string prenom;
        private string tel;
        private string adresse;
        private string mail;

        // remplace getId()
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; }
        public string Prenom { get => prenom; }
        public string Tel { get => tel; }
        public string Adresse { get => adresse; }
        public string Mail { get => mail; }

        /// <summary>
        /// Crée un personne
        /// </summary>
        /// <param name="unId"></param>
        /// <param name="unNom"></param>
        /// <param name="unPrenom"></param>
        /// <param name="unTel"></param>
        /// <param name="unMail"></param>
        /// <param name="uneAdresse"></param>
        public Personnes(int unId, string unNom, string unPrenom, string unTel,string unMail, string uneAdresse)
        {
            this.id = unId;
            this.nom = unNom;
            this.prenom = unPrenom;
            this.tel = unTel;
            this.mail = unMail;
            this.adresse = uneAdresse;
        }

        /// <summary>
        /// Défini comment va être affiché la personne dans une list box
        /// </summary>
        public virtual string Description
        {
            get => ("Id : " + this.id + " Nom : " + this.nom + " Prenom : " + this.prenom + " Télephone : " + this.tel + " Mail: " + this.mail + " Adresse: " + this.adresse);
        }
    }
}

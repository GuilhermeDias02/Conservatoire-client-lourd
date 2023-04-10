using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.modele
{
    class Personnes
    {

        private int id;
        private string nom;
        private string prenom;
        private string tel;
        private string adresse;
        private string mail;

        // remplace getId()
        public int Id { get => id; set => id = value; }


        public Personnes(int unId, string unNom, string unPrenom, string unTel,string unMail, string uneAdresse)
        {
            this.id = unId;
            this.nom = unNom;
            this.prenom = unPrenom;
            this.tel = unTel;
            this.mail = unMail;
            this.adresse = uneAdresse;
        }

        // pour afficher la liste par la suite
        public virtual string Description
        {
            get => ("Id : " + this.id + " Nom : " + this.nom + " Prenom : " + this.prenom + " Télephone : " + this.tel + " Mail: " + this.mail + " Adresse: " + this.adresse);
        }

        public string Nom { get => nom; }
    }
}

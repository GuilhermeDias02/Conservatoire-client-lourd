using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.modele
{
    public class Inscription
    {
        private readonly int idProf;
        private readonly string nomProf;
        private readonly string prenomProf;

        private int idEleve;
        private readonly string nomEleve;
        private readonly string prenomEleve;

        private int numSeance;
        private readonly string tranche;
        private readonly string jour;

        private readonly DateTime dateInscription;

        /*public Inscription(int unIdProf, int unIdEleve, int unNumSeance, DateTime uneDateInscription)
        {
            this.idProf = unIdProf;
            this.idEleve = unIdEleve;
            this.numSeance = unNumSeance;
            this.dateInscription = uneDateInscription;
        }*/

        /// <summary>
        /// Crée une inscription
        /// </summary>
        /// <param name="unIdProf"></param>
        /// <param name="unNomProf"></param>
        /// <param name="unPrenomProf"></param>
        /// <param name="unIdEleve"></param>
        /// <param name="unNomEleve"></param>
        /// <param name="unPrenomEleve"></param>
        /// <param name="unNumSeance"></param>
        /// <param name="uneTranche"></param>
        /// <param name="unJour"></param>
        /// <param name="uneDateInscription"></param>        
        public Inscription(int unIdProf, string unNomProf, string unPrenomProf, int unIdEleve, string unNomEleve, string unPrenomEleve, int unNumSeance, string uneTranche, string unJour, DateTime uneDateInscription)
        {
            this.idProf = unIdProf;
            this.nomProf = unNomProf;
            this.prenomProf = unPrenomProf;

            this.IdEleve = unIdEleve;
            this.nomEleve = unNomEleve;
            this.prenomEleve = unPrenomEleve;

            this.NumSeance = unNumSeance;
            this.tranche = uneTranche;
            this.jour = unJour;
            this.dateInscription = uneDateInscription;
        }

        /// <summary>
        /// Défini comment va être affiché l'inscription dans une list box
        /// </summary>
        public string Description
        {
            get => ("Prof: "+ this.nomProf +" "+ this.prenomProf +" Elève: "+ this.nomEleve +" "+ this.prenomEleve +" Heure: "+ this.tranche +" Jour: "+ this.jour +" Date d\'inscription: "+ this.dateInscription);
        }

        public int IdEleve { get => idEleve; set => idEleve = value; }
        public int NumSeance { get => numSeance; set => numSeance = value; }
    }
}

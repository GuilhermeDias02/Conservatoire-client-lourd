﻿using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.modele
{
    public class Inscription
    {
        private int idProf;
        private string nomProf;
        private string prenomProf;

        private int idEleve;
        private string nomEleve;
        private string prenomEleve;

        private int numSeance;
        private string tranche;
        private string jour;

        private DateTime dateInscription;

        /*public Inscription(int unIdProf, int unIdEleve, int unNumSeance, DateTime uneDateInscription)
        {
            this.idProf = unIdProf;
            this.idEleve = unIdEleve;
            this.numSeance = unNumSeance;
            this.dateInscription = uneDateInscription;
        }*/

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

        public string Description
        {
            get => ("Prof: "+ this.nomProf +" "+ this.prenomProf +" Elève: "+ this.nomEleve +" "+ this.prenomEleve +" Heure: "+ this.tranche +" Jour: "+ this.jour +" Date d\'inscription: "+ this.dateInscription);
        }
        public int IdEleve { get => idEleve; set => idEleve = value; }
        public int NumSeance { get => numSeance; set => numSeance = value; }
    }
}
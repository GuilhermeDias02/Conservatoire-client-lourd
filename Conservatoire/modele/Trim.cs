using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.modele
{
    public class Trim
    {
        private string libelle;
        private DateTime datePaiement;
        private string paye;

        public Trim(string libelle, DateTime datePaiement, string paye)
        {
            this.libelle = libelle;
            this.DatePaiement = datePaiement;
            this.Paye = paye;
        }

        public string Description
        {
            get => ("Trim: " + libelle + " Date payment: "+ DatePaiement +" Payé: "+ Paye);
        }
        public string Paye { get => paye; set => paye = value; }
        public DateTime DatePaiement { get => ; set => datePaiement = value; }
    }
}

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
            this.datePaiement = datePaiement;
            this.paye = paye;
        }

        public string Decription
        {
            get => ("Trim: " + libelle + " Date payment: "+ datePaiement +" Payé: "+ paye);
        }
    }
}

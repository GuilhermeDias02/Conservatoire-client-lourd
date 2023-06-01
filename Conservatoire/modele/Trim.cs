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

        /// <summary>
        /// Crée un trimestre
        /// </summary>
        /// <param name="libelle"></param>
        /// <param name="datePaiement"></param>
        /// <param name="paye"></param>
        public Trim(string libelle, DateTime datePaiement, string paye)
        {
            this.libelle = libelle;
            this.DatePaiement = datePaiement;
            this.Paye = paye;
        }

        /// <summary>
        /// Défini comment va être affiché le trimestre dans une list box
        /// </summary>
        public string Description
        {
            get => ("Trim: " + libelle + " Date payment: "+ DatePaiement +" Payé: "+ Paye);
        }

        public string Paye { get => paye; set => paye = value; }
        public DateTime DatePaiement { get => datePaiement; set => datePaiement = value; }
        public string Libelle { get => libelle; set => libelle = value; }
    }
}

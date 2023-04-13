using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.modele
{
    public class Prof : Personnes
    {
        private string instrument;
        private double salaire;

        public string Instrument { get => instrument; }
        public double Salaire { get => salaire; }

        public Prof(int unId,string unNom , string unPrenom, string unTel, string unMail, string uneAdresse, string unInstrument, double unSalaire) : base(unId, unNom, unPrenom, unTel, unMail, uneAdresse)
        {
            this.instrument = unInstrument;
            this.salaire = unSalaire;
        }

        public override string Description
        {
            get => (base.Description + " Instrument: " + this.instrument + " Salaire: " + this.salaire);
        }
    }
}

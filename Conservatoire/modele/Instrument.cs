using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.modele
{
    public class Instrument
    {
        private string libelle;

        /// <summary>
        /// Crée un instrumet=nt
        /// </summary>
        /// <param name="unLibelle"></param>
        public Instrument(string unLibelle)
        {
            this.libelle = unLibelle;
        }
    }
}

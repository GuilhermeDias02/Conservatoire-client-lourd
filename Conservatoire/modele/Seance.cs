using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.modele
{
    public class Seance
    {
        private int idProf;
        private int numSeance;
        private string tranche;
        private string jour;
        private int niveau;
        private int capacite;

        /// <summary>
        /// Crée une séance
        /// </summary>
        /// <param name="unIdProf"></param>
        /// <param name="unNumSeance"></param>
        /// <param name="uneTranche"></param>
        /// <param name="unJour"></param>
        /// <param name="unNiveau"></param>
        /// <param name="uneCapacité"></param>
        public Seance(int unIdProf, int unNumSeance, string uneTranche, string unJour, int unNiveau, int uneCapacité)
        { 
            this.idProf = unIdProf;
            this.NumSeance = unNumSeance;
            this.tranche = uneTranche;
            this.jour = unJour;
            this.niveau = unNiveau;
            this.capacite = uneCapacité;
        }

        /// <summary>
        /// Défini comment va être affiché la séance dans une list box
        /// </summary>
        public virtual string Description
        {
            get => ("IdProf : " + this.idProf + " NumSeance: " + this.NumSeance + " Tranche: " + this.tranche + " Jour: " + this.jour + " Niveau: " + this.niveau + " Capacité: " + this.capacite);
        }

        public int NumSeance { get => numSeance; set => numSeance = value; }
    }
}

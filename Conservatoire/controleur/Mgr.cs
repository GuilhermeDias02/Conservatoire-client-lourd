using Conservatoire.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conservatoire.modele;
using System.Drawing.Text;

namespace Conservatoire.controleur
{
    internal class Mgr
    {
        private PersonneDAO persDAO;
        private ProfDAO profDAO;
        private SeanceDAO seanceDAO;
        private EleveDAO eleveDAO;

        private List<Personnes> maListePersonnes;
        private List<Prof> maListeProfs;
        private List<Seance> maListeSeances;
        private List<Eleve> maListeEleves;

        public Mgr()
        {
            persDAO = new PersonneDAO();
            profDAO = new ProfDAO();
            seanceDAO = new SeanceDAO();
            eleveDAO = new EleveDAO();

            maListePersonnes = new List<Personnes>();
            maListeProfs = new List<Prof>();
            maListeSeances = new List<Seance>();
            maListeEleves = new List<Eleve>();
        }



        // Récupération de la liste des employés à partir de la DAL
        public List<Personnes> chargementPersBD()
        {

            maListePersonnes = PersonneDAO.getPersonnes();

            return (maListePersonnes);
        }

        public List<Prof> chargementProfsBD()
        {
            maListeProfs = ProfDAO.getProfs();

            return (maListeProfs);
        }

        public List<Seance> chargementSeancesBD()
        {
            maListeSeances = SeanceDAO.getSeances();

            return (maListeSeances);
        }

        public List<Seance> chargementSeancesProfBD(int unIdProf)
        {
            maListeSeances = SeanceDAO.getSeancesProf(unIdProf);

            return (maListeSeances);
        }

        public List<Eleve> chargementEleveInscritsBD(int unNumSeance)
        {
            maListeEleves = EleveDAO.getElevesInscrits(unNumSeance);

            return (maListeEleves);
        }
    }
}

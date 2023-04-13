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
    public class Mgr
    {
        private List<Personnes> maListePersonnes;
        private List<Prof> maListeProfs;
        private List<Seance> maListeSeances;
        private List<Eleve> maListeEleves;
        private List<string> maListeInstruments;

        public Mgr()
        {
            maListePersonnes = new List<Personnes>();
            maListeProfs = new List<Prof>();
            maListeSeances = new List<Seance>();
            maListeEleves = new List<Eleve>();
            maListeInstruments = new List<string>();
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

        public List<string> chargementInstruments()
        {
            maListeInstruments = InstrumentDAO.getInstruments();

            return (maListeInstruments);
        }

        public void ajoutProf(Prof unProf)
        {
            PersonneDAO.insertPersonne(unProf);

            ProfDAO.insertProf(PersonneDAO.getLastId(), unProf);
        }

        public void suppProf(Prof unProf)
        {
            ProfDAO.deleteProf(unProf.Id);

            PersonneDAO.deletePersonne(unProf.Id);
        }
    }
}

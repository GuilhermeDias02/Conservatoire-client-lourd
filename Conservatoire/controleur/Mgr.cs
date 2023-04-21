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
        private List<string> maListeTranches;
        private List<string> maListeJours;
        private List<int> maListeNiveaux;
        private List<Inscription> maListeInscriptions;

        public Mgr()
        {
            maListePersonnes = new List<Personnes>();
            maListeProfs = new List<Prof>();
            maListeSeances = new List<Seance>();
            maListeEleves = new List<Eleve>();
            maListeInstruments = new List<string>();
            maListeTranches = new List<string>();
            maListeJours = new List<string>();
            maListeNiveaux = new List<int>();
            maListeInscriptions = new List<Inscription>();
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

        public List<string> chargementTranches()
        {
            maListeTranches = TrancheDAO.getTranche();

            return (maListeTranches);
        }

        public List<string> chargementJours()
        {
            maListeJours = JourDAO.getJours();

            return (maListeJours);
        }

        public List<int> chargementNiveaux()
        {
            maListeNiveaux = NIveauDAO.getNiveaux();

            return (maListeNiveaux);
        }

        public void ajoutSeance(int id, string tranche, string jour, int niveau, int capacité)
        {
            SeanceDAO.insertSeance(id, tranche, jour, niveau, capacité);
        }

        public void suppSeance(int numSeance)
        {
            SeanceDAO.deleteSeance(numSeance);
        }

        public void modifSeance(int numSeance, string tranche, string jour)
        {
            SeanceDAO.modifSeance(numSeance, tranche, jour);
        }

        public Prof getUnProf(int id)
        {
            Prof p = ProfDAO.getProf(id);

            return p;
        }

        public void updateProf(int id, Prof unProf)
        {
            ProfDAO.updateProf(id, unProf);
            PersonneDAO.updatePersonneProf(id, unProf);
        }

        public List<Inscription> chargementInscriptionsBD()
        {
            maListeInscriptions = InscriptionDAO.getInscriptions();

            return (maListeInscriptions);
        }

        public List<Trim> chargementPaiementTrim(int idEleve, int numSeance)
        {
            List<Trim> maListeTrim = TrimDAO.getPaiementTrim(idEleve, numSeance);

            return (maListeTrim);
        }
    }
}

using Connecte;
using Conservatoire.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.DAL
{
    public class InscriptionDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "conservatoire4";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        // Récupération de la liste des employés
        public static List<Inscription> getInscriptions()
        {

            List<Inscription> lc = new List<Inscription>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("SELECT vprof.id as idProf, vprof.nom as nomProf, vprof.prenom as prenomProf, veleve.id as idEleve, veleve.nom as nomEleve, veleve.prenom as prenomEleve, seance.NUMSEANCE, seance.TRANCHE, seance.JOUR, DATEINSCRIPTION FROM inscription join vprof ON inscription.IDPROF = vprof.id JOIN veleve ON inscription.IDELEVE = veleve.id JOIN seance on inscription.NUMSEANCE = seance.NUMSEANCE;");


                MySqlDataReader reader = Ocom.ExecuteReader();

                Inscription i;




                while (reader.Read())
                {

                    int idProf = (int)reader.GetValue(0);
                    string nomProf = (string)reader.GetValue(1);
                    string prenomProf = (string)reader.GetValue(2);

                    int idEleve = (int)reader.GetValue(3);
                    string nomEleve = (string)reader.GetValue(4);
                    string prenomEleve = (string)reader.GetValue(5);

                    int numSeance = (int)reader.GetValue(6);
                    string tranche = (string)reader.GetValue(7);
                    string jour = (string)reader.GetValue(8);

                    DateTime dateInscription = (DateTime)reader.GetValue(9);

                    //Instanciation d'un Emplye
                    i = new Inscription(idProf, nomProf, prenomProf, idEleve, nomEleve, prenomEleve, numSeance, tranche, jour, dateInscription);

                    // Ajout de cet employe à la liste 
                    lc.Add(i);


                }



                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (lc);


            }

            catch (Exception emp)
            {

                throw (emp);

            }


        }
    }
}

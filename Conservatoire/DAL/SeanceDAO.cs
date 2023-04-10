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
    internal class SeanceDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "conservatoire4";
        private static string uid = "root";
        private static string mdp = "";

        private static ConnexionSql maConnexionSql;

        private static MySqlCommand Ocom;

        // Récupération de la liste des employés
        public static List<Seance> getSeances()
        {

            List<Seance> lc = new List<Seance>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("Select * from seance");

                MySqlDataReader reader = Ocom.ExecuteReader();

                Seance s;


                while (reader.Read())
                {

                    int idProf = (int)reader.GetValue(0);
                    int numSeance = (int)reader.GetValue(1);
                    string tranche = (string)reader.GetValue(2);
                    string jour = (string)reader.GetValue(3);
                    int niveau = (int)reader.GetValue(4);
                    int capacite = (int)reader.GetValue(5);

                    //Instanciation d'un Emplye
                    s = new Seance(idProf, numSeance, tranche, jour, niveau, capacite);

                    // Ajout de cet employe à la liste 
                    lc.Add(s);


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

        public static List<Seance> getSeancesProf(int unIdProf)
        {

            List<Seance> lc = new List<Seance>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("SELECT * FROM seance WHERE idprof = " + unIdProf);

                /*Ocom.CommandText = "SELECT * FROM seance WHERE idprof= @idProf";
                Ocom.Prepare();

                Ocom.Parameters.AddWithValue("@idProf", unIdProf);*/

                MySqlDataReader reader = Ocom.ExecuteReader();

                Seance s;


                while (reader.Read())
                {

                    int idProf = (int)reader.GetValue(0);
                    int numSeance = (int)reader.GetValue(1);
                    string tranche = (string)reader.GetValue(2);
                    string jour = (string)reader.GetValue(3);
                    int niveau = (int)reader.GetValue(4);
                    int capacite = (int)reader.GetValue(5);

                    //Instanciation d'un Emplye
                    s = new Seance(idProf, numSeance, tranche, jour, niveau, capacite);

                    // Ajout de cet employe à la liste 
                    lc.Add(s);


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

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
    public class SeanceDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "conservatoire4";
        private static string uid = "root";
        private static string mdp = "";

        private static string connectionString = "server=localhost;userid=root;password=;database=conservatoire4";

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

                /*maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("SELECT * FROM seance WHERE idprof = " + unIdProf);

                MySqlDataReader reader = Ocom.ExecuteReader();*/

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                command.Parameters.AddWithValue("@idprof", unIdProf);

                command.CommandText = "Select * from seance where idprof = @idprof";

                MySqlDataReader reader = command.ExecuteReader();

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

                connection.Close();

                // Envoi de la liste au Manager
                return (lc);


            }

            catch (Exception emp)
            {

                throw (emp);

            }


        }

        public static void insertSeance(int id, string tranche, string jour, int niveau, int capacite)
        {

            try
            {

                /*maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("INSERT INTO seance (idprof, tranche, jour, niveau, capacite) VALUES ("+ id +", '"+ tranche +"', '"+ jour +"', "+ niveau +", "+ capacité +")");*/

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@tranche", tranche);
                command.Parameters.AddWithValue("@jour", jour);
                command.Parameters.AddWithValue("@niveau", niveau);
                command.Parameters.AddWithValue("@capacite", capacite);

                command.CommandText = "INSERT INTO seance (idprof, tranche, jour, niveau, capacite) VALUES ( @id, @tranche, @jour, @niveau, @capacité)";


                int i = Ocom.ExecuteNonQuery();

                //maConnexionSql.closeConnection();
                connection.Close();
            }

            catch (Exception emp)
            {

                throw (emp);
            }

        }

        public static void deleteSeance(int unNumSeance)
        {

            try
            {

                /*maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("DELETE FROM seance WHERE numseance = " + unNumSeance);*/

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                command.Parameters.AddWithValue("@numseance", unNumSeance);

                command.CommandText = "DELETE FROM seance WHERE numseance = @numseance";


                int i = command.ExecuteNonQuery();



                //maConnexionSql.closeConnection();
                connection.Close();


            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }

        public static void modifSeance(int unNumSeance, string uneTranche, string unJour)
        {

            try
            {

                /*maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("UPDATE seance SET tranche = '"+ uneTranche +"', jour = '"+ unJour +"' WHERE numseance = "+ unNumSeance);*/

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                command.Parameters.AddWithValue("@numseance", unNumSeance);
                command.Parameters.AddWithValue("@tranche", uneTranche);
                command.Parameters.AddWithValue("@jour", unJour);

                command.CommandText = "UPDATE seance SET tranche = @trance, jour = @jour WHERE numseance = @numseance";

                int i = command.ExecuteNonQuery();



                //maConnexionSql.closeConnection();
                connection.Close();


            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }
    }
}

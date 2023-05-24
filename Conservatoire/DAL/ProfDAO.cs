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
    public class ProfDAO : PersonneDAO
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
        public static List<Prof> getProfs()
        {

            List<Prof> lc = new List<Prof>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("SELECT id, nom, prenom, tel, mail, adresse, instrument, salaire from personne join prof on personne.ID = prof.IDPROF;");


                MySqlDataReader reader = Ocom.ExecuteReader();

                Prof p;




                while (reader.Read())
                {

                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string tel = (string)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    string instrument = (string)reader.GetValue(6);
                    double salaire = (double)reader.GetValue(7);

                    //Instanciation d'un Emplye
                    p = new Prof(numero, nom, prenom, tel, mail, adresse, instrument, salaire);

                    // Ajout de cet employe à la liste 
                    lc.Add(p);


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

        public static Prof getProf(int id)
        {

            try
            {

                /*maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("SELECT id, nom, prenom, tel, mail, adresse, instrument, salaire from personne join prof on personne.ID = prof.IDPROF WHERE ID = "+ id +";");*/

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                command.Parameters.AddWithValue("@id", id);

                command.CommandText = "SELECT id, nom, prenom, tel, mail, adresse, instrument, salaire from personne join prof on personne.ID = prof.IDPROF WHERE ID = @id";


                MySqlDataReader reader = command.ExecuteReader();

                Prof p = new Prof(1000, "", "", "", "", "", "", 1000);




                while (reader.Read())
                {

                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string tel = (string)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    string instrument = (string)reader.GetValue(6);
                    double salaire = (double)reader.GetValue(7);

                    //Instanciation d'un Emplye
                    p = new Prof(numero, nom, prenom, tel, mail, adresse, instrument, salaire);

                }



                reader.Close();

                //maConnexionSql.closeConnection();
                connection.Close();

                // Envoi de la liste au Manager
                return (p);


            }

            catch (Exception emp)
            {

                throw (emp);

            }


        }

        public static void insertProf(int unId, Prof p)
        {

            try
            {

                /*maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("INSERT INTO prof (idprof, instrument, salaire) VALUES ('" + unId + "', '" + p.Instrument + "', '"+ p.Salaire +"')");*/

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                command.Parameters.AddWithValue("@idprof", unId);
                command.Parameters.AddWithValue("@instrument", p.Instrument);
                command.Parameters.AddWithValue("@salaire", p.Salaire);

                command.CommandText = "INSERT INTO prof (idprof, instrument, salaire) VALUES (@idprof, @instrument, @salaire)";

                int i = command.ExecuteNonQuery();

                //maConnexionSql.closeConnection();
                connection.Close();
            }

            catch (Exception emp)
            {

                throw (emp);
            }

        }

        public static void deleteProf(int unId)
        {

            try
            {

                /*maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("DELETE FROM prof WHERE idprof = " + unId);*/

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                command.Parameters.AddWithValue("@idprof", unId);

                command.CommandText = "DELETE FROM prof WHERE idprof = @idprof";

                int i = command.ExecuteNonQuery();



                //maConnexionSql.closeConnection();
                connection.Close();


            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }

        public static void updateProf(int unId, Prof p)
        {
            try
            {

                /*maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("update prof set instrument = '" + p.Instrument + "', salaire = "+ p.Salaire +" where idProf = "+ unId);*/

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                command.Parameters.AddWithValue("@idprof", unId);
                command.Parameters.AddWithValue("@instrument", p.Instrument);
                command.Parameters.AddWithValue("@idprof", unId);

                command.CommandText = "update prof set instrument = @instrument, salaire = @salaire where idProf = @idprof";

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

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
    public class TrimDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "conservatoire4";

        private static string uid = "root";

        private static string mdp = "";

        private static string connectionString = "server=localhost;userid=root;password=;database=conservatoire4";

        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        /// <summary>
        /// Récupération de la liste des trimestres
        /// </summary>
        /// <param name="idEleve"></param>
        /// <param name="numSeance"></param>
        /// <returns></returns>
        public static List<Trim> getPaiementTrim(int idEleve, int numSeance)
        {

            List<Trim> lc = new List<Trim>();

            try
            {

                /*maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("select libelle, datePaiement, paye from payer where idEleve= "+ idEleve +" and numseance="+ numSeance);*/

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                command.Parameters.AddWithValue("@ideleve", idEleve);
                command.Parameters.AddWithValue("@numseance", numSeance);

                command.CommandText = "select libelle, datePaiement, paye from payer where idEleve= @ideleve and numseance= @numseance";

                MySqlDataReader reader = command.ExecuteReader();

                Trim t;

                while (reader.Read())
                {

                    string libelle = (string)reader.GetValue(0);
                    DateTime datePaiement = (DateTime)reader.GetValue(1);
                    string paye;
                    if ((int)reader.GetValue(2) == 0)
                    {
                        paye = "non";
                    }
                    else
                    {
                        paye = "oui";
                    }

                    //Instanciation d'un Emplye
                    t = new Trim(libelle, datePaiement, paye);

                    // Ajout de cet employe à la liste 
                    lc.Add(t);

                }

                reader.Close();

                //maConnexionSql.closeConnection();
                connection.Close();

                // Envoi de la liste au Manager
                return (lc);

            }
            catch (Exception emp)
            {
                throw (emp);
            }
        }

        /// <summary>
        /// Modifie un trimestre
        /// </summary>
        /// <param name="unNumSeance"></param>
        /// <param name="uneTranche"></param>
        /// <param name="unJour"></param>
        public static void updateTrim(int unNumSeance, string uneTranche, string unJour)
        {

            try
            {

                /*maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("UPDATE seance SET tranche = '" + uneTranche + "', jour = '" + unJour + "' WHERE numseance = " + unNumSeance);

                int i = Ocom.ExecuteNonQuery();

                maConnexionSql.closeConnection();*/

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                command.Parameters.AddWithValue("@numseance", unNumSeance);
                command.Parameters.AddWithValue("@tranche", uneTranche);
                command.Parameters.AddWithValue("@jour", unJour);

                command.CommandText = "UPDATE seance SET tranche = @tranche, jour = @jour WHERE numseance = @numseance";


                int i = command.ExecuteNonQuery();

                connection.Close();
            }

            catch (Exception emp)
            {
                throw (emp);
            }


        }
    }
}

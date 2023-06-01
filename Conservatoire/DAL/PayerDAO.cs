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
    public class PayerDAO
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
        /// Modifie un paiement
        /// </summary>
        /// <param name="date"></param>
        /// <param name="paye"></param>
        /// <param name="idEleve"></param>
        /// <param name="numSeance"></param>
        /// <param name="libelle"></param>

        public static void updatePayer(string date, int paye, int idEleve, int numSeance, string libelle)
        {

            try
            {

                /*maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("UPDATE payer SET datepaiement = '"+ date +"', paye = "+ paye +" WHERE idEleve = '"+ idEleve +"' AND numseance = '"+ numSeance +"' AND libelle = '"+ libelle +"'");*/

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = connection.CreateCommand();

                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@paye", paye);
                command.Parameters.AddWithValue("@ideleve", idEleve);
                command.Parameters.AddWithValue("@numseance", numSeance);
                command.Parameters.AddWithValue("@libelle", libelle);

                command.CommandText = "UPDATE payer SET datepaiement = @date, paye = @paye WHERE idEleve = @ideleve AND numseance = @numseance AND libelle = @libelle";

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
using Connecte;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.DAL
{
    internal class NIveauDAO
    {

        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "conservatoire4";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        // Récupération de la liste des employés
        public static List<int> getNiveaux()
        {

            List<int> niveaux = new List<int>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("Select * from niveau");


                MySqlDataReader reader = Ocom.ExecuteReader();


                while (reader.Read())
                {

                    int i = (int)reader.GetValue(0);

                    niveaux.Add(i);
                }



                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (niveaux);


            }

            catch (Exception emp)
            {

                throw (emp);

            }
        }
    }
}

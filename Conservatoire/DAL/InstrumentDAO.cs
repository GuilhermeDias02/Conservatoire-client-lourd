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
    public class InstrumentDAO
    {


        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "conservatoire4";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        // Récupération de la liste des employés
        public static List<string> getInstruments()
        {

            List<string> Instruments = new List<string>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("Select * from instrument");


                MySqlDataReader reader = Ocom.ExecuteReader();


                while (reader.Read())
                {

                    string i = (string)reader.GetValue(0);

                    Instruments.Add(i);
                }



                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (Instruments);


            }

            catch (Exception emp)
            {

                throw (emp);

            }
        }
    }
}

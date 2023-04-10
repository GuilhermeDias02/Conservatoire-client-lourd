using Connecte;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conservatoire.modele;

namespace Conservatoire.DAL
{
    internal class PersonneDAO
    {

        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "conservatoire4";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        // Récupération de la liste des employés
        public static List<Personnes> getPersonnes()
        {

            List<Personnes> lc = new List<Personnes>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("Select * from personne");


                MySqlDataReader reader = Ocom.ExecuteReader();

                Personnes p;




                while (reader.Read())
                {

                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string tel = (string)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);

                    //Instanciation d'un Emplye
                    p = new Personnes(numero, nom, prenom, tel, mail, adresse);

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
    }
}

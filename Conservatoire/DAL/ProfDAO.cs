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


        public static void insertProf(int unId, Prof p)
        {

            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("INSERT INTO prof (idprof, instrument, salaire) VALUES ('" + unId + "', '" + p.Instrument + "', '"+ p.Salaire +"')");

                int i = Ocom.ExecuteNonQuery();

                maConnexionSql.closeConnection();

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

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("DELETE FROM prof WHERE idprof = " + unId);


                int i = Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();



            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }
    }
}

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



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        // Récupération de la liste des employés
        public static List<Trim> getPaiementTrim(int idEleve, int numSeance)
        {

            List<Trim> lc = new List<Trim>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("select libelle, datePaiement, paye from payer where idEleve= "+ idEleve +" and numseance="+ numSeance);

                MySqlDataReader reader = Ocom.ExecuteReader();

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

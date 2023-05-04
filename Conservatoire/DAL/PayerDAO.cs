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



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        // Récupération de la liste des employés

        public static void updatePayer(string date, int paye, int idEleve, int numSeance, string libelle)
        {

            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("UPDATE payer SET datepaiement = '"+ date +"', paye = "+ paye +" WHERE idEleve = '"+ idEleve +"' AND numseance = '"+ numSeance +"' AND libelle = '"+ libelle +"'");

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
﻿using Connecte;
using Conservatoire.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.DAL
{
    internal class EleveDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "conservatoire4";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;

        // Récupération de la liste des employés
        public static List<Eleve> getEleves()
        {

            List<Eleve> lc = new List<Eleve>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("SELECT id, nom, prenom, tel, mail, adresse, niveau, bourse from personne join eleve on personne.ID = eleve.IDELEVE;");


                MySqlDataReader reader = Ocom.ExecuteReader();

                Eleve e;




                while (reader.Read())
                {

                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string tel = (string)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    int niveau= (int)reader.GetValue(6);
                    bool bourse = (bool)reader.GetValue(7);

                    //Instanciation d'un Emplye
                    e = new Eleve(numero, nom, prenom, tel, mail, adresse, niveau, bourse);

                    // Ajout de cet employe à la liste 
                    lc.Add(e);


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

        public static List<Eleve> getElevesInscrits(int unNumSeance)
        {
            List<Eleve> ele = new List<Eleve>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("Select id, nom, prenom, tel, mail, adresse, niveau, bourse from personne join eleve on personne.id = eleve.ideleve where id in (select  ideleve from inscription where numseance = " + unNumSeance + ")");
                MySqlDataReader reader = Ocom.ExecuteReader();
                Eleve e;

                while (reader.Read())
                {
                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string tel = (string)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    int niv = (int)reader.GetValue(6);
                    bool bourse = (bool)reader.GetValue(7);

                    //Instanciation d'un Emplye
                    e = new Eleve(numero, nom, prenom, tel, mail, adresse, niv, bourse);

                    // Ajout de cet employe à la liste 
                    ele.Add(e);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (ele);
            }
            catch (Exception m)
            {
                throw (m);
            }


        }
    }
}

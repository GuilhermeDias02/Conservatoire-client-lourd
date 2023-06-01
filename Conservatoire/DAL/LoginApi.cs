using Conservatoire.modele;
using Google.Protobuf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.DAL
{
    public class LoginApi
    {
        /// <summary>
        /// Récupère les comptes à partir de l'api
        /// </summary>
        /// <returns></returns>
        public static string recupJson()
        {
            WebClient web = new WebClient();

            string json;

            try
            {

                string url = string.Format("https://guilherme-de-oliveira.efrei.me/Api-Conservatoire/identifiants");

                json = web.DownloadString(url);

                return json;
            }

            catch (Exception execption)
            {
                throw (execption);
            }
        }

        /// <summary>
        /// Renvoie true si l'identifiant et le mot de passe se trouve dans les informations récupérées
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static bool verifLogin(string username, string password, string json)
        {
            bool res = false;

            List<Login> logins = JsonConvert.DeserializeObject<List<Login>>(json);

            string hash = MD5Hash.Hash.Content(password);

            foreach (Login login in logins)
            {
                if(login.Indentifiant == username && login.Mdp == hash)
                {
                    res = true;

                    return res; // ou break
                }
            }

            return res;
        }
    }
}

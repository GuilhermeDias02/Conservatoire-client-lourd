using Conservatoire.controleur;
using Conservatoire.modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Conservatoire.vue
{
    public partial class Form5 : Form
    {
        private Prof prof;

        List<Seance> seances;

        Mgr monManager;

        /// <summary>
        /// Récupère le professeur sélectionné
        /// </summary>
        /// <param name="unProf"></param>
        public Form5(Prof unProf)
        {
            this.prof = unProf;

            seances = new List<Seance>();

            monManager = new Mgr();

            InitializeComponent();
        }

        /// <summary>
        /// Ajoute une séance à un professeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Récupération des informations
            string tranche = textBox1.Text;
            string jour = textBox2.Text;
            int niveau = Convert.ToInt16(textBox3.Text);
            int capacite = Convert.ToInt16(textBox4.Text);

            // Récupération des tranches, jours et niveaux de la bdd
            List<string> tranches = monManager.chargementTranches();
            List<string> jours = monManager.chargementJours();
            List<int> niveaux= monManager.chargementNiveaux();


            int existe = 0;

            // Si la tranche rentrée n'existe pas alors existe = 1
            foreach (string tr in tranches)
            {
                if (tranche == tr)
                {
                    existe = 0;
                    break;
                }
                existe = 1;
            }
            // Si le jour rentré n'existe pas alors existe = 2
            foreach (string jr in jours)
            {
                if (jr == jour)
                {
                    existe = 0;
                    break;
                }
                existe = 2;
            }
            // Si le niveau rentré n'existe pas alors existe = 3
            foreach (int nv in niveaux)
            {
                if (niveau == nv)
                {
                    existe = 0;
                    break;
                }
                existe = 3;
            }

            // Si aucun problème on crée la séance sinon on affiche le message d'erreur correspondant
            switch (existe)
            {
                case 0:
                    monManager.ajoutSeance(this.prof.Id, tranche, jour, niveau, capacite);

                    MessageBox.Show("Un nouveau cours à été ajouté.");

                    break;
                case 1:
                    MessageBox.Show("Cette tranche horaire n'est pas possible.");

                    break;
                case 2:
                    MessageBox.Show("Le Conservatoire n'est pas ouvert ce jour de la semaine.");

                    break;
                case 3:
                    MessageBox.Show("Ce niveau n'est pas disponible.");

                    break;
            }
        }

        /// <summary>
        /// Au chargement de la fenêtre on charge les séances de ce professeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form5_Load(object sender, EventArgs e)
        {
            seances = monManager.chargementSeancesProfBD(this.prof.Id);

            afficheS();
        }

        /// <summary>
        /// Affiche le contenu de la liste de séances dans la list box
        /// </summary>
        private void afficheS()
        {
            try
            {
                listBox1.DataSource = seances;
                listBox1.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Supprime la séance sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            monManager.suppSeance(((Seance)listBox1.SelectedItem).NumSeance);

            MessageBox.Show("Ce cours a bien été supprimé");
        }

        /// <summary>
        /// Modifie la séance sélectionnée et vérifie les tranches et jours rentrés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            // Récupération des informations
            int numSeance = ((Seance)listBox1.SelectedItem).NumSeance;
            string tranche = textBox5.Text;
            string jour = textBox6.Text;

            // Récupération des informations dans la bdd
            List<string> tranches = monManager.chargementTranches();
            List<string> jours = monManager.chargementJours();

            int existe = 0;

            // Si la tranche rentrée n'existe pas alors existe = 1
            foreach (string tr in tranches)
            {
                if (tranche == tr)
                {
                    existe = 0;
                    break;
                }
                existe = 1;
            }
            // Si le jour rentré n'existe pas alors existe = 2
            foreach (string jr in jours)
            {
                if (jr == jour)
                {
                    existe = 0;
                    break;
                }
                existe = 2;
            }

            // En fonction du résultat modifie la séance ou affiche le message d'erreur correspondant
            switch (existe)
            {
                case 0:
                    monManager.modifSeance(numSeance, tranche, jour);

                    MessageBox.Show("Un nouveau cours à été ajouté.");

                    break;
                case 1:
                    MessageBox.Show("Cette tranche horaire n'est pas possible.");

                    break;
                case 2:
                    MessageBox.Show("Le Conservatoire n'est pas ouvert ce jour de la semaine.");

                    break;
            }
        }

        /// <summary>
        /// Rafraîchit la liste de séances
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            seances = monManager.chargementSeancesProfBD(this.prof.Id);

            afficheS();
        }
    }
}

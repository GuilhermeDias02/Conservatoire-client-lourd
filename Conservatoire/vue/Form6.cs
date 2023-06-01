using Conservatoire.controleur;
using Conservatoire.modele;
using Mysqlx.Crud;
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
    public partial class Form6 : Form
    {
        Mgr monManager;

        List<Inscription> lInscriptions;
        List<Trim> lTrim;

        public Form6()
        {
            InitializeComponent();

            monManager = new Mgr();
        }

        /// <summary>
        /// Au chargement de la fenêtre affiche les inscriptions dans la list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form6_Load(object sender, EventArgs e)
        {
            lInscriptions = monManager.chargementInscriptionsBD();

            affiche();
        }

        /// <summary>
        /// Affiche les informations de la liste d'inscriptions dans la list box
        /// </summary>
        private void affiche()
        {
            try
            {
                listBox1.DataSource = lInscriptions;
                listBox1.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Affiches les paiements par trimestre de l'inscription sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lTrim = monManager.chargementPaiementTrim(((Inscription)listBox1.SelectedItem).IdEleve, ((Inscription)listBox1.SelectedItem).NumSeance);

            afficheT();
        }

        /// <summary>
        /// Affiche les informations de la liste de trimestres dans la list box
        /// </summary>
        private void afficheT()
        {
            try
            {
                listBox2.DataSource = lTrim;
                listBox2.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Affiche la couleur rouge ou verte en fonction de l'état du paiement pour chaque trimestre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Brush brush = Brushes.Black; // seulement s'il y a un problème

            if (((Trim)listBox2.Items[e.Index]).Paye == "non")
            {
                brush = Brushes.Red; // si c'est pas encore payé
            }
            else
            {
                brush = Brushes.SeaGreen; // si c'est payé
            }

            e.Graphics.DrawString(((Trim)listBox2.Items[e.Index]).Description, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        }

        /// <summary>
        /// Prérempli la date en fonction du trimestre sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                textBox1.Text = ((Trim)listBox2.SelectedItem).DatePaiement.ToString("yyyy/MM/dd");
            }
        }

        /// <summary>
        /// Coonfirme le paiement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string date = textBox1.Text;
            int idEleve = ((Inscription)listBox1.SelectedItem).IdEleve;
            int numSeance = ((Inscription)listBox1.SelectedItem).NumSeance;
            string libelle = ((Trim)listBox2.SelectedItem).Libelle;

            monManager.confirmerPaiement(date, idEleve, numSeance, libelle);
        }
    }
}

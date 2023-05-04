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

        private void Form6_Load(object sender, EventArgs e)
        {
            lInscriptions = monManager.chargementInscriptionsBD();

            affiche();
        }

        private void affiche()
        {
            try
            {
                listBox1.DataSource = null;
                listBox1.DataSource = lInscriptions;
                listBox1.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lTrim = monManager.chargementPaiementTrim(((Inscription)listBox1.SelectedItem).IdEleve, ((Inscription)listBox1.SelectedItem).NumSeance);

            afficheT();
        }

        private void afficheT()
        {
            try
            {
                listBox2.DataSource = null;
                listBox2.DataSource = lTrim;
                listBox2.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            //textBox1.Text = ((Trim)listBox2.SelectedItem).DatePaiement.ToString("yyyy/MM/dd");

            //textBox1.Text = date.ToString("yyyy/MM/dd");

            //textBox1.Text = ((Trim)listBox2.SelectedItem).Paye;
        }

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

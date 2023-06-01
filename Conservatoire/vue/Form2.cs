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

namespace Conservatoire.vue
{
    public partial class Form2 : Form
    {
        Mgr monManager;

        List<Prof> lProfs = new List<Prof>();

        public Form2()
        {
            InitializeComponent();
            monManager = new Mgr();
        }

        /// <summary>
        /// Lors du chargement de la fenêtre on charge et affiche les professeurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            lProfs = monManager.chargementProfsBD();

            affiche();
        }

        /// <summary>
        /// Affiche les informations de la liste de profs dans la listeBox
        /// </summary>
        private void affiche()
        {
            try
            {
                listBox1.DataSource = null;
                listBox1.DataSource = lProfs;
                listBox1.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Affiche la troisième fenêtre et envoie l'id du professeur selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int unIdProf = ((Personnes)listBox1.SelectedItem).Id;
            Form3 form3 = new Form3(unIdProf);

            form3.ShowDialog();
        }

        /// <summary>
        /// Affiche la quatrième fenêtre et envoie le professeur selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Prof unProf = (Prof)listBox1.SelectedItem;

            Form4 form4 = new Form4(unProf);
            form4.ShowDialog();
        }

        /// <summary>
        /// Rafraîchit la liste de profs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            lProfs = monManager.chargementProfsBD();

            affiche();
        }

        /// <summary>
        /// Affiche la cinqième fenêtre et envoie le professeur selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Prof unProf = (Prof)listBox1.SelectedItem;

            Form5 form5 = new Form5(unProf);
            form5.ShowDialog();
        }

        /// <summary>
        /// Affiche la sixième fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }
    }
}

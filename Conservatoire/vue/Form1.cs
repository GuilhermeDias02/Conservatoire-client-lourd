using Conservatoire.controleur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conservatoire.modele;
using Conservatoire.vue;

namespace Conservatoire
{
    public partial class Form1 : Form
    {
        Mgr monManager;
        public Form1()
        {
            InitializeComponent();

            monManager = new Mgr();
        }

        /// <summary>
        /// clic bouton de connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Si les informations rentrées sont bonnes alors affiche la deuxième fenêtre
            if (monManager.verifLogin(textBox1.Text, textBox2.Text))
            {
                this.Hide();

                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            // Sinon affiche un message d'erreur
            else
            {
                MessageBox.Show("Réessayez");
            }
        }
    }
}

using Conservatoire.controleur;
using Conservatoire.modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conservatoire.vue
{
    public partial class Form4 : Form
    {
        private Prof prof;

        private Mgr monManager;

        /// <summary>
        /// Récupère le professeur sélectionné
        /// </summary>
        /// <param name="unProf"></param>
        public Form4(Prof unProf)
        {
            this.prof = unProf;
            monManager = new Mgr();

            InitializeComponent();
        }

        /// <summary>
        /// Ajoute un nouveau professeur et vérifie que l'instrument existe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Récupération des informations
            int id = 1;
            string nom = textBox1.Text;
            string prenom = textBox2.Text;
            string tel = textBox3.Text;
            string mail = textBox4.Text;
            string adresse = textBox5.Text;
            string instrument = textBox6.Text;
            double salaire = Convert.ToDouble(textBox7.Text);

            // Chargement des instruments éxistant dans la bd
            List<string> instruments = monManager.chargementInstruments();
            bool existe = false;

            // Si l'un des instruments de la bd est égal à celui rentré alors il existe
            foreach(string instr in instruments)
            {
                if (instrument == instr)
                {
                    existe = true;
                    break;
                }
            }

            // Si cet instrument n'existe pas alors on affiche un message d'erreur
            if(!existe)
            {
                MessageBox.Show("Cet instrument n'existe pas!");
            }
            // S'il existe on crée le nouveau professeur et on l'ajoute dans la bdd
            else
            {
                Prof nvProf = new Prof(id, nom, prenom, tel, mail, adresse, instrument, salaire);

                monManager.ajoutProf(nvProf);

                MessageBox.Show("Un nouveau professeur à été ajouté.");
            }
        }

        /// <summary>
        /// Supprime de professeur précédemment selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            monManager.suppProf(this.prof);

            MessageBox.Show("Ce professeur a bien été supprimé");
        }

        /// <summary>
        /// Au chargement de la page on prérempli le formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form4_Load(object sender, EventArgs e)
        {
            Prof p = monManager.getUnProf(this.prof.Id);

            textBox14.Text = p.Nom;
            textBox13.Text = p.Prenom;
            textBox12.Text = p.Tel;
            textBox11.Text = p.Mail;
            textBox10.Text = p.Adresse;
            textBox9.Text = p.Instrument;
            textBox8.Text = Convert.ToString(p.Salaire);
        }

        /// <summary>
        /// Modifie le professeur et vérifie que l'instrument existe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            // Récupération des informations
            int id = 1;
            string nom = textBox14.Text;
            string prenom = textBox13.Text;
            string tel = textBox12.Text;
            string mail = textBox11.Text;
            string adresse = textBox10.Text;
            string instrument = textBox9.Text;
            double salaire = Convert.ToDouble(textBox8.Text);

            // Chargement des instruments éxistant dans la bd
            List<string> instruments = monManager.chargementInstruments();
            bool existe = false;

            // Si l'un des instruments de la bd est égal à celui rentré alors il exist
            foreach (string instr in instruments)
            {
                if (instrument == instr)
                {
                    existe = true;
                    break;
                }
            }

            // Si cet instrument n'existe pas alors on affiche un message d'erreur
            if (!existe)
            {
                MessageBox.Show("Cet instrument n'existe pas!");
            }
            // S'il existe on crée le nouveau professeur et on le modifie dans la bdd
            else
            {
                Prof nvProf = new Prof(id, nom, prenom, tel, mail, adresse, instrument, salaire);

                monManager.updateProf(this.prof.Id, nvProf);

                MessageBox.Show("Ce professeur à bien été modifié.");
            }
        }
    }
}

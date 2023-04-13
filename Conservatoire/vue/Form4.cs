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

        public Form4(Prof unProf)
        {
            this.prof = unProf;
            monManager = new Mgr();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 1;
            string nom = textBox1.Text;
            string prenom = textBox2.Text;
            string tel = textBox3.Text;
            string mail = textBox4.Text;
            string adresse = textBox5.Text;
            string instrument = textBox6.Text;
            double salaire = Convert.ToDouble(textBox7.Text);

            List<string> instruments = monManager.chargementInstruments();
            bool existe = false;

            foreach(string instr in instruments)
            {
                if (instrument == instr)
                {
                    existe = true;
                    break;
                }
            }

            if(!existe)
            {
                MessageBox.Show("Cet instrument n'existe pas!");
            }
            else
            {
                Prof nvProf = new Prof(id, nom, prenom, tel, mail, adresse, instrument, salaire);

                monManager.ajoutProf(nvProf);

                MessageBox.Show("Un nouveau professeur à été ajouté.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            monManager.suppProf(this.prof);

            MessageBox.Show("Ce professeur a bien été supprimé");
        }
    }
}

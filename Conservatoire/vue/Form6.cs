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
                listBox2.DataSource = lTrim;
                listBox2.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

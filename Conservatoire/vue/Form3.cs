using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conservatoire.controleur;
using Conservatoire.modele;

namespace Conservatoire.vue
{
    public partial class Form3 : Form
    {
        private int idProf;

        Mgr monManager;

        List<Seance> lSeance;
        List<Eleve> lEleve;

        public Form3(int unIdProf)
        {
            this.idProf = unIdProf;
            monManager = new Mgr();

            lSeance = new List<Seance>();
            lEleve = new List<Eleve>();

            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lSeance = monManager.chargementSeancesProfBD(this.idProf);

            afficheS();
        }

        private void afficheS()
        {
            try
            {
                listBox1.DataSource = lSeance;
                listBox1.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void afficheE()
        {
            try
            {
                listBox2.DataSource = lEleve;
                listBox2.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lEleve = monManager.chargementEleveInscritsBD(((Seance)listBox1.SelectedItem).NumSeance);

            afficheE();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            lEleve = monManager.chargementEleveInscritsBD(((Seance)listBox1.SelectedItem).NumSeance);

            afficheE();
        }
    }
}

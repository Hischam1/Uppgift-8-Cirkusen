using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uppgift_8___Cirkusen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // EFFEKTER
            groupBox2.Enabled = false;
         
        }
        medlem m = new medlem();
        aktivitet aktuellAktivitet = new aktivitet();
        träningsgrupper tr = new träningsgrupper();
        

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Text = "Välj medlem:";
            label1.Text = "Medlem:";
            groupBox2.Enabled = true;

            m.Visamedlamar();
            listBox1.DisplayMember = "NamnDisplay";
            listBox1.DataSource = m.medlemlista;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            groupBox2.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void rensalistaListB2_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* m = (medlem)listBox1.SelectedItem;

            if (m != null)
            {
               

                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.medlemlista;

            }*/
        }

        /*private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Text = "Välj ledare:";
            label1.Text = "Ledare:";

            m.Visaledare();
            listBox1.DisplayMember = "NamnDisplay";
            listBox1.DataSource = m.medlemlista;
        }*/

        private void ledarecheckbox_CheckedChanged(object sender, EventArgs e)
        {


            if (ledarecheckbox.Checked)
            {
                groupBox2.Text = "Välj ledare:";
                label1.Text = "Ledare:";
                m.Visaledare();
                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.medlemlista;
            }

            else
            {
                groupBox2.Text = "Välj medlem:";
                label1.Text = "Medlem:";

                m.Visamedlamar();
                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.medlemlista;

            }

        }

        private void visaakt_Click(object sender, EventArgs e)
        {
            aktuellAktivitet.VisaAktivitet();

            listBox2.DisplayMember = "aktivitetDisplay";
            listBox2.DataSource = aktuellAktivitet.aktivitetslista;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tr.VisaTräningsgrupper();

            m.Visamedlamar();
            listBox3.DisplayMember = "TräningsgruppsDisplay";
            listBox3.DataSource = tr.träningsgruppslista;

        }
    }
}

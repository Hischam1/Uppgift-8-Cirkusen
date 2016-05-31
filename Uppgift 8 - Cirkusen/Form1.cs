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
            // groupBox2.Enabled = false;
         
        }
        medlem m = new medlem();
        aktivitet aktuellAktivitet = new aktivitet();
        träningsgrupper tr = new träningsgrupper();
        

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Text = "Välj medlem:";
            label1.Text = "Medlem:";
            groupBox2.Enabled = true;
            ledarecheckbox.Checked = false;

            m.Visamedlamar();
            listBox1.DisplayMember = "NamnDisplay";
            listBox1.DataSource = m.medlemlista;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            //groupBox2.Enabled = false;

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
            m = (medlem)listBox1.SelectedItem;

            if (m != null)
            {
                textBox1.Text = m.förnamn;
                textBox2.Text = m.efternamn;
                textBox3.Text = m.medlemstyp;
                textBox6.Text = m.personnr.ToString();
                textBox5.Text = m.telefon;

                if (ledarecheckbox.Checked)
                {
                    tr.VisaSelectedTräningsgruppLedare(m.medlemsid);
                    listBox3.DisplayMember = "TräningsgruppsDisplay";
                    listBox3.DataSource = tr.träningsgruppslista;
                }
                else
                {
                    tr.VisaSelectedTräningsgruppMedlem(m.medlemsid);
                    listBox3.DisplayMember = "TräningsgruppsDisplay";
                    listBox3.DataSource = tr.träningsgruppslista;
                }

            }

        }

        private void ledarecheckbox_CheckedChanged(object sender, EventArgs e)
        {


            if (ledarecheckbox.Checked)
            {
                groupBox2.Text = "Välj ledare:";
                label1.Text = "Ledare:";
                groupBox4.Text = "Ansvarar för:";
                m.Visaledare();
                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.medlemlista;
            }

            else
            {
                groupBox2.Text = "Välj medlem:";
                label1.Text = "Medlem:";
                groupBox4.Text = "Tillhör:";

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
            groupBox4.Text = "Träningsgrupper:";
            listBox3.DisplayMember = "TräningsgruppsDisplay";
            listBox3.DataSource = tr.träningsgruppslista;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox3.DataSource = null;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tr.VisaTräningsgrupperSortNamn();

            listBox3.DisplayMember = "TräningsgruppsDisplay";
            listBox3.DataSource = tr.träningsgruppslista;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tr.VisaTräningsgrupperSortTermin();

            listBox3.DisplayMember = "TräningsgruppsDisplay";
            listBox3.DataSource = tr.träningsgruppslista;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            tr.VisaTräningsgrupperSortLedare();

            listBox3.DisplayMember = "TräningsgruppsDisplay";
            listBox3.DataSource = tr.träningsgruppslista;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            m.VisamedlamarSorteraNamn();

            listBox1.DisplayMember = "NamnDisplay";
            listBox1.DataSource = m.medlemlista;

            if (ledarecheckbox.Checked)
            {
                m.VisamedlamarSorteraLedareNamn();
                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.medlemlista;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            m.VisamedlamarSorteraMedlemstyp();

            listBox1.DisplayMember = "NamnDisplay";
            listBox1.DataSource = m.medlemlista;

            if (ledarecheckbox.Checked)
            {
                m.VisamedlamarSorteraLedareMedlemstyp();
                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.medlemlista;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            m.LäggTillMedlem(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox6.Text), textBox5.Text);
            m.Visamedlamar();
            listBox1.DisplayMember = "NamnDisplay";
            listBox1.DataSource = m.medlemlista;

            if (ledarecheckbox.Checked)
            {
                m.LäggTillMedlem(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox6.Text), textBox5.Text);
                m.Visaledare();
                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.medlemlista;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (textBox5.Text.Length > 10)
            {

                if (ledarecheckbox.Checked)
                {
                    MessageBox.Show("Ett telefonnummer får endast ha 10 siffor. \nExempel: 070xxxxxxx");
                    m.Visaledare();
                    listBox1.DisplayMember = "NamnDisplay";
                    listBox1.DataSource = m.medlemlista;
                }
                else
                {
                    MessageBox.Show("Ett telefonnummer får endast ha 10 siffor. \nExempel: 070xxxxxxx");
                    m.Visamedlamar();
                    listBox1.DisplayMember = "NamnDisplay";
                    listBox1.DataSource = m.medlemlista;
                }

            }
            else
            {

            if (ledarecheckbox.Checked)
            {
                m.UppdateraMedlem(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox6.Text), textBox5.Text);
                m.Visaledare();
                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.medlemlista;
            }
            else
            {
                m.UppdateraMedlem(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox6.Text), textBox5.Text);
                m.Visamedlamar();
                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.medlemlista;
            }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            m.TaBortMedlem();
            listBox1.DisplayMember = "NamnDisplay";
            listBox1.DataSource = m.medlemlista;

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            aktuellAktivitet.VisaAktivitetSorteraID();
            listBox2.DisplayMember = "aktivitetDisplay";
            listBox2.DataSource = aktuellAktivitet.aktivitetslista;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            aktuellAktivitet.VisaAktivitetSorteraDatum();
            listBox2.DisplayMember = "aktivitetDisplay";
            listBox2.DataSource = aktuellAktivitet.aktivitetslista;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            aktuellAktivitet = (aktivitet)listBox2.SelectedItem;

            if (m != null)
            {
                m.VisaSelectedAktivitetMedlem(m.medlemsid);
                listBox4.DisplayMember = "NamnDisplay";
                listBox4.DataSource = m.medlemlista;
            }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}

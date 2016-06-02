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

            listBox7.DataSource = null;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            aktuellAktivitet.aktivitetslista = null;
            aktuellAktivitet.aktivitetslistaResultat = null;
            m.medlemslistaTOTAL = null;
            m.medlemslistaFrånSpecifikAktivitet = null;

            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox4.DataSource = null;
            listBox5.DataSource = null;
            listBox7.DataSource = null;

            listBox2.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();

            label7.Text = null;
            label10.Text = null;

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

                aktuellAktivitet.VisaSelectedMedlemsAktiviteter(m.medlemsid);
                listBox2.DisplayMember = "AktivitetDisplay";
                listBox2.DataSource = aktuellAktivitet.medlemsaktivitetslista;
            }
        }

        private void ledarecheckbox_CheckedChanged(object sender, EventArgs e)
        {

            if (ledarecheckbox.Checked)
            {
                groupBox2.Text = "Välj ledare:";
                label1.Text = "Ledare:";
                m.Visaledare();
                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.ledarlista;
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

        private void button5_Click(object sender, EventArgs e)
        {

            tr.VisaTräningsgrupper();
            listBox3.DisplayMember = "TräningsgruppsDisplay";
            listBox3.DataSource = tr.träningsgruppslista;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            listBox3.DataSource = null;
            listBox4.DataSource = null;
            listBox5.DataSource = null;
            listBox7.DataSource = null;
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
            if (checkBox1.Checked == false)
            {
                m.LäggTillMedlem(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox6.Text), textBox5.Text);
                m.Visamedlamar();
                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.medlemlista;
            }


            else if (checkBox1.Checked == true)
            {
                m.LäggTillLedare(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox6.Text), textBox5.Text);
                m.Visaledare();
                listBox1.DisplayMember = "NamnDisplay";
                listBox1.DataSource = m.ledarlista;

                ledarecheckbox.Checked = true;
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
            m = (medlem)listBox1.SelectedItem;

            if (m != null)
            {

                if (ledarecheckbox.Checked)
                {
                    m.TaBortLedare(m.medlemsid);
                    m.Visaledare();
                    aktuellAktivitet.VisaAktivitet();
                    listBox1.DisplayMember = "NamnDisplay";
                    listBox1.DataSource = m.medlemlista;
                    
                }
                else
                {
                    m.TaBortMedlem(m.medlemsid);
                    m.Visamedlamar();

                    aktuellAktivitet.VisaAktivitet();
                    listBox1.DisplayMember = "NamnDisplay";
                    listBox1.DataSource = m.medlemlista;
                    
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            aktuellAktivitet = (aktivitet)listBox2.SelectedItem;

            if (aktuellAktivitet != null)
            {
                m.VisaAllaMedlemmarITräningsgrupp(tr.träningsgruppsid);
                listBox7.DisplayMember = "NamnDisplay";
                listBox7.DataSource = m.medlemslistaTOTAL;

                m.VisaSelectedAktivitetMedlem(aktuellAktivitet.aktivitetsid);
                listBox4.DisplayMember = "NamnDisplay";
                listBox4.DataSource = m.medlemslistaFrånSpecifikAktivitet;

                m.VisaSelectedAktivitetLedare(aktuellAktivitet.aktivitetsid);
                listBox5.DisplayMember = "NamnDisplay";
                listBox5.DataSource = m.ledarlista;

                label7.Text = listBox4.Items.Count.ToString();

                label10.Text = listBox2.Items.Count.ToString();
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tr = (träningsgrupper)listBox3.SelectedItem;

            if (tr != null)
            {
                aktuellAktivitet.VisaSelectedTräningsgruppAktivitet(tr.träningsgruppsid);
                listBox2.DisplayMember = "AktivitetDisplay";
                listBox2.DataSource = aktuellAktivitet.aktivitetslista;

                label21.Text = listBox7.Items.Count.ToString();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            aktuellAktivitet.LäggTillAktivitet(Convert.ToInt32(träningsgruppsidTextBox.Text), BeskrivningTextBox.Text, DatumTextBox.Text, KlockslagTextBox.Text, PlatsTextbox.Text);
            aktuellAktivitet.VisaAktivitet();
            listBox2.DisplayMember = "aktivitetDisplay";
            listBox2.DataSource = aktuellAktivitet.aktivitetslista;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            m = (medlem)listBox1.SelectedItem;
            aktuellAktivitet = (aktivitet)listBox2.SelectedItem;

            if (m != null && aktuellAktivitet != null)
            {
                m.LäggTillMedlemIAktivitet(m.medlemsid, aktuellAktivitet.aktivitetsid);
                m.VisaSelectedAktivitetLedare(aktuellAktivitet.aktivitetsid);
                m.VisaSelectedAktivitetMedlem(aktuellAktivitet.aktivitetsid);
                listBox4.DisplayMember = "NamnDisplay";
                listBox4.DataSource = m.medlemslistaFrånSpecifikAktivitet;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            m = (medlem)listBox1.SelectedItem;
            aktuellAktivitet = (aktivitet)listBox2.SelectedItem;

            if (m != null && aktuellAktivitet != null)
            {
                m.TaBortMedlemFrånAktivitet(m.medlemsid, aktuellAktivitet.aktivitetsid);
                m.VisaSelectedAktivitetMedlem(aktuellAktivitet.aktivitetsid);
                listBox4.DisplayMember = "NamnDisplay";
                listBox4.DataSource = m.medlemslistaFrånSpecifikAktivitet;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            aktuellAktivitet = (aktivitet)listBox2.SelectedItem;

            if (aktuellAktivitet != null)
            {
                m.VisaSelectedAktivitetMedlem(aktuellAktivitet.aktivitetsid);
                listBox4.DisplayMember = "NamnDisplay";
                listBox4.DataSource = m.medlemlista;

                m.VisaSelectedAktivitetLedare(aktuellAktivitet.aktivitetsid);
                listBox5.DisplayMember = "NamnDisplay";
                listBox5.DataSource = m.ledarlista;

                label7.Text = listBox4.Items.Count.ToString();

                string a = aktuellAktivitet.RäknaSelectedAktivitet(aktuellAktivitet.träningsgruppsid).ToString();
                label10.Text = a;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tr = (träningsgrupper)listBox3.SelectedItem;

            if (tr != null)
            {              
                aktuellAktivitet.VisaAktivitetUtifrånDatum(tr.träningsgruppsid, FrånTextBox.Text, TillTextBox.Text);
                listBox2.DisplayMember = "AktivitetDisplay";
                listBox2.DataSource = aktuellAktivitet.aktivitetslistaResultat;
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Utskrift sker");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            m = (medlem)listBox1.SelectedItem;

            if (m != null)
            {
                aktuellAktivitet.VisaAktivitetUtifrånDatumMedlem(m.medlemsid, FrånTextBox.Text, TillTextBox.Text);
                listBox2.DisplayMember = "AktivitetDisplay";
                listBox2.DataSource = aktuellAktivitet.medlemsaktivitetslistaResultat;

                listBox7.DataSource = null;
            }
        }
    }
}

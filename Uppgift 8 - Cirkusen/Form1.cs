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

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Text = "Välj medlem:";
            label1.Text = "Medlem:";
            m.Visamedlamar();

            listBox1.DisplayMember = "NamnDisplay";
            listBox1.DataSource = m.medlemlista;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void rensalistaListB2_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Text = "Välj ledare:";
            label1.Text = "Ledare:";

            m.Visaledare();
            listBox1.DisplayMember = "NamnDisplay";
            listBox1.DataSource = m.medlemlista;
        }
    }
}

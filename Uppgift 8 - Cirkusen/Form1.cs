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

        public BindingList<medlem> medlemlista = new BindingList<medlem>();

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5433;User Id=administratör;Password=1234;Database=cirkus;");

            try
            {

                string sql = "SELECT * FROM medlem";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                medlem m;
                while (dr.Read())
                {
                    m = new medlem()
                    {
                        medlemsid = (int) dr["medlemsid"],
                        förnamn = dr["förnamn"].ToString(),
                        efternamn = dr["efternamn"].ToString()
                    };
                    medlemlista.Add(m);
                    //MessageBox.Show(dr["förnamn"].ToString());
                    listBox1.DisplayMember = "NamnDisplay";
                    listBox1.DataSource = medlemlista;
                }
            }
            catch (NpgsqlException ex)
            {
                if (ex.Code.Equals("28P01"))
                {
                    MessageBox.Show("Fel lösenord.");
                }
                if (ex.Code.Equals("42501"))
                {
                    MessageBox.Show("Användaren saknar nödvändiga rättigheter.");
                }
                else
                {
                    MessageBox.Show(ex.Code);
                }
                // MessageBox.Show(ex.Message);

            }
            finally
            {
                connect.Close();
            }



        }
    }
}

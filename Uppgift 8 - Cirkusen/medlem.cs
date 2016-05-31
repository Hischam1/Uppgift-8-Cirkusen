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
    public class medlem
    {
        BindingList<aktivitet> aktivitetlista = new BindingList<aktivitet>();

        public int medlemsid { get; set; }
        public string förnamn { get; set; }
        public string efternamn { get; set; }
        public string träningsgruppsnamn { get; set; }

        public string NamnDisplay
        {
            get
            {
                return medlemsid + " - " + förnamn + " " + efternamn + " \t\t |  " + träningsgruppsnamn;
            }             
        }
        public BindingList<medlem> medlemlista = new BindingList<medlem>();

        public void Visamedlamar()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

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
                        medlemsid = (int)dr["medlemsid"],
                        förnamn = dr["förnamn"].ToString(),
                        efternamn = dr["efternamn"].ToString(),
                        //träningsgruppsnamn = dr["namn"].ToString()

                    };
                    medlemlista.Add(m);
                    //MessageBox.Show(dr["förnamn"].ToString());

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
        public void Visaledare()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            try
            {
                string sql = "SELECT m.medlemsid,m.förnamn,m.efternamn,t.namn FROM medlem m, träningsgrupper t, ansvar a WHERE a.medlemsid = m.medlemsid AND a.träningsgruppsid = t.träningsgruppsid AND m.ledare = TRUE";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                medlem m;
                while (dr.Read())
                {
                    m = new medlem()
                    {
                        medlemsid = (int)dr["medlemsid"],
                        förnamn = dr["förnamn"].ToString(),
                        efternamn = dr["efternamn"].ToString(),
                        träningsgruppsnamn = dr["namn"].ToString()

                    };
                    medlemlista.Add(m);
                    //MessageBox.Show(dr["förnamn"].ToString());


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

        public BindingList<aktivitet> HämtaAktivitetlista()
        {
            return aktivitetlista;
        }

    }
}

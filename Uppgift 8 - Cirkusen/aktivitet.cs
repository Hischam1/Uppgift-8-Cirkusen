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
    public class aktivitet
    {
        public int aktivitetsid { get; set; }
        public int träningsgruppsid { get; set; }
        public string beskrivning { get; set; }
        public string datum { get; set; }
        public string klockslag { get; set; }
        public string plats { get; set; }
        public string träningsgruppsnamn { get; set; }
        //public string förnamn { get; set; }
        //public string efternamn { get; set; }
        //public int personnr { get; set; }
        //public int medlemsid { get; set; }


        public string aktivitetDisplay
        {
            get
            {
                return aktivitetsid + " - " + träningsgruppsnamn + "\t " + beskrivning + "\t " + datum + " - " + klockslag + " - " + plats;
            }

        }

        public BindingList<aktivitet> aktivitetslista = new BindingList<aktivitet>();

        public void VisaAktivitet()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            aktivitetslista.Clear();

            try
            {
                string sql = "SELECT a.aktivitetsid, a.beskrivning, a.datum, a.klockslag, a.plats, t.namn FROM aktivitet a, träningsgrupper t WHERE t.träningsgruppsid = a.träningsgruppsid";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                aktivitet akt;
                while (dr.Read())
                {
                    akt = new aktivitet()
                    {
                        aktivitetsid = (int)dr["aktivitetsid"],
                        träningsgruppsnamn = dr["namn"].ToString(),
                        beskrivning = dr["beskrivning"].ToString(),
                        datum = dr["datum"].ToString(),
                        klockslag = dr["klockslag"].ToString(),
                        plats = dr["plats"].ToString()

                    };
                    aktivitetslista.Add(akt);

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
        public void VisaAktivitetSorteraID()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            aktivitetslista.Clear();

            try
            {
                string sql = "SELECT a.aktivitetsid, a.beskrivning, a.datum, a.klockslag, a.plats, t.namn FROM aktivitet a, träningsgrupper t WHERE t.träningsgruppsid = a.träningsgruppsid ORDER BY a.aktivitetsid";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                aktivitet akt;
                while (dr.Read())
                {
                    akt = new aktivitet()
                    {
                        aktivitetsid = (int)dr["aktivitetsid"],
                        träningsgruppsnamn = dr["namn"].ToString(),
                        beskrivning = dr["beskrivning"].ToString(),
                        datum = dr["datum"].ToString(),
                        klockslag = dr["klockslag"].ToString(),
                        plats = dr["plats"].ToString()

                    };
                    aktivitetslista.Add(akt);

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
        public void VisaAktivitetSorteraDatum()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            aktivitetslista.Clear();

            try
            {
                string sql = "SELECT a.aktivitetsid, a.beskrivning, a.datum, a.klockslag, a.plats, t.namn FROM aktivitet a, träningsgrupper t WHERE t.träningsgruppsid = a.träningsgruppsid ORDER BY a.datum";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                aktivitet akt;
                while (dr.Read())
                {
                    akt = new aktivitet()
                    {
                        aktivitetsid = (int)dr["aktivitetsid"],
                        träningsgruppsnamn = dr["namn"].ToString(),
                        beskrivning = dr["beskrivning"].ToString(),
                        datum = dr["datum"].ToString(),
                        klockslag = dr["klockslag"].ToString(),
                        plats = dr["plats"].ToString()

                    };
                    aktivitetslista.Add(akt);

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

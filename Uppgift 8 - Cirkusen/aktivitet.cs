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
        public string förnamn { get; set; }
        public string efternamn { get; set; }
        public int personnr { get; set; }
        public int medlemsid { get; set; }
        public int antal { get; set; }
        public string datumfrån { get; set; }
        public string datumtill { get; set; }
        public string connectSQLadress = "Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;";


        public string aktivitetDisplay
        {
            get
            {
                return aktivitetsid + " - " + träningsgruppsnamn + "\t " + beskrivning + "\t " + datum + " - " + klockslag + " - " + plats + "\t " + förnamn + " " + efternamn;
            }
        }

        public BindingList<aktivitet> aktivitetslista = new BindingList<aktivitet>();
        public BindingList<aktivitet> medlemsaktivitetslista = new BindingList<aktivitet>();
        public BindingList<aktivitet> aktivitetslistaResultat = new BindingList<aktivitet>();
        public BindingList<aktivitet> medlemsaktivitetslistaResultat = new BindingList<aktivitet>();

        public void VisaAktivitet()
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            aktivitetslista.Clear();

            try
            {
                string sql = "SELECT  a.aktivitetsid, a.beskrivning, a.datum, a.klockslag, a.plats, t.namn FROM aktivitet a, träningsgrupper t WHERE t.träningsgruppsid = a.träningsgruppsid";
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
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

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
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

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
        public int RäknaSelectedAktivitet(int träningsgruppsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            //aktivitetslista.Clear();

            try
            {
                string sql = "SELECT COUNT(a.träningsgruppsid) as 'Antal' FROM aktivitet a, träningsgrupper t WHERE a.träningsgruppsid = t.träningsgruppsid AND a.träningsgruppsid = " + träningsgruppsid + " GROUP BY a.träningsgruppsid";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                aktivitet akt;
                while (dr.Read())
                {
                    akt = new aktivitet()
                    {
                        antal = (int)dr["Antal"]

                    };
                    //aktivitetslista.Add(akt);

                    
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

            return antal;
        }
        public void LäggTillAktivitet(int träningsgruppsid, string beskrivning, string datum, string klockslag, string plats)
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            aktivitetslista.Clear();

            Random random = new Random();

            try
            {
                string sql = "INSERT INTO aktivitet (aktivitetsid, träningsgruppsid, beskrivning, datum, klockslag, plats) VALUES ('" + random.Next(100000000, 199999999) + "', '" + träningsgruppsid + "', '" + beskrivning + "', '" + datum + "', '" + klockslag + "', '" + plats + "')";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

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
        public void VisaSelectedTräningsgruppAktivitet(int träningsgruppsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            aktivitetslista.Clear();

            try
            {
                string sql = "SELECT * FROM aktivitet a, träningsgrupper t WHERE t.träningsgruppsid = a.träningsgruppsid AND t.träningsgruppsid = '" + träningsgruppsid + "'";
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
        public void VisaAktivitetUtifrånDatum(int träningsgruppsid, string datumfrån, string datumtill)
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            aktivitetslistaResultat.Clear();

            try
            {
                string sql = "SELECT a.aktivitetsid, t.namn, a.träningsgruppsid, a.beskrivning, a.datum, a.klockslag, a.plats FROM träningsgrupper t, aktivitet a WHERE t.träningsgruppsid = a.träningsgruppsid AND a.träningsgruppsid = '" + träningsgruppsid + "' AND datum BETWEEN '" + datumfrån + "' and '" + datumtill + "'";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                aktivitet akt;
                while (dr.Read())
                {
                    akt = new aktivitet()
                    {
                        aktivitetsid = (int)dr["aktivitetsid"],
                        träningsgruppsid = (int)dr["träningsgruppsid"],
                        träningsgruppsnamn = dr["namn"].ToString(),
                        beskrivning = dr["beskrivning"].ToString(),
                        datum = dr["datum"].ToString(),
                        klockslag = dr["klockslag"].ToString(),
                        plats = dr["plats"].ToString()

                    };
                    aktivitetslistaResultat.Add(akt);

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
        public void VisaAktivitetUtifrånDatumMedlem(int medlemsid, string datumfrån, string datumtill)
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            medlemsaktivitetslistaResultat.Clear();

            try
            {
                string sql = "SELECT a.aktivitetsid, t.namn, a.beskrivning, a.datum, a.klockslag, a.plats FROM träningsgrupper t, aktivitet a, deltar d, medlem m WHERE t.träningsgruppsid = a.träningsgruppsid AND a.aktivitetsid = d.aktivitetsid AND d.medlemsid = m.medlemsid AND d.medlemsid = '" + medlemsid + "' AND datum BETWEEN '" + datumfrån + "'  and '" + datumtill + "'";
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
                    medlemsaktivitetslistaResultat.Add(akt);

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
        public void VisaSelectedMedlemsAktiviteter(int medlemsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            medlemsaktivitetslista.Clear();

            try
            {
                string sql = "SELECT a.aktivitetsid, t.namn, a.beskrivning, a.datum, a.klockslag, a.plats FROM aktivitet a, deltar d, medlem m, träningsgrupper t WHERE d.aktivitetsid = a.aktivitetsid AND m.medlemsid = d.medlemsid AND t.träningsgruppsid = a.träningsgruppsid AND m.medlemsid = '" + medlemsid + "'";
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
                    medlemsaktivitetslista.Add(akt);

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

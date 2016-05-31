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
        public string medlemstyp { get; set; }
        public int personnr { get; set; }
        public string telefon { get; set; }

        public string NamnDisplay
        {
            get
            {
                return medlemsid + " - " + förnamn + " " + efternamn + " \t\t   " + medlemstyp;
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
                        medlemstyp = dr["medlemstyp"].ToString(),
                        personnr = (int)dr["personnr"],
                        telefon = dr["telefon"].ToString()

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
                string sql = "SELECT m.medlemsid,m.förnamn,m.efternamn, m.medlemstyp, m.personnr, m.telefon FROM medlem m WHERE  m.ledare = TRUE";
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
                        medlemstyp = dr["medlemstyp"].ToString(),
                        personnr = (int)dr["personnr"],
                        telefon = dr["telefon"].ToString()

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
        public void VisamedlamarSorteraNamn()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            try
            {
                string sql = "SELECT * FROM medlem ORDER BY förnamn";
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
                        medlemstyp = dr["medlemstyp"].ToString(),
                        personnr = (int)dr["personnr"],
                        telefon = dr["telefon"].ToString()


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
        public void VisamedlamarSorteraMedlemstyp()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            try
            {
                string sql = "SELECT * FROM medlem ORDER BY medlemstyp";
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
                        medlemstyp = dr["medlemstyp"].ToString(),
                        personnr = (int)dr["personnr"],
                        telefon = dr["telefon"].ToString()


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
        public void VisamedlamarSorteraLedareNamn()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            try
            {
                string sql = "SELECT * FROM medlem WHERE ledare = TRUE ORDER BY förnamn";
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
                        medlemstyp = dr["medlemstyp"].ToString(),
                        personnr = (int)dr["personnr"],
                        telefon = dr["telefon"].ToString()

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
        public void VisamedlamarSorteraLedareMedlemstyp()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            try
            {
                string sql = "SELECT * FROM medlem WHERE ledare = TRUE ORDER BY medlemstyp";
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
                        medlemstyp = dr["medlemstyp"].ToString(),
                        personnr = (int)dr["personnr"],
                        telefon = dr["telefon"].ToString()

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
        public void LäggTillMedlem(string förnamn, string efternamn, string medlemstyp, int personnr, string telefon)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            Random random = new Random();

            try
            {
                string sql = "INSERT INTO medlem (medlemsid, förnamn, efternamn, medlemstyp, personnr, telefon) VALUES ('" + random.Next(1000) + "', '" + förnamn +"', '"+ efternamn +"', '"+ medlemstyp + "', '" + personnr + "', '" + telefon + "')";
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
        public void UppdateraMedlem(string förnamn, string efternamn, string medlemstyp, int personnr, string telefon)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            Random random = new Random();

            try
            {
                string sql = "UPDATE medlem SET förnamn = '" + förnamn + "', efternamn = '" + efternamn + "', medlemstyp = '" + medlemstyp + "', personnr = '" + personnr + "', telefon = '" + telefon + "' WHERE medlemsid = '" + medlemsid + "'";
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
        public void TaBortMedlem()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            Random random = new Random();

            try
            {
                string sql = "DELETE FROM medlem, deltar, tillhör, ansvar WHERE medlemsid = '" + medlemsid + "'";
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
        public void VisaSelectedAktivitetMedlem(int medlemsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            try
            {
                string sql = "SELECT m.förnamn, m.efternamn, m.personnr FROM medlem m, aktivitet a, deltar d WHERE m.medlemsid = d.medlemsid AND a.aktivitetsid = d.aktivitetsid AND m.medlemsid = '" + medlemsid + "'";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                medlem m;
                while (dr.Read())
                {
                    m = new medlem()
                    {

                        förnamn = dr["förnamn"].ToString(),
                        efternamn = dr["efternamn"].ToString(),
                        personnr = (int)dr["personnr"]


                    };
                    medlemlista.Add(m);

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

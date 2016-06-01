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
        public int aktivitetsid { get; set; }
        public int träningsgruppsid { get; set; }



        public string NamnDisplay
        {
            get
            {
                return medlemsid + " - " + förnamn + " " + efternamn + " \t    " + personnr + " \t\t\t    " + medlemstyp;
            }             
        }


        public BindingList<medlem> medlemlista = new BindingList<medlem>();
        public BindingList<medlem> ledarlista = new BindingList<medlem>();
        public BindingList<medlem> medlemslistaTOTAL = new BindingList<medlem>();
        public BindingList<medlem> medlemslistaFrånSpecifikAktivitet = new BindingList<medlem>();



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
        public void LäggTillLedare(string förnamn, string efternamn, string medlemstyp, int personnr, string telefon)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            Random random = new Random();

            try
            {
                string sql = "INSERT INTO medlem (medlemsid, förnamn, efternamn, medlemstyp, personnr, telefon, ledare) VALUES ('" + random.Next(1000) + "', '" + förnamn + "', '" + efternamn + "', '" + medlemstyp + "', '" + personnr + "', '" + telefon + "', TRUE)";
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
        public void TaBortMedlem(int medlemsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            Random random = new Random();

            try
            {
                string sql = "DELETE FROM medlem WHERE medlemsid = " + medlemsid;
                string sql2 = "DELETE FROM tillhör WHERE medlemsid = " + medlemsid;
                string sql3 = "DELETE FROM deltar WHERE medlemsid = " + medlemsid;
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, connect);
                NpgsqlCommand cmd3 = new NpgsqlCommand(sql3, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                NpgsqlDataReader dr2 = cmd2.ExecuteReader();
                NpgsqlDataReader dr3 = cmd3.ExecuteReader();

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
        public void TaBortLedare(int medlemsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            Random random = new Random();

            try
            {
                string sql = "DELETE FROM medlem WHERE medlemsid = " + medlemsid;
                string sql2 = "DELETE FROM ansvar WHERE medlemsid = " + medlemsid;
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                NpgsqlDataReader dr2 = cmd2.ExecuteReader();

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
        public void VisaSelectedAktivitetMedlem(int aktivitetsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemslistaFrånSpecifikAktivitet.Clear();
            
            try
            {
                string sql = "SELECT m.förnamn, m.efternamn, d.medlemsid, m.personnr FROM medlem m, deltar d, aktivitet a WHERE m.medlemsid = d.medlemsid AND d.aktivitetsid = a.aktivitetsid AND a.aktivitetsid = '" + aktivitetsid + "'";
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
                        personnr = (int)dr["personnr"]

                    };
                    medlemslistaFrånSpecifikAktivitet.Add(m);

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
        public void VisaSelectedAktivitetLedare(int aktivitetsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            ledarlista.Clear();

            try
            {
                string sql = "SELECT m.förnamn, m.efternamn, an.medlemsid, m.personnr FROM medlem m, ansvar an, aktivitet a, träningsgrupper t WHERE t.träningsgruppsid = a.träningsgruppsid AND t.träningsgruppsid = an.träningsgruppsid AND m.medlemsid = an.medlemsid AND a.träningsgruppsid = an.träningsgruppsid AND a.aktivitetsid = '" + aktivitetsid + "'";
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
                        personnr = (int)dr["personnr"]

                    };
                    ledarlista.Add(m);

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
        public void LäggTillMedlemIAktivitet(int medlemsid, int aktivitetsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            Random random = new Random();

            try
            {
                string sql = "INSERT INTO deltar (medlemsid, aktivitetsid) VALUES (" + medlemsid + ", "+ aktivitetsid +")";
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
                if (ex.Code.Equals("23505"))
                {
                    MessageBox.Show("Medlemmen finns redan i den valda aktiviteten.");
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
        public void TaBortMedlemFrånAktivitet(int medlemsid, int aktivitetsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemlista.Clear();

            Random random = new Random();

            try
            {
                string sql = "DELETE FROM deltar WHERE medlemsid = " + medlemsid + " AND aktivitetsid = " + aktivitetsid +"";
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
                if (ex.Code.Equals("23505"))
                {
                    MessageBox.Show("Medlemmen finns redan i den valda aktiviteten.");
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
        public void LäggTillLedareIAktivitet(int medlemsid, int träningsgruppsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            ledarlista.Clear();

            Random random = new Random();

            try
            {
                string sql = "INSERT INTO ansvar (medlemsid, träningsgruppsid) VALUES (" + medlemsid + ", " + träningsgruppsid + ")";
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
                if (ex.Code.Equals("23505"))
                {
                    MessageBox.Show("Medlemmen finns redan i den valda aktiviteten.");
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
        public void VisaAllaMedlemmarITräningsgrupp(int träningsgruppsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            medlemslistaTOTAL.Clear();

            try
            {
                string sql = "SELECT m.förnamn, m.efternamn, d.medlemsid, m.personnr FROM medlem m, deltar d, aktivitet a, träningsgrupper t WHERE m.medlemsid = d.medlemsid AND d.aktivitetsid = a.aktivitetsid AND t.träningsgruppsid = a.träningsgruppsid AND t.träningsgruppsid = '" + träningsgruppsid + "'"; ;
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
                        personnr = (int)dr["personnr"]

                    };
                    medlemslistaTOTAL.Add(m);

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

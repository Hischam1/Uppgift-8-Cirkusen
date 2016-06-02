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
    class träningsgrupper
    {

        public int träningsgruppsid { get; set; }
        public string namn { get; set; }
        public string termin { get; set; }
        public int medlemsid { get; set; }
        public string förnamn { get; set; }
        public string efternamn { get; set; }
        public int aktivitetsid { get; set; }
        public string träningsgruppsnamn { get; set; }
        public string beskrivning { get; set; }
        public string datum { get; set; }
        public string connectSQLadress = "Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;";

        public string TräningsgruppsDisplay
        {
            get
            {
                return träningsgruppsid + " - " + namn + " \t\t " + termin;
            }
        }
        public BindingList<träningsgrupper> träningsgruppslista = new BindingList<träningsgrupper>();

        public void VisaTräningsgrupper()
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            träningsgruppslista.Clear();

            try
            {
                string sql = "SELECT t.träningsgruppsid, t.namn, t.termin FROM träningsgrupper t";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                träningsgrupper tr;
                while (dr.Read())
                {
                    tr = new träningsgrupper()
                    {
                        träningsgruppsid = (int)dr["träningsgruppsid"],
                        namn = dr["namn"].ToString(),
                        termin = dr["termin"].ToString()

                    };
                    träningsgruppslista.Add(tr);

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
        public void VisaTräningsgrupperSortNamn()
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            träningsgruppslista.Clear();

            try
            {
                string sql = "SELECT t.träningsgruppsid, t.namn, t.termin, m.förnamn, m.efternamn FROM träningsgrupper t, medlem m, ansvar a WHERE m.medlemsid = a.medlemsid AND t.träningsgruppsid = a.träningsgruppsid ORDER BY t.namn";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                träningsgrupper tr;
                while (dr.Read())
                {
                    tr = new träningsgrupper()
                    {
                        träningsgruppsid = (int)dr["träningsgruppsid"],
                        namn = dr["namn"].ToString(),
                        termin = dr["termin"].ToString(),
                        förnamn = dr["förnamn"].ToString(),
                        efternamn = dr["efternamn"].ToString(),


                    };
                    träningsgruppslista.Add(tr);

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
        public void VisaTräningsgrupperSortTermin()
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            träningsgruppslista.Clear();

            try
            {
                string sql = "SELECT t.träningsgruppsid, t.namn, t.termin, m.förnamn, m.efternamn FROM träningsgrupper t, medlem m, ansvar a WHERE m.medlemsid = a.medlemsid AND t.träningsgruppsid = a.träningsgruppsid ORDER BY t.termin";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                träningsgrupper tr;
                while (dr.Read())
                {
                    tr = new träningsgrupper()
                    {
                        träningsgruppsid = (int)dr["träningsgruppsid"],
                        namn = dr["namn"].ToString(),
                        termin = dr["termin"].ToString(),
                        förnamn = dr["förnamn"].ToString(),
                        efternamn = dr["efternamn"].ToString(),


                    };
                    träningsgruppslista.Add(tr);

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
        public void VisaTräningsgrupperSortLedare()
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            träningsgruppslista.Clear();

            try
            {
                string sql = "SELECT t.träningsgruppsid, t.namn, t.termin, m.förnamn, m.efternamn FROM träningsgrupper t, medlem m, ansvar a WHERE m.medlemsid = a.medlemsid AND t.träningsgruppsid = a.träningsgruppsid ORDER BY m.förnamn";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                träningsgrupper tr;
                while (dr.Read())
                {
                    tr = new träningsgrupper()
                    {
                        träningsgruppsid = (int)dr["träningsgruppsid"],
                        namn = dr["namn"].ToString(),
                        termin = dr["termin"].ToString(),
                        förnamn = dr["förnamn"].ToString(),
                        efternamn = dr["efternamn"].ToString(),


                    };
                    träningsgruppslista.Add(tr);

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
        public void VisaSelectedTräningsgruppLedare(int medlemsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            träningsgruppslista.Clear();

            try
            {
                string sql = "SELECT * FROM träningsgrupper t, ansvar a WHERE t.träningsgruppsid = a.träningsgruppsid AND a.medlemsid = '" + medlemsid + "'";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                träningsgrupper tr;
                while (dr.Read())
                {
                    tr = new träningsgrupper()
                    {
                        träningsgruppsid = (int)dr["träningsgruppsid"],
                        namn = dr["namn"].ToString(),
                        termin = dr["termin"].ToString(),
                        
                    };
                    träningsgruppslista.Add(tr);

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
        public void VisaSelectedTräningsgruppMedlem(int medlemsid)
        {
            NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

            träningsgruppslista.Clear();

            try
            {
                string sql = "SELECT * FROM träningsgrupper t, tillhör ti WHERE t.träningsgruppsid = ti.träningsgruppsid AND ti.medlemsid = '" + medlemsid + "'";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                träningsgrupper tr;
                while (dr.Read())
                {
                    tr = new träningsgrupper()
                    {
                        träningsgruppsid = (int)dr["träningsgruppsid"],
                        namn = dr["namn"].ToString(),
                        termin = dr["termin"].ToString(),

                    };
                    träningsgruppslista.Add(tr);

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
        //public void VisaSelectedTräningsgruppAktivitet(int träningsgruppsid)
        //{
        //    NpgsqlConnection connect = new NpgsqlConnection(connectSQLadress);

        //    träningsgruppslista.Clear();

        //    try
        //    {
        //        string sql = "SELECT * FROM aktivitet a, träningsgrupper t WHERE t.träningsgruppsid = a.träningsgruppsid AND t.träningsgruppsid = '" + träningsgruppsid + "'";
        //        connect.Open();
        //        NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
        //        NpgsqlDataReader dr = cmd.ExecuteReader();

        //        träningsgrupper tr;
        //        while (dr.Read())
        //        {
        //            tr = new träningsgrupper()
        //            {
        //                aktivitetsid = (int)dr["aktivitetsid"],
        //                träningsgruppsnamn = dr["namn"].ToString(),
        //                beskrivning = dr["beskrivning"].ToString(),
        //                datum = dr["datum"].ToString(),
        //                klockslag = dr["klockslag"].ToString(),
        //                plats = dr["plats"].ToString()

        //            };
        //            träningsgruppslista.Add(tr);

        //        }
        //    }
        //    catch (NpgsqlException ex)
        //    {
        //        if (ex.Code.Equals("28P01"))
        //        {
        //            MessageBox.Show("Fel lösenord.");
        //        }
        //        if (ex.Code.Equals("42501"))
        //        {
        //            MessageBox.Show("Användaren saknar nödvändiga rättigheter.");
        //        }
        //        else
        //        {
        //            MessageBox.Show(ex.Code);
        //        }
        //        // MessageBox.Show(ex.Message);

        //    }
        //    finally
        //    {

        //        connect.Close();

        //    }
        //}
    }
}

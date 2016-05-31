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
        public string förnamn { get; set; }
        public string efternamn { get; set; }

        public string TräningsgruppsDisplay
        {
            get
            {
                return träningsgruppsid + " - " + namn + " \t\t " + termin + " \t " + förnamn + " " + efternamn;
            }
        }
        public BindingList<träningsgrupper> träningsgruppslista = new BindingList<träningsgrupper>();

        public void VisaTräningsgrupper()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5432;User Id=administratör;Password=1234;Database=cirkus;");

            träningsgruppslista.Clear();

            try
            {
                string sql = "SELECT t.träningsgruppsid, t.namn, t.termin, m.förnamn, m.efternamn FROM träningsgrupper t, medlem m, ansvar a WHERE m.medlemsid = a.medlemsid AND t.träningsgruppsid = a.träningsgruppsid";
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
    }
}

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


        public string aktivitetDisplay
        {
            get
            {
                return aktivitetsid + " - " + träningsgruppsid;
            }

        }

        public BindingList<aktivitet> aktivitetslista = new BindingList<aktivitet>();

        public void VisaAktivitet()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Server=localhost;Port=5433;User Id=administratör;Password=1234;Database=uppgift8_cirkus;");

            aktivitetslista.Clear();

            try
            {
                string sql = "SELECT a.aktivitetsid, a.träningsgruppsid FROM aktivitet a";
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                aktivitet akt;
                while (dr.Read())
                {
                    akt = new aktivitet()
                    {
                        aktivitetsid = (int)dr["aktivitetsid"],
                        träningsgruppsid = (int)dr["träningsgruppsid"]

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

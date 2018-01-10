using POP_SF49_16GUI.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF49_16GUI.Baza
{
    class KorisnikBaza
    {
        public static void popunjavanjeKorisnika()
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                // otvara konekciju i pravi dataset objekat koji je kao kes memorija ucitane baze(zbog lakseg manipulisanja podacima)
                connection.Open();
                DataSet dataset = new DataSet();

                // pravim komandu koji cu koristiti
                SqlCommand komanda = connection.CreateCommand();
                komanda.CommandText = @"SELECT * FROM Korisnici";

                // pravim adapter objekat koji sluzi da popunim dataset sa komandom(iznad) 
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                adapter.Fill(dataset, "Korisnici");

                foreach (DataRow red in dataset.Tables["Korisnici"].Rows)
                {
                    Korisnik k = new Korisnik();
                    k.Ime = (string)red["Ime"];
                    k.Prezime = (string)red["Prezime"];
                    k.Username = (string)red["KorisnickoIme"];
                    k.Password = (string)red["Lozinka"];
                    k.Obrisan = (bool)red["Obrisan"];
                    bool Tip = (bool)red["TipKorisnika"];
                    k.Tip_Korisnika = vratiTipKorisnika(Tip);

                    RadSaPodacima.Instance.Korisnici.Add(k);
                }
            }
        }

        public static string vratiTipKorisnika(bool tip)
        {
            if (tip == false)
            {
                return "admin";
            }
            else
            {
                return "korisnik";
            }

        }
    }
}

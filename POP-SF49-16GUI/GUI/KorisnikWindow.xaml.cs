using POP_SF49_16GUI.model;
using POP_SF49_16GUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POP_SF49_16GUI.GUI
{
    /// <summary>
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        int kbroj = 0;
        private Korisnik izabrani;
        public KorisnikWindow(int broj, Korisnik objekat)
        {
            InitializeComponent();
            izabrani = objekat;
            kbroj = broj;
            TipoviKorisnika();
            tbIme.DataContext = izabrani;
            tbPrezime.DataContext = izabrani;
            tbUsername.DataContext = izabrani;
            tbPassword.DataContext = izabrani;
            cbTip.DataContext = izabrani;
        }
        private void TipoviKorisnika()
        {
            cbTip.Items.Add("korisnik");
            cbTip.Items.Add("admin");
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            var izabrani_tip_korisnika = "" + cbTip.SelectedItem;
            var lista = RadSaPodacima.Instance.Korisnici;
            var msg_greska = false;
            var msg_prazno = false;
            string poruka = " Niste uneli polje: ";
            string greska = "Username koji ste izabrali je zauzet: ";


            if (tbIme.Text == "")
            {
                msg_prazno = true;
                poruka += " Ime ";
            }

            if (tbPrezime.Text == "")
            {
                msg_prazno = true;
                poruka += " Prezime ";

            }

            if (tbUsername.Text == "")
            {
                msg_prazno = true;
                poruka += " Username ";

            }
            if (kbroj == 1)
            {
                foreach (Korisnik k in lista)
                {
                    if (k.Username.Equals(tbUsername.Text))
                    {
                        msg_greska = true;
                    }
                }

            }

            if (tbPassword.Text == "")
            {
                msg_prazno = true;
                poruka += " Password ";

            }
            if (cbTip.SelectedItem == null)
            {
                msg_prazno = true;
                poruka += " Tip ";

            }
            if (msg_prazno == true || msg_greska == true)
            {
                MessageBox.Show(poruka, greska);
            }
            else if (msg_greska == false && msg_prazno == false)
            {
                if (kbroj == 1)
                {
                    izabrani.Password = Hash(tbPassword.Text);
                    lista.Add(izabrani);
                    GenericSerialize.Serialize("Korisnici.xml", lista);
                    this.Close();

                }
                else if (kbroj == 2)
                {
                    foreach (Korisnik n in lista)
                    {
                        if (n.Username == izabrani.Username)
                        {
                            n.Ime = izabrani.Ime;
                            n.Prezime = izabrani.Prezime;
                            n.Username = izabrani.Username;
                            n.Password = Hash(tbPassword.Text);
                            n.Tip_Korisnika = izabrani.Tip_Korisnika;



                        }
                    }
                    GenericSerialize.Serialize("Korisnici.xml", lista);
                    this.Close();

                }

            }

        }
        private string Hash(string passw)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(passw));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

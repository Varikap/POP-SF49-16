using POP_SF49_16GUI.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    public partial class UserWindow : Window 
    {
        private ProdajaNamestaja izabrani;
        private Korisnik ulogovan;
        private ICollectionView view;

        public UserWindow (Korisnik ulog)
        {
            ulogovan = ulog;
            InitializeComponent();
            tbKolicina.DataContext = izabrani;
            refresh();

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var listaProdaja = RadSaPodacima.Instance.ProdajaNamestaja;
            var listaNamestaja = RadSaPodacima.Instance.Namestaj;
            Namestaj n = (Namestaj)dgPrikaz.SelectedItem;
            var msg_prazno = false;
            var msg_greska = false;
            string poruka = " Niste uneli polje: ";
            string greska = "Pogresno ste uneli polje: ";
            int parsedTest;
            if (tbKolicina.Text == "")
            {
                msg_prazno = true;
                poruka += " Kolicina ";
            }
            if (dgPrikaz.SelectedItem == null)
            {
                msg_prazno = true;
                poruka += "Namestaj";
            }
            if (!int.TryParse(tbKolicina.Text, out parsedTest))
            {
                msg_greska = true;
                greska += " Kolicina ";


            }
            else
            {
                if (n.Kolicina < int.Parse(tbKolicina.Text))
                {
                    msg_greska = true;
                    greska += " Kolicina ";

                }
            }
            if (msg_prazno == true || msg_greska == true)
            {
                MessageBox.Show(poruka, greska);
            }
            else if (msg_greska == false && msg_prazno == false)
            {
                ProdajaNamestaja p = new ProdajaNamestaja();
                
                p.Broj_Racuna = listaProdaja.Count + 1;
                p.Datum_Prodaje = DateTime.Now;
                p.NamestajId = n.Id;
                p.Obrisan = false;
                p.Kupac = ulogovan.Ime;
                p.Broj_Komada_Namestaja = int.Parse(tbKolicina.Text);
                n.Kolicina -= p.Broj_Komada_Namestaja;
                Baza.ProdajaNamestajaBaza.ProdajaDodaj(p);
                Baza.NamestajBaza.NamestajIzmeni(n);
                RadSaPodacima.Instance.ProdajaNamestaja.Add(p);
                MessageBox.Show("Uspesno izvrsena prodaja");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void refresh()
        {
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Namestaj);
            view.Filter = PrikazNeobrisanogNamestaja;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.AutoGeneratingColumn += prikaz3;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        private void prikaz3(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "AkcijskaCenaId" || e.Column.ToString() == "NaStanju" || e.Column.Header.ToString() == "Password" || e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "NaStanju" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;

            }
        }
        private bool PrikazNeobrisanogNamestaja(object obj)
        {
            return ((Namestaj)obj).NaStanju == false;
        }
    }
}

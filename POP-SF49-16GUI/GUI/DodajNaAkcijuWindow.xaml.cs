using POP_SF49_16GUI.model;
using POP_SF49_16GUI.Utils;
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
    public partial class DodajNaAkcijuWindow : Window
    {
        string operacija;
        private ICollectionView viewSaAkcijom;
        private ICollectionView viewBezAkcije;
        public DodajNaAkcijuWindow()
        {
            InitializeComponent();
            viewBezAkcije = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Namestaj);
            viewSaAkcijom = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Namestaj);
            viewBezAkcije.Filter = PrikazNamestajaBezAkcije;
            viewSaAkcijom.Filter = PrikazNamestajaSaAkcijom;
            cbNamestaj.ItemsSource = viewBezAkcije;
            cbUklonjenNamestaj.ItemsSource = viewSaAkcijom;
            cbAkcija.ItemsSource = RadSaPodacima.Instance.Akcije;

        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var listaNam = RadSaPodacima.Instance.Namestaj;
            var msg_prazno = false;
            string poruka = " Niste odabrali polje: ";
            if (cbAkcija.SelectedItem == null)
            {
                msg_prazno = true;
                poruka += " Akcija";

            }
            else if (cbNamestaj.SelectedItem == null)
            {
                msg_prazno = true;
                poruka += " namestaj";

            }
            else if (cbUklonjenNamestaj.SelectedItem == null)
            {
                msg_prazno = true;
                poruka += "Namestaj";

            }
            if (msg_prazno == true)
            {
                MessageBox.Show(poruka);
            }
            else
            {
                if (operacija.Equals("dodavanje"))
                {
                    foreach (Namestaj n in listaNam)
                    {
                        if (n == cbNamestaj.SelectedItem)
                        {
                            Akcija kcija = (Akcija)cbAkcija.SelectedItem;
                            n.AkcijskaCena = kcija;
                            Baza.NamestajBaza.NamestajIzmeni(n);
                            this.Close();
                            break;
                        }
                    }
                    GenericSerialize.Serialize("listaNam.xml", listaNam);
                }
                else if (operacija.Equals("uklanjanje"))
                {
                    foreach (Namestaj n in listaNam)
                    {
                        if (n == cbUklonjenNamestaj.SelectedItem)
                        {
                            n.AkcijskaCena = null;
                            Baza.NamestajBaza.NamestajIzmeni(n);
                            this.Close();
                            break;
                        }
                    }
                    GenericSerialize.Serialize("listaNam.xml", listaNam);
                } 
            }
            this.Close();
        }

        private void btnDodavanje_Click(object sender, RoutedEventArgs e)
        {
            operacija = "dodavanje";
            cbUklonjenNamestaj.IsEnabled = false;
            cbUklonjenNamestaj.Background = new SolidColorBrush(Colors.LightGray);
            cbNamestaj.IsEnabled = true;
            cbNamestaj.Background = new SolidColorBrush(Colors.White);
            cbAkcija.IsEnabled = true;
            cbAkcija.Background = new SolidColorBrush(Colors.White);
            btnUkloni.Background = new SolidColorBrush(Colors.LightGray);
            btnDodavanje.Background = new SolidColorBrush(Colors.Gray);
        }

        private void btnUkloni_Click(object sender, RoutedEventArgs e)
        {
            operacija = "uklanjanje";
            cbUklonjenNamestaj.IsEnabled = true;
            cbUklonjenNamestaj.Background = new SolidColorBrush(Colors.LightGray);
            cbNamestaj.IsEnabled = false;
            cbNamestaj.Background = new SolidColorBrush(Colors.White);
            cbAkcija.IsEnabled = false;
            cbAkcija.Background = new SolidColorBrush(Colors.White);
            btnUkloni.Background = new SolidColorBrush(Colors.Gray);
            btnDodavanje.Background = new SolidColorBrush(Colors.LightGray);
        }

        private bool PrikazNamestajaSaAkcijom(object obj)
        {
            return ((Namestaj)obj).NaStanju == true;
        }
        private bool PrikazNamestajaBezAkcije(object obj)
        {
            return ((Namestaj)obj).NaStanju == true;
        }
    }
}

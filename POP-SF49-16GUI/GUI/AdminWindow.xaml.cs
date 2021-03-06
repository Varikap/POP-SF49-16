﻿using POP_SF49_16GUI.model;
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
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private ICollectionView view;

        public Korisnik IzabraniKorisnik { get; set; }

        public Korisnik Korisnik { get; set; }

        public Namestaj IzabraniNamestaj { get; set; }

        public Namestaj Namestaj { get; set; }

        public TipNamestaja IzabraniTipNamestaja { get; set; }

        public TipNamestaja TipNamestaja { get; set; }

        public Akcija IzabranaAkcija { get; set; }

        public Object Objekat { get; set; }

        public DodatnaUsluga IzabranaUsluga;

        public string operacija = "";
        public AdminWindow()
        {
            InitializeComponent();
            //proveraAkcija();
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            if (operacija.Equals(""))
            {
                MessageBox.Show("Niste izabrali pregled ni jednog tipa!");
            }
            else
            {
                if (operacija.Equals("korisnik"))
                {
                    var zaDodati = new Korisnik
                    {
                        Ime = ""
                    };
                    var window = new KorisnikWindow(1, zaDodati);
                    window.ShowDialog();
                    RadSaPodacima.Instance.Korisnici.Clear();
                    Baza.KorisnikBaza.popunjavanjeKorisnika();
                    view.Refresh();
                }
                else if (operacija.Equals("namestaj"))
                {
                    var zaDodati = new Namestaj()
                    {
                        Naziv = ""

                    };
                    var window = new NamestajWindow(1, zaDodati);
                    window.ShowDialog();
                    RadSaPodacima.Instance.Namestaj.Clear();
                    Baza.NamestajBaza.popunjavanjeNamestaja();
                    view.Refresh();
                }
                else if (operacija.Equals("tipNamestaja"))
                {
                    var zaDodati = new TipNamestaja()
                    {
                        Naziv = ""
                    };
                    var window = new TipNamestajaWindow(1, zaDodati);
                    window.ShowDialog();
                    RadSaPodacima.Instance.TipoviNamestaja.Clear();
                    Baza.TipNamestajaBaza.popunjavanjeTipaNamestaja();
                    view.Refresh();
                }
                else if(operacija.Equals("akcija"))
                {
                    var zaDodati = new Akcija()
                    {
                        Popust = 0,
                        Datum_Pocetka = DateTime.Now,
                        Datum_Zavrsetka = DateTime.Now
                    };
                    var window = new AkcijeWindow(1, zaDodati);
                    window.ShowDialog();
                    RadSaPodacima.Instance.Akcije.Clear();
                    Baza.AkcijaBaza.popunjavanjeAkcija();
                    view.Refresh();
                }
                else if (operacija.Equals("dodatneUsluge"))
                {
                    var zaDodati = new DodatnaUsluga
                    {
                        Naziv = ""
                    };
                    var window = new DodatnaUslugaWindow(1, zaDodati);
                    window.ShowDialog();
                    RadSaPodacima.Instance.DodatnaUsluga.Clear();
                    Baza.DodatnaUslugaBaza.popunjavanjeDodatneUsluge();
                    view.Refresh();
                }
                view.Refresh();
            }

        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (operacija.Equals(""))
            {
                MessageBox.Show("Niste izabrali pregled ni jednog tipa!");
            }
            if (operacija.Equals("korisnik"))
            {
                if (dgPrikaz.SelectedItem != null)
                {
                    Korisnik = (Korisnik)Objekat;
                    var zaIzmenu = (Korisnik)Korisnik.Clone();
                    var window = new KorisnikWindow(2, zaIzmenu);
                    window.ShowDialog();
                    RadSaPodacima.Instance.Korisnici.Clear();
                    Baza.KorisnikBaza.popunjavanjeKorisnika();
                    view.Refresh();

                }
                else
                {
                    MessageBox.Show(" Morate izabrati korisnika za izmenu!! ");
                }
            }
            else if (operacija.Equals("namestaj"))
            {
                if (dgPrikaz.SelectedItem != null)
                {
                    Namestaj = (Namestaj)Objekat;
                    var prosledjenNamestaj = (Namestaj)Namestaj.Clone();
                    var window = new NamestajWindow(2, prosledjenNamestaj);
                    window.ShowDialog();
                    RadSaPodacima.Instance.Namestaj.Clear();
                    Baza.NamestajBaza.popunjavanjeNamestaja();
                    view.Refresh();
                }
                else
                {
                    MessageBox.Show(" Morate izabrati objekat za izmenu!! ");
                }
            }
            else if (operacija.Equals("tipNamestaja"))
            {
                if (dgPrikaz.SelectedItem != null)
                {
                    TipNamestaja prosledjenTip = (TipNamestaja)Objekat;
                    TipNamestaja zaIzmenu = (TipNamestaja)prosledjenTip.Clone();
                    var window = new TipNamestajaWindow(2, zaIzmenu);
                    window.ShowDialog();
                    RadSaPodacima.Instance.TipoviNamestaja.Clear();
                    Baza.TipNamestajaBaza.popunjavanjeTipaNamestaja();
                    view.Refresh();
                }
                else
                {
                    MessageBox.Show(" Morate izabrati objekat za izmenu!! ");
                }
            }
            else if (operacija.Equals("akcija"))
            {
                if (dgPrikaz.SelectedItem != null)
                {
                    Akcija prosledjenaAkcija = (Akcija)Objekat;
                    Akcija zaIzmenu = (Akcija)prosledjenaAkcija.Clone();
                    var window = new AkcijeWindow(2, zaIzmenu);
                    window.ShowDialog();
                    RadSaPodacima.Instance.Akcije.Clear();
                    Baza.AkcijaBaza.popunjavanjeAkcija();
                    view.Refresh();
                }
                else
                {
                    MessageBox.Show(" Morate izabrati objekat za izmenu!! ");
                }
            }
            else if (operacija.Equals("dodatneUsluge"))
            {
                if (dgPrikaz.SelectedItem != null)
                {
                    DodatnaUsluga prosledjenaUsluga = (DodatnaUsluga)Objekat;
                    DodatnaUsluga zaIzmenu = (DodatnaUsluga)prosledjenaUsluga.Clone();
                    var window = new DodatnaUslugaWindow(2, zaIzmenu);
                    window.ShowDialog();
                    RadSaPodacima.Instance.DodatnaUsluga.Clear();
                    Baza.DodatnaUslugaBaza.popunjavanjeDodatneUsluge();
                    view.Refresh();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (operacija.Equals(""))
            {
                MessageBox.Show("Niste izabrali pregled ni jednog tipa!");
            }
            else
            {
                if (operacija.Equals("korisnik"))
                {
                    var lista_korisnika = RadSaPodacima.Instance.Korisnici;
                    var Korisnik = (Korisnik)Objekat;
                    var ob = (Korisnik)Korisnik.Clone();
                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati korisnika za brisanje!! ");
                    }
                    if (ob != null)
                    {
                        Baza.KorisnikBaza.korisnikIzbrisi(ob);
                        RadSaPodacima.Instance.Korisnici.Remove(ob);
                        RadSaPodacima.Instance.Korisnici.Clear();
                        Baza.KorisnikBaza.popunjavanjeKorisnika();
                        view.Refresh();
                    }
                }
                else if (operacija.Equals("namestaj"))
                {
                    var lista_namestaja = RadSaPodacima.Instance.Namestaj;
                    Namestaj = (Namestaj)Objekat;
                    var ob = (Namestaj)Namestaj.Clone();

                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati objekat za brisanje!! ");
                    }
                    else if (ob != null)
                    {
                        Baza.NamestajBaza.NamestajIzbrisi(ob);
                        RadSaPodacima.Instance.Namestaj.Remove(ob);
                        RadSaPodacima.Instance.Namestaj.Clear();
                        Baza.NamestajBaza.popunjavanjeNamestaja();
                        view.Refresh();

                    }
                }
                else if (operacija.Equals("akcija"))
                {
                    var lista_akcija = RadSaPodacima.Instance.Akcije;
                    var ob = (Akcija)Objekat;
                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati objekat za brisanje!! ");
                    }
                    else if (ob != null)
                    {
                        Baza.AkcijaBaza.AkcijaIzbrisi(ob);
                        RadSaPodacima.Instance.Akcije.Remove(ob);
                        RadSaPodacima.Instance.Akcije.Clear();
                        Baza.AkcijaBaza.popunjavanjeAkcija();
                        view.Refresh();

                    }
                }
                else if (operacija.Equals("tipNamestaja"))
                {
                    var lista_tipova = RadSaPodacima.Instance.TipoviNamestaja;
                    var lista_namestaja = RadSaPodacima.Instance.Namestaj;
                    var ob = (TipNamestaja)Objekat;
                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati objekat za brisanje!! ");
                    }
                    else if (ob != null)
                    {

                        Baza.TipNamestajaBaza.TipNamestajaIzbrisi(ob);
                        RadSaPodacima.Instance.TipoviNamestaja.Remove(ob);
                        Baza.NamestajBaza.NamestajIzbrisiByTip(ob);
                        RadSaPodacima.Instance.TipoviNamestaja.Clear();
                        Baza.TipNamestajaBaza.popunjavanjeTipaNamestaja();
                        RadSaPodacima.Instance.Namestaj.Clear();
                        Baza.NamestajBaza.popunjavanjeNamestaja();
                        view.Refresh();
                    }
                }

                else if (operacija.Equals("dodatneUsluge"))
                {
                    var listaUsluga = RadSaPodacima.Instance.DodatnaUsluga;
                    var ob = (DodatnaUsluga)Objekat;
                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati objekat za brisanje!! ");
                    }
                    else if(ob != null)
                    {
                        Baza.DodatnaUslugaBaza.DodatnaUslugaIzbrisi(ob);
                        RadSaPodacima.Instance.DodatnaUsluga.Remove(ob);
                        RadSaPodacima.Instance.DodatnaUsluga.Clear();
                        Baza.DodatnaUslugaBaza.popunjavanjeDodatneUsluge();
                        view.Refresh();
                    }

                }

            }
        }

        private void namestaji_Click(object sender, RoutedEventArgs e)
        {
            operacija = "namestaj";
            btnDodajAkciju.Visibility = Visibility.Hidden;
            Objekat = null;
            Objekat = IzabraniNamestaj;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Namestaj);
            view.Filter = PrikazNeobrisanogNamestaja;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.AutoGeneratingColumn += prikaz3;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private void korisnici_Click(object sender, RoutedEventArgs e)
        {
            operacija = "korisnik";
            btnDodajAkciju.Visibility = Visibility.Hidden;
            Objekat = null;
            Objekat = IzabraniKorisnik;
            dgPrikaz.ItemsSource = null;
            view = null;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Korisnici);
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.DataContext = this;
            dgPrikaz.ItemsSource = RadSaPodacima.Instance.Korisnici;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void akcije_Click(object sender, RoutedEventArgs e)
        {
            operacija = "akcija";
            btnDodajAkciju.Visibility = Visibility.Visible;
            Objekat = null;
            Objekat = IzabranaAkcija;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Akcije);
            dgPrikaz.ItemsSource = null;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void tipoviNamestaja_Click(object sender, RoutedEventArgs e)
        {
            operacija = "tipNamestaja";
            btnDodajAkciju.Visibility = Visibility.Hidden;
            Objekat = null;
            Objekat = IzabraniTipNamestaja;
            dgPrikaz.ItemsSource = null;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.TipoviNamestaja);
            view.Filter = PrikazNeobrisanogTipaNamestaja;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dodatneUslge_Click(object sender, RoutedEventArgs e)
        {
            operacija = "dodatneUsluge";
            btnDodajAkciju.Visibility = Visibility.Hidden;
            Objekat = null;
            Objekat = IzabranaUsluga;
            dgPrikaz.ItemsSource = null;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.DodatnaUsluga);
            view.Filter = PrikazNeobrisaneDodatneUsluge;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool PrikazNeobrisanogNamestaja(object obj)
        {
            return ((Namestaj)obj).NaStanju == false;
        }
        private bool PrikazNeobrisanogTipaNamestaja(object obj)
        {
            return ((TipNamestaja)obj).Obrisan == false;
        }

        private bool PrikazNeobrisaneDodatneUsluge(object obj)
        {
            return ((DodatnaUsluga)obj).Obrisan == false;
        }

        private void prikaz3(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "AkcijskaCenaId" || e.Column.ToString() == "NaStanju" || e.Column.Header.ToString() == "Password" || e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "NaStanju" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;

            }
        }

        private void btnDodajAkciju_Click(object sender, RoutedEventArgs e)
        {
            var Window = new DodajNaAkcijuWindow();
            Window.ShowDialog();
        }

        private void proveraAkcija ()
        {
            var listaAkcija = RadSaPodacima.Instance.Akcije;
            var listaNamestaja = RadSaPodacima.Instance.Namestaj;
            foreach (Akcija a in listaAkcija)
            {
                if (a.Datum_Zavrsetka < DateTime.Now)
                {
                    listaAkcija.Remove(a);
                    foreach (Namestaj n in listaNamestaja)
                    {
                        if (n.AkcijskaCena == a)
                        {
                            n.AkcijskaCena = null;
                        }
                    }
                }
            }
            GenericSerialize.Serialize("listaNam.xml", listaNamestaja);
            GenericSerialize.Serialize("Akcije.xml", listaAkcija);
        }

       
    }
}

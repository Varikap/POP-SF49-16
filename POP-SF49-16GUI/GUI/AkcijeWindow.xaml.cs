using POP_SF49_16GUI.model;
using POP_SF49_16GUI.Utils;
using System;
using System.Collections.Generic;
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
    public partial class AkcijeWindow : Window
    {
        private Akcija odabrana;
        int pbroj = 0;
        public AkcijeWindow(int broj, Akcija objekat)
        {
            InitializeComponent();
            pbroj = broj;
            odabrana = objekat;
            tbNaziv.DataContext = odabrana;
            dpKraj.DataContext = odabrana;
            dpPocetak.DataContext = odabrana;
            tbPopust.DataContext = odabrana;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var lista = RadSaPodacima.Instance.Akcije;
            var msg_prazno = false;
            var msg_pogresno = false;
            string poruka = "Niste uneli polje";
            string pogresno = "Pocetak akcije ne moze biti veci od kraja";
            int temp;
            if (tbNaziv.Text =="")
            {
                msg_prazno = true;
                poruka += "naziv";
            }
            if (dpKraj.Text == "")
            {
                msg_prazno = true;
                poruka += "datum zavrsetka";
            }
            if (dpPocetak.Text == "")
            {
                msg_prazno = true;
                poruka += "datum pocetka";
            }
            if (!int.TryParse(tbPopust.Text, out temp))
            {
                msg_prazno = true;
                poruka += "popust";
            }
            if (odabrana.Datum_Pocetka > odabrana.Datum_Zavrsetka)
            {
                msg_pogresno = true;
                
            }
            if (msg_prazno == true)
            {
                MessageBox.Show(poruka);
            }
            if (msg_pogresno == true || msg_prazno == false)
            {
                MessageBox.Show(pogresno,poruka);
            }
            else if (msg_pogresno == false && msg_pogresno == false)
            {
                if (pbroj == 1)
                {
                    odabrana.Id = lista.Count + 1;
                    lista.Add(odabrana);
                    GenericSerialize.Serialize("Akcije.xml", lista);
                    this.Close();
                }
                else if (pbroj == 2)
                {
                    foreach (Akcija a in lista)
                    {
                        if (a.Id == odabrana.Id)
                        {
                            a.Naziv = odabrana.Naziv;
                            a.Datum_Pocetka = odabrana.Datum_Pocetka;
                            a.Datum_Zavrsetka = odabrana.Datum_Zavrsetka;
                            a.Popust = odabrana.Popust;
                            GenericSerialize.Serialize("Akcije.xml", lista);
                            this.Close();
                            break;
                        }
                    }
                }
            }
           
        }
    }
}

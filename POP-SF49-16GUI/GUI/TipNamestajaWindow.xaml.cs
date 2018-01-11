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
    /// <summary>
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        int kbroj = 0;
        private TipNamestaja izabrani;
        public TipNamestajaWindow(int broj, TipNamestaja objekat)
        {
            InitializeComponent();
            izabrani = objekat;
            kbroj = broj;
            tbNaziv.DataContext = izabrani;
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var lista = RadSaPodacima.Instance.TipoviNamestaja;
            var msg_prazno = false;
            string poruka = " Niste uneli polje: ";

            if (tbNaziv.Text == "")
            {
                msg_prazno = true;
                poruka += " Naziv ";
            }

            if (msg_prazno == true)
            {
                MessageBox.Show(poruka);
            }
            else if (msg_prazno == false)
            {
                if (kbroj == 1)
                {
                    izabrani.Id = lista.Count + 1;
                    Baza.TipNamestajaBaza.TipNamestajaDodaj(izabrani);
                    RadSaPodacima.Instance.TipoviNamestaja.Add(izabrani);
                    this.Close();

                }
                else if (kbroj == 2)
                {
                    foreach (TipNamestaja n in lista)
                    {
                        if (n.Id == izabrani.Id)
                        {
                            n.Naziv = izabrani.Naziv;




                        }
                    }
                    Baza.TipNamestajaBaza.TipNamestajaIzmeni(izabrani);
                    this.Close();

                }

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

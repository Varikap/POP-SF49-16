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
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        private DodatnaUsluga usluga;
        int kbroj = 0;
        public DodatnaUslugaWindow(int broj, DodatnaUsluga objekat)
        {
            InitializeComponent();
            usluga = objekat;
            kbroj = broj;
            tbCena.DataContext = usluga;
            tbNaziv.DataContext = usluga;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var listaUsluga = RadSaPodacima.Instance.DodatneUsluge;

            if (kbroj == 1)
            {
                usluga.Id = listaUsluga.Count + 1;
                listaUsluga.Add(usluga);
                GenericSerialize.Serialize("DodatneUsluge.xml", listaUsluga);
                this.Close();
            }
            else if (kbroj == 2)
            {
                foreach (DodatnaUsluga d in listaUsluga)
                {
                    if (d.Id == usluga.Id)
                    {
                        d.Naziv = usluga.Naziv;
                        d.Cena = usluga.Cena;
                        GenericSerialize.Serialize("DodatneUsluge.xml", listaUsluga);
                        this.Close();
                    }
                }
            }
        }
    }
}

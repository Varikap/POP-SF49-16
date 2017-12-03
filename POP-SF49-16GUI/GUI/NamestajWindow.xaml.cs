﻿using POP_SF49_16GUI.model;
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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        private Namestaj odabrani;
        int pbroj = 0;

        public NamestajWindow(int broj, Namestaj izabrani)
        {
            InitializeComponent();
            this.odabrani = izabrani;


            pbroj = broj;


            cbTip.ItemsSource = RadSaPodacima.Instance.TipoviNamestaja;
            tbCena.DataContext = odabrani;
            tbKolicina.DataContext = odabrani;
            tbNaziv.DataContext = odabrani;
            cbTip.DataContext = odabrani;
            if (pbroj==2)
            {
                foreach (TipNamestaja t in cbTip.Items)
                {
                    if (odabrani.TipNamestaja.ToString().Equals(t.Naziv))
                    {
                        cbTip.SelectedValue = t;
                    }
                } 
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            var izabrani_tip_namestaja = (TipNamestaja)cbTip.SelectedItem;
            var lista = RadSaPodacima.Instance.Namestaj;
            var msg_greska = false;
            var msg_prazno = false;
            string poruka = " Niste uneli polje: ";
            string greska = "Pogresno ste uneli polje: ";
            int parsedTest;

            if (tbCena.Text == "")
            {
                msg_prazno = true;
                poruka += " Cena ";
            }
            if (!int.TryParse(tbCena.Text, out parsedTest))
            {
                msg_greska = true;
                greska += " Cena ";


            }
            if (tbKolicina.Text == "")
            {
                msg_prazno = true;
                poruka += " Kolicina ";

            }
            if (!int.TryParse(tbKolicina.Text, out parsedTest))
            {
                msg_greska = true;
                greska += " Kolicina ";

            }
            if (tbNaziv.Text == "")
            {
                msg_prazno = true;
                poruka += " Naziv ";

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
                if (pbroj == 1)
                {
                    odabrani.Id = lista.Count + 1;

                    lista.Add(odabrani);
                    GenericSerialize.Serialize("listaNam.xml", lista);
                    this.Close();

                }
                else if (pbroj == 2)
                {
                    foreach (Namestaj n in lista)
                    {
                        if (n.Id == odabrani.Id)
                        {
                            n.Kolicina = odabrani.Kolicina;
                            n.Cena = odabrani.Cena;
                            n.Naziv = odabrani.Naziv;
                            n.TipNamestaja = odabrani.TipNamestaja;



                        }
                    }
                    GenericSerialize.Serialize("listaNam.xml", lista);
                    this.Close();

                }

            }

        }
    }
}

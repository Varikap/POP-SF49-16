using POP_SF49_16GUI.model;
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
    /// Interaction logic for DodajNaAkcijuWindow.xaml
    /// </summary>
    public partial class DodajNaAkcijuWindow : Window
    {
        public DodajNaAkcijuWindow()
        {
            InitializeComponent();
            cbNamestaj.ItemsSource = RadSaPodacima.Instance.Namestaj;
            cbAkcija.ItemsSource = RadSaPodacima.Instance.Akcije;
            cbUklonjenNamestaj.ItemsSource = RadSaPodacima.Instance.Namestaj;

        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDodavanje_Click(object sender, RoutedEventArgs e)
        {
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
            cbUklonjenNamestaj.IsEnabled = true;
            cbUklonjenNamestaj.Background = new SolidColorBrush(Colors.LightGray);
            cbNamestaj.IsEnabled = false;
            cbNamestaj.Background = new SolidColorBrush(Colors.White);
            cbAkcija.IsEnabled = false;
            cbAkcija.Background = new SolidColorBrush(Colors.White);
            btnUkloni.Background = new SolidColorBrush(Colors.Gray);
            btnDodavanje.Background = new SolidColorBrush(Colors.LightGray);
        }
    }
}

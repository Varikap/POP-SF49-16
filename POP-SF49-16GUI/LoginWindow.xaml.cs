using POP_SF49_16GUI.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace POP_SF49_16GUI
{

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            int br = 0;
            try
            {
                var korisnici = RadSaPodacima.Instance.Korisnici;
                foreach (var korisnik in korisnici)
                {
                    if (tbUserName.Text.Equals(korisnik.Username))
                    {
                        string password = Hash(tbPassword.Password);
                        if (password.Equals(korisnik.Password))
                        {
                            br += 1;
                            if (korisnik.Tip_Korisnika.Equals("admin"))
                            {
                                var prozor = new GUI.AdminWindow();
                                this.Hide();
                                prozor.ShowDialog();
                                break;
                            }
                            else
                            {
                                var prozor = new GUI.AdminWindow();
                                this.Hide();
                                prozor.ShowDialog();
                                break;
                            } 
                        }
                    }
                }
                if (br == 0)
                {
                    MessageBox.Show("Neispravno Korisnicko ime ili Lozinka");
                }
                this.Show();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private string Hash(string passw)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(passw));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
    }
}

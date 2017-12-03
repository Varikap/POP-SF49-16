﻿using POP_SF49_16GUI.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                    if (tbUserName.Text.Equals(korisnik.Username) && tbPassword.Password.Equals(korisnik.Password))
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

            /*
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-3TN1TDU; Inital Catalog=LoginSalon; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                string query = "SELECT COUNT(1) FROM LoginSalon WHERE username=@username AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@username", tbUserName.Text);
                sqlCmd.Parameters.AddWithValue("@password", tbPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count==1)
                {
                    var prozor = new GUI.NamestajWindow();
                    prozor.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Korisnicko ime ili lozinka su neispravni!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
            */
        }
    }
}
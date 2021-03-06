﻿using POP_SF49_16GUI.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF49_16GUI.Baza
{
    class TipNamestajaBaza
    {
        public static void popunjavanjeTipaNamestaja()
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {

                connection.Open();
                DataSet dataset = new DataSet();


                SqlCommand komanda = connection.CreateCommand();
                komanda.CommandText = @"SELECT * FROM TipoviNamestaja";


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                adapter.Fill(dataset, "TipoviNamestaja");

                foreach (DataRow red in dataset.Tables["TipoviNamestaja"].Rows)
                {
                    TipNamestaja k = new TipNamestaja();
                    k.Id = (int)red["Id"];
                    k.Naziv = (string)red["Naziv"];
                    k.Obrisan = (bool)red["Obrisan"];

                    RadSaPodacima.Instance.TipoviNamestaja.Add(k);
                }
            }
        }
        public static void TipNamestajaDodaj(TipNamestaja k)
        {
            using (SqlConnection conn = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO TipoviNamestaja (Id, Naziv, Obrisan) 
                                        VALUES (@Id, @Naziv, @Obrisan)";
                command.Parameters.Add(new SqlParameter("@Id", k.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", k.Naziv));
                command.Parameters.Add(new SqlParameter("@Obrisan", k.Obrisan));

                command.ExecuteNonQuery();
            }
        }

        public static void TipNamestajaIzmeni(TipNamestaja k)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE TipoviNamestaja 
                                        SET Id=@Id, Naziv=@Naziv, Obrisan=@Obrisan WHERE Id=@Id";
                command.Parameters.Add(new SqlParameter("@Id", k.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", k.Naziv));
                command.Parameters.Add(new SqlParameter("@Obrisan", k.Obrisan));

                command.ExecuteNonQuery();
            }
        }

        public static void TipNamestajaIzbrisi(TipNamestaja k)
        {
            using (SqlConnection connection = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE TipoviNamestaja SET Obrisan=@Obrisan WHERE Id=@Id";

                command.Parameters.Add(new SqlParameter("@Id", k.Id));
                command.Parameters.Add(new SqlParameter("@Obrisan", 1));

                command.ExecuteNonQuery();
            }
        }

        public static void ClearTable()
        {
            using (SqlConnection conn = new SqlConnection(RadSaPodacima.Instance.ConnectionStr))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"DELETE FROM TipoviNamestaja";

                command.ExecuteNonQuery();
            }
        }

    }
}

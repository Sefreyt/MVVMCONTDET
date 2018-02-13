using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace MVVMCONTDET.Data
{
    public class Panneaux
    {
        //private string _dateTimeValue;
        //private DateTime _dateTimeValueOut;

        public int ID { get; set; }
        public string Contrat { get; set; }
        public string Element { get; set; }
        public string Dessin { get; set; }
        public string Fabrication { get; set; }
        public string Erection { get; set; }

    }
    public class RequeteSQL
    {
        public static string name = "SrvSQL service";
        private static string connectionString =
                  @"Data Source=SRVSQL;Initial Catalog=Schok_dev;User Id=excel; Password=excel";

        public static List<Panneaux> GetPanneaux()
        {
            const string getPannauxQuery = "select cc_cont, cc_elem, cc_dessin, cc_d_deb from dbo.CONTDET";
            var listeDesPanneaux = new List<Panneaux>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State != ConnectionState.Closed)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = getPannauxQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var pannel = new Panneaux();
                                    pannel.Contrat = reader.GetString(0);
                                    pannel.Element = reader.GetString(1);
                                    pannel.Dessin = reader.GetString(2);
                                    pannel.Fabrication = reader.GetString(3);
                                    listeDesPanneaux.Add(pannel);
                                }
                            }
                        }
                    }
                }
                return listeDesPanneaux;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }

        public static void Write(Panneaux panneaux)
        {
            Debug.WriteLine("J'imagine que l'ecriture *et l<update* a la bd est ici.");
        }
        public static void Delete(Panneaux panneaux)
        {
            Debug.WriteLine("J'imagine que le delete a la bd est ici.");
        }
    }
}


using System;
using System.Data;
using System.Data.SqlClient;

namespace Cert
{
    class Program
    {
        static int Main()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=localhost; Initial Catalog=ESPP; Integrated Security = SSPI;");
            
            SqlCommand command = new SqlCommand
            {
                CommandText = "select * from certificates where keyid = 'HDBU0H87E0CG0IIE'",
                CommandType = CommandType.Text,
                Connection = sqlConnection
            };

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                object result = null;
                while (reader.Read())
                {
                    result = reader.GetValue(0);
                }

                sqlConnection.Close();

                if (result == null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 100;   
            }
        }
    }
}

using System;
using System.Data.SqlClient;
using static System.Console;

namespace CsharpAdoNetComando
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectString = "Server=sql.freeasphost.net;Database=robertomelo822_sample_1;uid=robertomelo822;pwd=78Rest65!;";
            SqlConnection conn = new SqlConnection(connectString);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM clientes order by id";

            SqlDataReader dr = cmd.ExecuteReader();

            //MOSTRANDO TODOS OS CLIETES CADASTRADOS VIA CODIGO NO BANCO ONLINE GRATUIDO SQL SERVER
            while (dr.Read())
            {
                WriteLine("ID: {0}", dr["id"]);
                WriteLine("Nome: {0}", dr["nome"]);
                WriteLine("Email: {0}", dr["email"]);
                WriteLine("\n==============================\n");
            }

            ReadLine();
           
        }
    }
}
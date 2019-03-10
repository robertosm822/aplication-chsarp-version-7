using System;
using System.Data.SqlClient;
using static System.Console;

namespace CsharpAdoNetComando
{
    class Program
    {
        static void Main(string[] args)
        {

            //INVOCANDO OS CARACTERES CORRETOS NO 
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            /* Editar Cliente */
            //SalvarCliente("Anita Silva Melo", "meloanita@rarmy.com", "ativo", 7);

            /* Adicioar Novo cliente */
            //SalvarCliente("Anita Silva Melo", "meloanita@rarmy.com");

            /* Deletar Cliente */
            //DeletarCliente(6);
            WriteLine("==================== CONTROLE DE CLIENTES ======================");
            WriteLine("= Selecione uma Opção");
            WriteLine("  1 - Listar");
            WriteLine("  2 - Cadastrar");
            WriteLine("  3 - Editar");
            WriteLine("  4 - Excluir");
            WriteLine("  5 - Visualizar");
            WriteLine("Opção: ");
            int opc = Convert.ToInt32(ReadLine());
            Clear();
            switch (opc)
            {
                case 1:
                    Title = "Listagem de Clientes";
                    WriteLine("************** LISTAGEM DE CLIENTES ************");
                    ListarClientes();
                    break;
                case 2:
                    Title = "Cadastrar de Clientes";
                    WriteLine("************** CADASTRAR DE CLIENTES ************");

                    Write("Informe um Nome: ");
                    string nome = ReadLine();
                    Write("Informe um E-mail: ");
                    string email = ReadLine();

                    SalvarCliente(nome, email);

                    break;
                case 3:
                    Title = "Alteração de Clientes";
                    WriteLine("************** ALTERAR DE CLIENTES ************");

                    ListarClientes();
                    WriteLine("Selecione um cliente pla ID: ");
                    int idOp = Convert.ToInt32(ReadLine());
                    (int _id, string _nome, string _email) = SelecionarCliente(idOp);
                    Clear();

                    Title = "Alteração de Cliente - "+ _nome;
                    WriteLine($"************** ALTERAR CLIENTE - {_nome} ************");
                    Write("Informe um Nome: ");
                        nome = ReadLine();
                    Write("Informe um E-mail: ");
                        email = ReadLine();
                    Write("Informe um estado (ativo|inativo): ");
                        string modo = ReadLine();

                    nome = nome.Equals("") ? _nome : nome;
                    email = email.Equals("") ? _email : email;
                    modo = modo.Equals("") ? "ativo": modo;

                    SalvarCliente(nome, email, modo, _id);

                    break;
                case 4:
                    Title = "Exclusão de Clientes";
                    WriteLine("************** EXCLUSÃO DE CLIENTES ************");
                    ListarClientes();

                    WriteLine("Selecione um cliente pla ID: ");
                    idOp = Convert.ToInt32(ReadLine());
                    (_id, _nome,_email) = SelecionarCliente(idOp);
                    Clear();

                    Title = "Exclusão de Cliente"+ _nome;
                    WriteLine($"=======================EXCLUSÃO DE CLIENTE ===============");
                    WriteLine("\n**************** ATENÇÃO ********************************\n");
                    WriteLine("Deseja confirmar? S para SIM | N para NÃO: ");
                    string confirmar = ReadLine().ToUpper();

                    if (confirmar.Equals("S"))
                    {
                        DeletarCliente(_id);
                        WriteLine("Apagado com sucesso!");
                    }

                    break;
                case 5:
                    Title = "Visualiar de Clientes";
                    WriteLine("************** VISUALIZAR DE CLIENTES ************");
                    ListarClientes();

                    WriteLine("Selecione um cliente pla ID: ");
                    idOp = Convert.ToInt32(ReadLine());
                    (_id, _nome, _email) = SelecionarCliente(idOp);
                    Clear();

                    Title = "Visualizar Cliente" + _nome;
                    WriteLine($"=======================VER DETALHES DO CLIENTE - {_nome} ===============");

                    WriteLine("ID: {0}", _id);
                    WriteLine("NOME: {0}", _nome);
                    WriteLine("EMAIL: {0}", _email);
          
                    break;
                default:
                    Title = "Opção inválida";
                    WriteLine("************** ESCOLHA UMA OPÇÃO VÁLIDA ************");
                    break;

            }
            
			//PROGRAMAÇÃO - C# 7 COM ADO.NET
            //CERTIFICADO: 6c0c4474-f8a7-42d3-9adb-a9881c8ede80
			ReadLine();
           
        }
		
		static void ListarClientes()
		{
			string connString = getStringConn();
			using(SqlConnection conn = new SqlConnection(connString))
			{
				
				conn.Open();

				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT * FROM clientes order by id";
				//MOSTRANDO TODOS OS CLIETES CADASTRADOS VIA CODIGO NO BANCO ONLINE GRATUIDO SQL SERVER
				using(SqlDataReader dr = cmd.ExecuteReader())
				{
                    while (dr.Read())
                    {
                        WriteLine("ID: {0}", dr["id"]);
                        WriteLine("Nome: {0}", dr["nome"]);
                        WriteLine("Email: {0}", dr["email"]);
                        WriteLine("Status: {0}", dr["modo"]);
                        WriteLine("\n==============================\n");
                    }
                   
				}
				conn.Close();
			}	
		}
		
		static void SalvarCliente(string nome, string email, string modo="ativo" )
		{
			string connString = getStringConn();
			using(SqlConnection conn = new SqlConnection(connString))
			{
				
				conn.Open();

				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = "INSERT INTO clientes (nome, email, modo) values (@nome, @email, @modo)";
				cmd.Parameters.AddWithValue("@nome", nome);
				cmd.Parameters.AddWithValue("@email", email);
				cmd.Parameters.AddWithValue("@modo", modo);
				cmd.ExecuteNonQuery();
				
				conn.Close();
			}	
		}

        static void SalvarCliente(string nome, string email, string modo, int id)
        {
            string connString = getStringConn();
            using (SqlConnection conn = new SqlConnection(connString))
            {

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE clientes SET nome=@nome, email=@email, modo=@modo WHERE id=@id";
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@modo", modo);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        static void DeletarCliente(int id)
        {
            string connString = getStringConn();
            using (SqlConnection conn = new SqlConnection(connString))
            {

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM clientes WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        static (int, string, string) SelecionarCliente(int id)
        {
            string connString = getStringConn();
            using (SqlConnection conn = new SqlConnection(connString))
            {

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM clientes WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                //MOSTRANDO APENAS UM CLIENTE BANCO ONLINE GRATUIDO SQL SERVER
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    return (Convert.ToInt32(dr["id"].ToString()),dr["nome"].ToString(), dr["email"].ToString());
                }
                
            }
        }

        static string getStringConn()
		{
			string connString = "Server=sql.freeasphost.net;Database=robertomelo822_sample_1;uid=robertomelo822;pwd=78Rest65!;";
			return connString;
		}
    }
}
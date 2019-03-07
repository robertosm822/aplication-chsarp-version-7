using System;
using System.Globalization;
using System.Text;
using System.Collections;
using static System.Console;
using System.Collections.Generic;

namespace AvancandoCSharp
{
    class Carro {
        private string _marca;

        public string Marca {
            /*
            get
            {
                return _marca;
            }
            set {
                _marca = value;
            }
            */
            //padrao de sintaxe C# 7
            get => _marca;
            set => _marca = value;
        }

        private int _anoFabricacao;
        public int AnoFabricacao {
            /*
            get
            {
                return _anoFabricacao;
            }
            set
            {
                _anoFabricacao = value;
            }
            */
            //padrao de sintaxe C# 7
            get => _anoFabricacao;
            set => _anoFabricacao = value;
        }

        //void apenas executa uma ação
        public void Buzinar()
        {
            WriteLine("Biii... Biiii!");
        }

        public void virar(string direcao)
        {
            if (direcao.Equals("D"))
            {
                WriteLine("Virando a direita...");
            }
            else
            {
                WriteLine("Virando a esquerda...");
            }
        }
    }

    class Pessoa
    {
        private string _nome;
        public string Nome { get; set; }

        private int _idade;
        public int Idade
        {
            get => _idade;
            set => _idade = value < 0 || value > 120 ? throw new Exception("Idade inválida") : value;
        }
    }

    //Structs - Estrurura semelhante a classes, mas possui limatações
    // ela não aceita herança e é limitada 
    public struct Vendedor
    {
        public int matricula;
        public string nome;
        public string email;

        public void digiOi()
        {
            WriteLine($"Oi {this.nome}");
        }
    }

    class Program
    {
 
        static void Main(string[] args)
        {

            //INVOCANDO OS CARACTERES CORRETOS NO 
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //string frase = "Hoje a noitem sem luz, decidi xeretar a quinta gaveta de vovô: achei linguiça, fubá, pão";

            //string subFrase = "achei";
            //WriteLine("Total de Caracteres da String");
            //WriteLine(frase.Length);

            //separar as strings por virgula em um array
            /*
            string[] partes = frase.Split(',');
            for (var i=0; i< partes.Length; i++) {
                WriteLine(partes[i].Trim());
            }
            */

            //verificar se no bloco de string existe a ocorrencia de uma palavra
            /*
                string subFrase = "quinta";
                var achou = frase.Contains(subFrase);
                WriteLine(achou);
            */

            //EXIBIR A POSICAO DE UMA STRING DENTRO DE UMA FRASE
            //int posIni = frase.IndexOf(subFrase);
            //WriteLine(pos);

            //PEGAR PARTES DE UMA FRASE
            //int posFim = 10;
            // string sub1 = frase.Substring(posIni);
            // WriteLine(sub1);

            //MINUSCULOS E MAIUSCULOS
            //WriteLine(frase.ToUpper());
            //WriteLine(frase.ToLower());

            //REPLACE, TROCAR CARACTERES
            //string frase_trocada = frase.Replace("Vovô", "mamãe",true, CultureInfo.CurrentCulture);
            //WriteLine(frase_trocada);

            //CONCATENANDO STRING COM VARIAVEIS
            /*
            string nome = "Roberto Soares";
            int idade = 40;
            DateTime dataCadastro = new DateTime(2015,03,01);
            string faseConcat = "O cliente {0} tem {1} anos de indade ";
            faseConcat += " Desde: {2:dd/MM/yyyy}";
            string saida = String.Format(faseConcat,nome, idade, dataCadastro);
            */

            //MANIPULANDO A CLASSE StringBuilder para CONCATENAR STRINGS E VARIAVEIS
            //string texto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum dolor ante, ullamcorper eget tempus vel, ";
            //    texto += "aliquet id quam. Quisque ut vulputate ligula. Pellentesque hendrerit vulputate nunc id mattis. Maecenas turpis";
            //    texto += " arcu, dapibus vitae aliquam non, lobortis ac orci. Sed lectus nisi, tristique nec diam sed, hendrerit dignissim";
            //    texto += " erat. In scelerisque metus eget leo feugiat tempor. Praesent ac tristique quam, ut fermentum odio. Maecenas";
            //    texto += " eu dolor eu purus dignissim viverra vel sed ligula. Nunc interdum neque sit amet risus ullamcorper, nec ";
            //    texto += "tempor purus tincidunt. Praesent eget ligula venenatis, mattis turpis auctor, rhoncus massa. Nunc semper leo at massa dictum convallis.";
            /*
            StringBuilder builder = new StringBuilder("   Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum dolor ante, ullamcorper eget tempus vel,");
            builder.Append("aliquet id quam. Quisque ut vulputate ligula. Pellentesque hendrerit vulputate nunc id mattis. Maecenas turpis");
            builder.Append("arcu, dapibus vitae aliquam non, lobortis ac orci. Sed lectus nisi, tristique nec diam sed, hendrerit dignissim");
            builder.AppendLine(" erat. In scelerisque metus eget leo feugiat tempor. Praesent ac tristique quam, ut fermentum odio.");
            builder.Append("   Maecenas eu dolor eu purus dignissim viverra vel sed ligula. Nunc interdum neque sit amet risus ullamcorper, nec ");
            builder.AppendLine("tempor purus tincidunt. Praesent eget ligula venenatis, mattis turpis auctor, rhoncus massa. Nunc semper leo at massa dictum convallis.");

            string nome = "Roberto Soares";
            int idade = 40;
            DateTime dataCadastro = new DateTime(2015, 03, 01);

            StringBuilder frase = new StringBuilder("O cliente {0} tem {1} anos de indade  Desde: {2:dd/MM/yyyy}");
            builder.AppendFormat(frase.ToString(), nome, idade, dataCadastro);
            */

            //MANIPULAR DATAS COM DateTime
            // WriteLine("{0}", DateTime.Now.AddDays(2));
            //WriteLine("{0}", DateTime.Now.AddHours(1));

            //Formatar datas para string
            //DateTime data = new DateTime(2018,04,03,08,30,00);

            //trabalhando um formato a data
            //mais informacoes em: https://docs.microsoft.com/pt-br/dotnet/standard/base-types/custom-date-and-time-format-strings
            /*
            string databanco = "2019-03-07 15:44:00";
            DateTime data = DateTime.Parse(databanco);

            string horaFormatada = String.Format("{0:HH}h{0:mm}", data);
            string dataFormatada = String.Format("{0:dd/MM/yyyy}", data);

            WriteLine(horaFormatada);
            WriteLine(dataFormatada);
            */


            // MANIPULANDO CLASSES SIMPLES NO C#
            /*
             * testando  classe Carro
            Carro carro = new Carro();
            carro.Marca = "Fusca";
            carro.AnoFabricacao = 1978;

            carro.Buzinar();
            carro.virar("D");
            carro.virar("E");

            WriteLine($"Eu tenho um {carro.Marca} fabricado em {carro.AnoFabricacao}");
            */

            //testando o tratamento de erros personalizados
            try
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = "Tio Patinhas";
                pessoa.Idade = 125;

                WriteLine($"{pessoa.Nome} - {pessoa.Idade}");

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }


            //manipulando a classe do tipo Structs
            Vendedor vendedor = new Vendedor();
            vendedor.nome = "Humberto Silva";
            vendedor.email = "huber@gmail.com";
            vendedor.matricula = 456123;

            //vendedor.digiOi();

            /*
                MANIPULACAO DE ArrayList
             */
            // Creates and initializes a new ArrayList.
            /*
            List<string> myAL = new List<string>();
            myAL.Add("Hello");
            myAL.Add("World");
            myAL.Add("!");

            // Displays the properties and values of the ArrayList.
            Console.WriteLine("myAL");
            Console.WriteLine("    Count:    {0}", myAL.Count);
            Console.WriteLine("    Capacity: {0}", myAL.Capacity);
            Console.Write("    Values:");
            PrintValues(myAL);
            */

            List<Carro> myAL = new List<Carro>();
            Carro carro = new Carro();
            carro.Marca = "Fusca";
            carro.AnoFabricacao = 1978;
            myAL.Add(carro);

            Carro carro1 = new Carro();
            carro1.Marca = "Mustang";
            carro1.AnoFabricacao = 1988;
            myAL.Add(carro1);

            Carro carro2 = new Carro();
            carro2.Marca = "Brasília";
            carro2.AnoFabricacao = 1977;
            myAL.Add(carro2);

            foreach (Carro veiculo in myAL)
            {
                WriteLine($"Eu tenho os seguintes carros: {veiculo.Marca} - {veiculo.AnoFabricacao}");
            }


            ReadLine();
        }

        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();
        }
    }
}
using System;
using System.Text;
using System.Collections.Generic;

namespace dio_Bank
{
    class Program
    {

        static List<Conta> lista_contas = new List<Conta>();

        static void Main(string[] args)
        {
         string opcao_usuario = ObterOpcaoUsuario();

           while (opcao_usuario.ToUpper() != "X")
           {
                
                switch (opcao_usuario)
                {
                        case "1":
                            ListarContas();
                            break;
                        case "2":
                            InserirConta();
                            break;
                        case "3":
                            Transferir();
                            break;
                        case "4":
                            Sacar();
                            break;
                        case "5":
                            Depositar();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                    default:
                            throw new ArgumentOutOfRangeException();
                }
                opcao_usuario = ObterOpcaoUsuario();
           }
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int indice_conta_origem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino: !");
            int indice_conta_destino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transmitido: !");
            int valor_transferencia = int.Parse(Console.ReadLine());

            lista_contas[indice_conta_origem].Transferir(valor_transferencia, lista_contas[indice_conta_destino]);
        }

        private static void Depositar()
        {
            int entrada_conta = 0;
            double entrada_deposito = 0.0;

            if(lista_contas.Count == 0)
            {
                Console.WriteLine("Não existem contas cadastradas!");
                return; 
            }
            Console.WriteLine("Digite o número da conta: ");
            if(int.TryParse(Console.ReadLine(), out int numero_conta) 
                    && (numero_conta >= 0 && numero_conta <= lista_contas.Count))
             {
                 entrada_conta = numero_conta;
             }
             else
             {
                 Console.WriteLine("Número da conta inválido!!!!!");
                 return;
             }

             Console.WriteLine("Digite o valor do Saque: ");
             if(double.TryParse(Console.ReadLine(), out double valor_deposito))
             {
                 entrada_deposito = valor_deposito;
             }
             else
             {
                 Console.WriteLine("Valor deposito inválido!!!!!");
                 return;
             }


            lista_contas[entrada_conta].Depositar(entrada_deposito);
        }

        private static void Sacar()
        {
            bool validado = false;
            int entrada_conta = 0;
            double entrada_saque = 0.0;

            if(lista_contas.Count == 0)
            {
                Console.WriteLine("Não existem contas cadastradas!");
                return; 
            }

                Console.WriteLine("Digite o número da conta: ");
                if(int.TryParse(Console.ReadLine(), out int numero_conta) 
                    && (numero_conta >= 0 && numero_conta <= lista_contas.Count))
                {
                    entrada_conta = numero_conta;
                }
                else
                {
                    Console.WriteLine("Número da conta inválido!!!!!");
                    return;
                }

                Console.WriteLine("Digite o valor do Saque: ");
                if(double.TryParse(Console.ReadLine(), out double valor_saque))
                {
                    entrada_saque = valor_saque;
                }
                else
                {
                    Console.WriteLine("Valor saque inválido!!!!!");
                     return;
                }

                 lista_contas[entrada_conta].Sacar(entrada_saque);

        }
           
        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if(lista_contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            
            int contador = 0;
            foreach (var item in lista_contas)
            {
                Console.Write("#{0} - ", contador);
                Console.Write(item.ToString());
                contador++;
            }
        }

        private static void InserirConta()
        {   
            bool[] validador = new bool[]{false,false,false,false};
            string entrada_nome = "";
            int entrada_tipo_conta = 0;
            double entrada_saldo = 0.0, entrada_credito = 0.0;
            
            Console.WriteLine("Inserir nova conta");

            while ((validador[0] 
                    && validador[1] 
                        && validador[2] 
                            && validador[3]) == false)    
            {
                if(!validador[0])
                { 
                    Console.WriteLine("Digite 1 para Conta Física ou 2 para Jurídica: ");

                    if(int.TryParse(Console.ReadLine(), out int tipo_conta) 
                        && (tipo_conta == 1 || tipo_conta == 2))
                    {
                        entrada_tipo_conta = tipo_conta;
                        validador[0] = true;
                    }
                    else
                    {
                        Console.WriteLine("Tipo de conta inválido!!!!!");
                    }
                }

                if(validador[0] && !validador[1])
                {
                    Console.WriteLine("Digite o nome do Cliente: ");
                    entrada_nome = Console.ReadLine();
                    validador[1] = true;
                }

                if(validador[0] && validador[1] && !validador[2])
                {
                    Console.WriteLine("Digite o saldo inicial: ");

                    if(double.TryParse(Console.ReadLine(), out double saldo))
                    {
                        entrada_saldo = saldo;
                        validador[2] = true;
                    }
                    else
                    {
                        Console.WriteLine("Saldo inválido!!!!!");
                    }
                    
                }

                if(validador[0] && validador[1] && validador[2] && !validador[3])
                {
                    Console.WriteLine("Digite o crédito: ");
                    if(double.TryParse(Console.ReadLine(), out double credito))
                    {
                        entrada_credito = credito;
                        validador[3] = true;
                    }
                    else
                    {
                        Console.WriteLine("Crédito inválido!!!!!");
                    }
                }
            }
            
            Conta novaConta = new Conta(_tipo_conta: (TipoConta)entrada_tipo_conta,
                                        _saldo: entrada_saldo,
                                        _credito: entrada_credito,
                                        _nome: entrada_nome);

            lista_contas.Add(novaConta);

        }

        private static String ObterOpcaoUsuario()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Environment.NewLine + "DIO Bank a seu dispor!!!" + Environment.NewLine);
            str.Append("Informe a opção desejada:" + Environment.NewLine);
            str.Append("1 - Listar contas" + Environment.NewLine);
            str.Append("2 - Inserir nova conta" + Environment.NewLine);
            str.Append("3 - Transferir" + Environment.NewLine);
            str.Append("4 - Sacar" + Environment.NewLine);
            str.Append("5 - Depositar" + Environment.NewLine);
            str.Append("C - Limpar Tela" + Environment.NewLine);
            str.Append("X - Sair" + Environment.NewLine);

            Console.WriteLine(str);
            string opcao_usuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcao_usuario;
        }
    }
}

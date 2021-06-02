using System;
using System.Text;
using System.Collections.Generic;

namespace dio_Bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
         string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
                
                switch (opcaoUsuario)
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
                opcaoUsuario = ObterOpcaoUsuario();
           }
        }

        private static void Transferir()
        {
            int entradaContaOrigem = 0, entradaContaDestino = 0;
            double entradaValorTransferencia = 0.0;
            

            if(listContas.Count == 0)
            {
                Console.WriteLine("Não existem contas cadastradas!");
                return; 
            }
            else if(listContas.Count == 1)
            {
                 Console.WriteLine("Existe somente uma conta cadastrada!");
                return;
            } 

            while (true)
            {
                Console.WriteLine("Digite o número da conta de origem: ");
                entradaContaOrigem = int.Parse(Console.ReadLine());

                if(int.TryParse(Console.ReadLine(), out int indiceContaOrigem) 
                    && (indiceContaOrigem >= 0 && indiceContaOrigem <= listContas.Count))
                {
                    entradaContaOrigem = indiceContaOrigem;
                    break;
                }
                else
                {
                     Console.WriteLine("Número da conta inválido!!!!!");
                }
            }

            while (true)
            {
                Console.WriteLine("Digite o número da conta de destino: !");

                if(int.TryParse(Console.ReadLine(), out int indiceContaDestino) 
                    && (indiceContaDestino >= 0 && indiceContaDestino <= listContas.Count))
                {
                    entradaContaOrigem = indiceContaDestino;
                    break;
                }
                else
                {
                     Console.WriteLine("Número da conta inválido!!!!!");
                }
            }

            while (true)
            {
                Console.WriteLine("Digite o valor a ser transmitido: !");
                
                if(double.TryParse(Console.ReadLine(), out double valorTransferencia))
                {
                    entradaValorTransferencia = valorTransferencia;
                    break;
                }
        
            }

            listContas[entradaContaOrigem].Transferir(entradaValorTransferencia, listContas[entradaContaDestino]);
        }

        private static void Depositar()
        {
            int entrada_conta = 0;
            double entrada_deposito = 0.0;

            if(listContas.Count == 0)
            {
                Console.WriteLine("Não existem contas cadastradas!");
                return; 
            }

            Console.WriteLine("Digite o número da conta: ");
            if(int.TryParse(Console.ReadLine(), out int numero_conta) 
                    && (numero_conta >= 0 && numero_conta <= listContas.Count))
             {
                 entrada_conta = numero_conta;
             }
             else
             {
                 Console.WriteLine("Número da conta inválido!!!!!");
                 return;
             }

             Console.WriteLine("Digite o valor do Saque: ");
             if(double.TryParse(Console.ReadLine(), out double valorDeposito))
             {
                 entrada_deposito = valorDeposito;
             }
             else
             {
                 Console.WriteLine("Valor deposito inválido!!!!!");
                 return;
             }


            listContas[entrada_conta].Depositar(entrada_deposito);
        }

        private static void Sacar()
        {

            int entradaConta = 0;
            double entradaSaque = 0.0;

            if(listContas.Count == 0)
            {
                Console.WriteLine("Não existem contas cadastradas!");
                return; 
            }

            while (true)
            {
                Console.WriteLine("Digite o número da conta: ");
                 if(int.TryParse(Console.ReadLine(), out int numeroConta) 
                    && (numeroConta >= 0 && numeroConta <= listContas.Count))
                {
                    entradaConta = numeroConta;
                    break;
                }
                else
                {
                    Console.WriteLine("Número da conta inválido!!!!!");
                }     
            }
            
            while (true)
            {
                Console.WriteLine("Digite o valor do Saque: ");
                if(double.TryParse(Console.ReadLine(), out double valorSaque))
                {
                    entradaSaque = valorSaque;
                    break;
                }
                else
                {
                    Console.WriteLine("Valor saque inválido!!!!!");
                }
            }

            listContas[entradaConta].Sacar(entradaSaque);
        }
           
        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            
            int contador = 0;
            foreach (var item in listContas)
            {
                Console.Write("#{0} - ", contador);
                Console.Write(item.ToString());
                contador++;
            }
        }

        private static void InserirConta()
        {   
            string entradaNome = "";
            int entradaTipoConta = 0;
            double entradaSaldo = 0.0, entradaCredito = 0.0;
            
            Console.WriteLine("Inserir nova conta");
        
            while (true)
            {
                Console.WriteLine("Digite 1 para Conta Física ou 2 para Jurídica: ");

                if(int.TryParse(Console.ReadLine(), out int tipoConta) 
                    && (tipoConta == 1 || tipoConta == 2))
                {
                    entradaTipoConta = tipoConta;
                    break;
                }
                else
                {
                    Console.WriteLine("Tipo de conta inválido!!!!!");
                }
            }

            Console.WriteLine("Digite o nome do Cliente: ");
            entradaNome = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Digite o saldo inicial: ");
                if(double.TryParse(Console.ReadLine(), out double saldo))
                {
                    entradaSaldo = saldo;
                    break;
                }
                else
                {
                    Console.WriteLine("Saldo inválido!!!!!");
                }
            }

            while (true)
            {
                Console.WriteLine("Digite o crédito: ");
                if(double.TryParse(Console.ReadLine(), out double credito))
                {
                    entradaCredito = credito;
                    break;
                }
                else
                {
                    Console.WriteLine("Crédito inválido!!!!!");
                }
            }
                    
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
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
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}

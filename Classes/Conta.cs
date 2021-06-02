using System;
using System.Text;

namespace dio_Bank
{
    public class Conta
    {
        private TipoConta tipoConta {get; set;}
        private double saldo {get; set;}
        private double credito {get; set;}
        private string nome {get; set;}
    
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            this.tipoConta = tipoConta;
            this.saldo = saldo;
            this.credito = credito;
            this.nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
    	    if (this.saldo - valorSaque < this.credito *-1)
            {
               Console.WriteLine("Saldo insuficiente");
               return false;
            }

           this.saldo -= valorSaque;

            Console.WriteLine($"Saldo atual da conta de {this.nome} é {this.saldo}");
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {this.nome} é {this.saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
           if (this.Sacar(valorTransferencia))
                contaDestino.Depositar(valorTransferencia);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("TipoConta " + this.tipoConta + " | ");
            str.Append("Nome " + this.nome + " | ");
            str.Append("Saldo " + this.saldo + " | ");
            str.Append("Crédito " + this.credito );

            return str.ToString();
        }


    }
}
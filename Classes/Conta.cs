using System;
using System.Text;

namespace dio_Bank
{
    public class Conta
    {
        private TipoConta _tipo_conta {get; set;}
        private double _saldo {get; set;}
        private double _credito {get; set;}
        private string _nome {get; set;}
    
        public Conta(TipoConta _tipo_conta, double _saldo, double _credito, string _nome) 
        {
            this._tipo_conta = _tipo_conta;
            this._saldo = _saldo;
            this._credito = _credito;
            this._nome = _nome;
        }

        public bool Sacar(double valor_saque)
        {
    	    if (this._saldo - valor_saque < this._credito *-1)
            {
               Console.WriteLine("Saldo insuficiente");
               return false;
            }

            this._saldo -= valor_saque;

            Console.WriteLine($"Saldo atual da conta de {this._nome} é {this._saldo}");
            return true;
        }

        public void Depositar(double valor_deposito)
        {
            this._saldo += valor_deposito;

            Console.WriteLine($"Saldo atual da conta de {this._nome} é {this._saldo}");
        }

        public void Transferir(double valor_transferencia, Conta conta_destino)
        {
           if (this.Sacar(valor_transferencia))
                conta_destino.Depositar(valor_transferencia);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("TipoConta " + this._tipo_conta + " | ");
            str.Append("Nome " + this._nome + " | ");
            str.Append("Saldo " + this._saldo + " | ");
            str.Append("Crédito " + this._credito );

            return str.ToString();
        }


    }
}
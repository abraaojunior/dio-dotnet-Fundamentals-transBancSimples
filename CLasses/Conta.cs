using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
   public class Conta
    {
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }


        public Conta(TipoConta tipoconta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoconta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            // validando saldo, se cobre saque
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insufisciente!!!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo); //ver sobre comsição formatada

            return true;

        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito; //mesma coisa de this.Saldo = this.Saldo + this.Deposito;

            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);

        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar( valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Credito: " + this.Credito;
            return retorno;
        }
    }
}

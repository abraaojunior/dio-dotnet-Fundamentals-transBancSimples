using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

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

            Console.WriteLine("Obrigado por utilizar nossos serviços. ");
                Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.Write("Digite o numero da conta para deposito: ");
            int indiceContaDeposito = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor para deposito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceContaDeposito].Depositar(valorDeposito);
            
            // throw new NotImplementedException();
        }

        private static void Transferir()
        {
            Console.Write("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite a conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTranferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTranferencia, listaContas[indiceContaDestino]);
            
            //throw new NotImplementedException();
        }

        private static void Sacar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
            
            
            // throw new NotImplementedException();
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta castrada.");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("# {0} ", i);
                Console.WriteLine(conta);
            }
            
            //throw new NotImplementedException();
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta: ");

            Console.Write("Digite 1 para conta pessoa Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoconta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listaContas.Add(novaConta);

            //throw new NotImplementedException();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!!!!");
            Console.WriteLine("Informe a opção desejada: ");
            
            Console.WriteLine("1 - Listar contas: ");
            Console.WriteLine("2 - Inserir nova conta: ");
            Console.WriteLine("3 - Transferir: ");
            Console.WriteLine("4 - Sacar: ");
            Console.WriteLine("5 - Depositar: ");
            Console.WriteLine("C - Limpar Tela: ");
            Console.WriteLine("X - Sair ");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

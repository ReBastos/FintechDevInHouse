using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
   
    public  class Conta
    {
        public string Nome { get; set; }
        public string CPF { get; set; } //Falta Validar
        public string Endereco { get; set; }
        public decimal RendaMensal { get; set; }
        public string Agencia { get; set; }
        public decimal Saldo { get; set; } = 100;
        public List<Transacao>? TransacaoList { get; set; }

        public void AdicionarTransacao(Transacao transacao)
        {
            if(TransacaoList == null)
            {
                TransacaoList = new List<Transacao>();
            }
            TransacaoList.Add(transacao);
        }

        
        public Conta(string nome, string cPF, string endereco, decimal rendaMensal, string agencia)
        {
            Nome = nome;
            CPF = cPF;
            Endereco = endereco;
            RendaMensal = rendaMensal;
            Agencia = agencia;
        }

        public Saque Saque(decimal valor)
        {
            
                this.Saldo = Saldo - valor;

                Saque saque = new Saque(this.Nome, valor);

                return saque;

        }

        public Deposito Deposito(decimal valor)
        {

            this.Saldo = Saldo + valor;

            Deposito deposito = new Deposito(this.Nome, valor);

            return deposito;


        }

        public void RetornarSaldo()
        {
            Console.WriteLine($"Seu saldo atual é: R${Saldo:N2}");
        }

        public void Extrato()
        {
            TransacaoList.ForEach(transacao => {
            
                if(transacao is Transferencias)
                {
                    InformacoesConta();
                }
            });
        }

        public void InformacoesConta()
        {
            Console.WriteLine($"Nome: {this.Nome}");
            Console.WriteLine($"Agência: {this.Agencia}");

        }

        public decimal Transferencia(decimal valor, Conta conta)
        {

            try
            {
                if (valor < 0)
                    throw new Exception("Valor de transferência não pode ser negativo!");

                if (Saldo < valor)
                    throw new Exception("Você não possúi saldo suficiente!");

                Saldo = Saldo - valor;
                conta.Saldo = conta.Saldo + valor;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return valor;
        }

        //Falta Alterar Dados
    
    
    
    }
}

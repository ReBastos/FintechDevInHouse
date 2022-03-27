using FintechDevInHouse.Transacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
   
    public abstract class Conta
    {
        public string Nome { get; set; }
        public string CPF { get; set; } //Falta Validar
        public string Endereco { get; set; }
        public decimal RendaMensal { get; set; }
        public int Numero { get; set; }
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

        public Saque Saque(decimal valor, Conta origem)
        {
            
                this.Saldo = Saldo - valor;

                Saque saque = new Saque(origem, valor);

                return saque;

        }

        public Deposito Deposito(decimal valor, Conta origem)
        {

            this.Saldo = Saldo + valor;

            Deposito deposito = new Deposito(origem, valor);

            return deposito;


        }

        public void RetornarSaldo()
        {
            Console.WriteLine($"Seu saldo atual é: R${Saldo:N2}");
        }

        public void InformacoesConta()
        {
            Console.WriteLine($"Nome: {this.Nome}");
            Console.WriteLine($"Agência: {this.Agencia}");

        }

        public void Transferencia(decimal valor, Conta origem, Conta destino)
        {

            this.Saldo = Saldo - valor;
            destino.Saldo = Saldo + valor;

            Transferencias transferencia = new Transferencias(origem,valor,destino);

            origem.AdicionarTransacao(transferencia);
            destino.AdicionarTransacao(transferencia);



           
        }

        //Falta Alterar Dados
    
    
    
    }
}

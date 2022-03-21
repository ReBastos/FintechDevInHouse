using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
    public enum AgenciaEnum
    {
        Florianopolis, SaoJose,Biguacu
    }
    public  class Conta
    {
        public string Nome { get; set; }
        public string CPF { get; set; } //Falta Validar
        public string Endereco { get; set; }
        public decimal RendaMensal { get; set; }
        public AgenciaEnum Agencia { get; set; }
        public decimal Saldo { get; set; } = 100;
        public List<Transacao> TransacaoList { get; set; }

        public void AdicionarTransacao(Transacao transacao)
        {
            if(TransacaoList == null)
            {
                TransacaoList = new List<Transacao>();
            }
            TransacaoList.Add(transacao);
        }

        
        public Conta(string nome, string cPF, string endereco, decimal rendaMensal, AgenciaEnum agencia)
        {
            Nome = nome;
            CPF = cPF;
            Endereco = endereco;
            RendaMensal = rendaMensal;
            Agencia = agencia;
        }

        public void Saque(Saque saque)
        {
            try
            {
                if (Saldo < saque.Valor)
                    throw new Exception("Você não possúi saldo suficiente na conta!");

                if(saque.Valor <= 0)
                    throw new Exception("Valor de saque não pode ser negativo!");

                Saldo = Saldo - saque.Valor;

                Console.WriteLine($"O valor: R${saque:N2} foi sacado.");
                Console.WriteLine($"Saldo atual: R${Saldo:N2}");

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            
        }

        public void Deposito(Deposito deposito)
        {
            try
            {
                if (deposito.Valor <= 0)
                    throw new Exception("Valor de depósito inválido! Tente novalmente com um valor diferente.");

                Saldo = Saldo + deposito.Valor;

                TransacaoList.Add(deposito);
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
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
                    InformacoesConta(transacao.Origem)
                }
            });
        }

        public static void InformacoesConta(Conta conta)
        {
            Console.WriteLine($"Nome:{conta.Nome}");
            Console.WriteLine($"Agência{conta.Agencia}");

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

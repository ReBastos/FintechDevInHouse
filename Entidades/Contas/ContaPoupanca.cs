using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
    public class ContaPoupanca : Conta
    {

        public ContaPoupanca(string nome, string cPF, string endereco, decimal rendaMensal, string agencia) 
            : base(nome, cPF, endereco, rendaMensal, agencia)
        {
        }


        public decimal SimularInvestimento(decimal quantidadeMeses, decimal rentabilidadeAnual) 
        {
            var rentabilidadeMensal = rentabilidadeAnual / 12;

            decimal saldo = Saldo;
            decimal valorSimulado = 0;

            for (int i = 0; i < quantidadeMeses; i++)
            {
                valorSimulado = saldo * (rentabilidadeMensal / 100);
                saldo = saldo + valorSimulado;
            }

            return valorSimulado;
        }

    }
}

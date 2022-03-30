using FintechDevInHouse.Entidades;
using FintechDevInHouse.Transacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Transacoes
{
    
    public class ContaInvestimento : Conta
    {
 
        public Investimento? Investido { get; set; }
        

        public ContaInvestimento(string nome, string cPF, string endereco, decimal rendaMensal, string agencia) 
            : base(nome, cPF, endereco, rendaMensal, agencia)
        {
        }



    }
}

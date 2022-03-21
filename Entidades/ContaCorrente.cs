using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
    internal class ContaCorrente : Conta
    {
        public ContaCorrente(string nome, string cPF, string endereco, decimal rendaMensal, AgenciaEnum agencia) 
            : base(nome, cPF, endereco, rendaMensal, agencia)
        {
        }


    }
}

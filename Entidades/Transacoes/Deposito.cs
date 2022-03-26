using FintechDevInHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Transacoes
{
    public class Deposito : Transacao
    {
        public Deposito(Conta origem, decimal valor) : base(origem, valor)
        {
        }


    }
}

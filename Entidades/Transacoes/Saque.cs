using FintechDevInHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Transacoes
{
    public class Saque : Transacao
    {
        public Saque(Conta origem, decimal valor) : base(origem, valor)
        {
        }

    }
}

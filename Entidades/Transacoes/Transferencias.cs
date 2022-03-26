using FintechDevInHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Transacoes
{
    public class Transferencias : Transacao
    {
        

        public Conta Destino { get; set; }


        public Transferencias(Conta origem, decimal valor, Conta destino) : base(origem, valor)
        {
            Destino = destino;
        }

    }
}

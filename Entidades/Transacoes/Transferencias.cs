using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
    public class Transferencias : Transacao
    {
        

        public string Destino { get; set; }


        public Transferencias(string origem, decimal valor, string destino) : base(origem, valor)
        {
            Destino = destino;
        }

    }
}

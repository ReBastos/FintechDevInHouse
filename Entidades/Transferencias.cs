using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
    public class Transferencias
    {
        public Conta Origem { get; set; }
        public Conta Destino { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; } = DateTime.Now;

        public Transferencias(Conta origem, Conta destino, decimal valor)
        {
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }
    }
}

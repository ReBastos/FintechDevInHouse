using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
    public class Transacao
    {
        public string Origem { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public Transacao(string origem, decimal valor)
        {
            Origem = origem;
            Valor = valor;
            Data = DateTime.Now;
        }
    }
}

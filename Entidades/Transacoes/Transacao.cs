using FintechDevInHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Transacoes
{
    public class Transacao
    {
        public Conta Origem { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public Transacao(Conta origem, decimal valor)
        {
            Origem = origem;
            Valor = valor;
            Data = DateTime.Now;
        }
    }
}

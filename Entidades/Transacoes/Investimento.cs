using FintechDevInHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Transacoes
{
    public enum TipoInvestimentoEnum
    {
        LCI, LCA, CDB
    }

    public class Investimento : Transacao
    {
       

        public TipoInvestimentoEnum TipoInvestimento { get; set; }

        public DateTime? DataRetirada { get; set; }


        public Investimento(Conta origem, decimal valor, TipoInvestimentoEnum tipoInvestimento) : base(origem, valor)
        {
            TipoInvestimento = tipoInvestimento;
        }
    }
}

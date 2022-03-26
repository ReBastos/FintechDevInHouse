using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades.Transacoes
{
    public enum TipoInvestimentoEnum
    {
        LCI, LCA, CDB
    }

    public class Investimento : Transacao
    {
       

        public TipoInvestimentoEnum TipoInvestimento { get; set; }

        public DateTime? DataRetirada { get; set; }


        public Investimento(Conta origem, decimal valor) : base(origem, valor)
        {
        }
    }
}

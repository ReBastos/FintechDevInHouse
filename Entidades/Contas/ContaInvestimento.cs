﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
    public enum TipoInvestimentoEnum
    {
        LCI, LCA, CDB
    }
    public class ContaInvestimento : Conta
    {
        public decimal Investimento { get; set; } = 0;
        public TipoInvestimentoEnum TipoInvestimento { get; set; }

        public ContaInvestimento(string nome, string cPF, string endereco, decimal rendaMensal, string agencia) 
            : base(nome, cPF, endereco, rendaMensal, agencia)
        {
        }

    }
}

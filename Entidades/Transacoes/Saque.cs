﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
    public class Saque : Transacao
    {
        public Saque(string origem, decimal valor) : base(origem, valor)
        {
        }

    }
}
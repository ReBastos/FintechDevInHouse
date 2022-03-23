using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
    public class Agencia
    {
        public List<Conta>? ListContas { get; set; }

        public void AdicionarConta(Conta conta)
        {
            if (ListContas == null)
            {
                ListContas = new List<Conta>();
            }

            ListContas.Add(conta);
        }

        public Agencia(List<Conta>? listContas)
        {
            ListContas = listContas;
        }
    }
}

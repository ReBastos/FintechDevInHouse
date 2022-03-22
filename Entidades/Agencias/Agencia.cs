using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
    public class Agencia
    {
        public List<Conta> Contas { get; set; }

        public void AdicionarConta(Conta conta)
        {
            if (Contas == null)
            {
                Contas = new List<Conta>();
            }

            Contas.Add(conta);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechDevInHouse.Entidades
{
    public class Banco
    {

        public List<Conta> ContasList { get; set; }

        public void AdicionarConta(Conta conta)
        {
            if(ContasList == null)
            {
                ContasList = new List<Conta>();
            }

            ContasList.Add(conta);

        }
    }
}

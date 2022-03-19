// See https://aka.ms/new-console-template for more information
using FintechDevInHouse.Entidades;

Conta conta1 = new Conta("Renato", "017", "Ferreira", 1100, AgenciaEnum.Florianopolis);

Conta conta2 = new Conta("Rafael", "017", "Ferreira", 1200, AgenciaEnum.Florianopolis);


conta1.Transferencia(200, conta2);

conta1.RetornarSaldo();
conta2.RetornarSaldo();


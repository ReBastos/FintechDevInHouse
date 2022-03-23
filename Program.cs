// See https://aka.ms/new-console-template for more information
using FintechDevInHouse.Entidades;
using FintechDevInHouse.Entidades.Agencias;

do {
    Console.Clear();
    Agencia florianopolis = new Agencia(null);
    Agencia biguacu = new Agencia(null);
    Agencia saoJose = new Agencia(null);

    Console.WriteLine("Qual agência você gostaria de acessar?");
    Console.WriteLine("001 - Florianópolis");
    Console.WriteLine("002 - São José");
    Console.WriteLine("003 - Biguaçu");
    
    string opcaoAgencia = Console.ReadLine();

    if (opcaoAgencia == "001" || opcaoAgencia == "002" || opcaoAgencia == "003") {

        do {
        Console.Clear();
        Console.WriteLine("Menu Principal!");
        Console.WriteLine("1 - Criar Conta");
        Console.WriteLine("2 - Acessar Conta");
            var opcao = Console.ReadLine();
            if (opcao == "1")
            {
                Conta contaCriada = CriarConta(opcaoAgencia);
                VincularAgencia(contaCriada, opcaoAgencia, florianopolis, biguacu, saoJose);


            } else if (opcao == "2") {

                if (opcaoAgencia == "001") { Conta contaAcessada = AcessarConta(florianopolis);
                    MenuConta(contaAcessada);
                } else
                if (opcaoAgencia == "002") { Conta contaAcessada = AcessarConta(saoJose);
                    MenuConta(contaAcessada);
                } else
                if (opcaoAgencia == "003") { Conta contaAcessada = AcessarConta(biguacu);
                    MenuConta(contaAcessada);
                }
                else
                {
                    Console.WriteLine("Agência Inexitente");
                }

                

                
            } else if (opcao == "0")
        
            {             
                break;

            } else {

            Console.WriteLine("Opçao selecionada inválida! Tente uma opção Diferente!");

             }
    } while (true);
    }

    else
    {
        Console.WriteLine("Agência Inválida");
    }


} while (true);

Conta CriarConta(string agencia)
{
    Console.Clear();
    Console.WriteLine("Criar Conta:");
    
    Console.WriteLine("Digite o seu nome:");
    string nome = Console.ReadLine();

    Console.WriteLine("Digite o seu CPF:");
    string cpf = Console.ReadLine();

    Console.WriteLine("Digite o seu endereço:");
    string endereco = Console.ReadLine();

    Console.WriteLine("Digite a sua renda mensal:");
    decimal rendaMensal = Convert.ToDecimal(Console.ReadLine());


    do {

    Console.WriteLine("Selecione o Tipo da Conta:");
    Console.WriteLine("1 - Conta Corrente");
    Console.WriteLine("2 - Conta Poupança");
    Console.WriteLine("3 - Conta Investimento");
    string selecaoTipoConta = Console.ReadLine(); 

        if (selecaoTipoConta == "1")
        {
            ContaCorrente contaCriada = new ContaCorrente(nome, cpf, endereco, rendaMensal, agencia);
            contaCriada.InformacoesConta();
            Console.WriteLine("Conta criada com SUCESSO! Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            return contaCriada;
            break;

        } else if (selecaoTipoConta == "2")
        {
            ContaPoupanca contaCriada = new ContaPoupanca(nome, cpf, endereco, rendaMensal, agencia);
            Console.WriteLine("Conta criada com SUCESSO! Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            return contaCriada;
            break;

        } else if (selecaoTipoConta == "3")
        {
            ContaInvestimento contaCriada = new ContaInvestimento(nome, cpf, endereco, rendaMensal, agencia);
            Console.WriteLine("Conta criada com SUCESSO! Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            return contaCriada;
            break;
            
        } else
        {
            Console.WriteLine("Tipo de conta inválido! Selecione uma opção válida!");
            return null;
            continue;
        }


    } while (true);

}

void VincularAgencia(Conta conta, string agencia, Agencia florianopolis, Agencia biguacu, Agencia saojose)
{
    try
    {
        
        if (agencia == "001")
        {
            florianopolis.AdicionarConta(conta);


        }
        else if (agencia == "002")
        {
            biguacu.AdicionarConta(conta);


        }
        else if (agencia == "003")
        {
            saojose.AdicionarConta(conta);


        }
        else
        {
            throw new Exception("Agência inválida! Selecione uma opção válida!");

    
        }
    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

Conta AcessarConta (Agencia agencia)
{
    try
    {
        Console.WriteLine("Digite o seu CPF para acessar a sua conta:");
        string cpf = Console.ReadLine();

        Conta contaSelecionada = agencia.ListContas.FirstOrDefault(conta => conta.CPF == cpf);
        
        

        if(contaSelecionada == null)
        {
            return null;
            throw new Exception("Conta não encontrada!");
        } else
        {
            Console.WriteLine($"Seja Bem-Vindo {contaSelecionada.Nome}");
            return contaSelecionada;
        }
    } catch (Exception ex) {

        Console.WriteLine(ex.Message);
        return null;
    }
    
}

void MenuConta(Conta conta)
{
    if(conta is ContaCorrente)
    {
        MenuContaCorrente(conta);

    } else if (conta is ContaPoupanca)
    {

    } else if (conta is ContaInvestimento)
    {

    }

}

void MenuContaCorrente(Conta conta)
{
    do
    {
        Console.Clear();
        Console.WriteLine($"Titular: {conta.Nome}       Agência: {conta.Agencia}");
        Console.WriteLine("1 - Saque");
        Console.WriteLine("2 - Depósito");
        Console.WriteLine("3 - Verificar Saldo");
        Console.WriteLine("4 - Extrato");
        Console.WriteLine("5 - Transferência");
        Console.WriteLine("6 - Alterar Dados");
        Console.WriteLine("0 - Sair");
        var opcao = Console.ReadLine();

        if (opcao == "1")
        {

            Saque(conta);

        }
        else if (opcao == "2")
        {

            Deposito(conta);

        }
        else if (opcao == "3")
        {

            VerificarSaldo(conta);

        }
        else if (opcao == "4")
        {

            Extrato(conta);

        }


    } while (true);
}

void Saque(Conta conta)
{
    Console.WriteLine("Digite o valor a ser sacado:");
    decimal valorSaque = Convert.ToDecimal(Console.ReadLine());

    try
    {
        if (conta.Saldo < valorSaque)
            throw new Exception("Você não possúi saldo suficiente na conta!");

        if (valorSaque <= 0)
            throw new Exception("Valor de saque não pode ser negativo!");

        var saque = conta.Saque(valorSaque);

        Console.WriteLine($"O valor: R${valorSaque:N2} foi sacado.");
        Console.WriteLine($"Saldo atual: R${conta.Saldo:N2}");
        Console.ReadLine();

        conta.AdicionarTransacao(saque);

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
    }
}

void Deposito(Conta conta)
{

    Console.WriteLine("Digite o valor a ser depositado:");
    decimal valorDeposito = Convert.ToDecimal(Console.ReadLine());

    try
    {
        if (valorDeposito <= 0)
            throw new Exception("Valor de depósito inválido! Tente um valor difrente!");

        var deposito = conta.Deposito(valorDeposito);

        Console.WriteLine($"O valor: R${valorDeposito:N2} foi depositado.");
        Console.WriteLine($"Saldo atual: R${conta.Saldo:N2}");
        Console.ReadKey();

        conta.AdicionarTransacao(deposito);

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
    }
}

void VerificarSaldo(Conta conta)
{
    Console.WriteLine($"Seu saldo é de R${conta.Saldo:N2}.");
    Continuar();

}

void Extrato(Conta conta)
{
    try
    {

        if (conta.TransacaoList == null)
            throw new Exception("Não há extrato de transacoes");

        conta.TransacaoList.ForEach(transacao =>
        {
            if(transacao is Deposito)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Tipo de Transacao: Depósito");
                Console.WriteLine($"Valor: R${transacao.Valor:N2}");
                Console.WriteLine("-------------------------------");

            } else if (transacao is Saque)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Tipo de Transacao: Saque");
                Console.WriteLine($"Valor: R${transacao.Valor:N2}");
                Console.WriteLine("-------------------------------");
            
            } else if (transacao is Transferencias)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Tipo de Transacao: Transferência");
                Console.WriteLine($"Origem: {transacao.Origem}");
                Console.WriteLine($"Destino: {transacao}");

            }
            
            
        });
            Continuar();

    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    

}


void Continuar()
{
    Console.WriteLine("Pessione uma telca para continuar...");
    Console.ReadKey();
}
// See https://aka.ms/new-console-template for more information
using FintechDevInHouse.Entidades;
using FintechDevInHouse.Transacoes;

TempodoSistema();

void MenuPrincipal(DateTime dataAtual)
{
    do
    {
        Console.Clear();
        Agencia florianopolis = new Agencia(null, "Florianopolis");
        Agencia biguacu = new Agencia(null, "Biguacu");
        Agencia saoJose = new Agencia(null, "São José");


        Console.WriteLine("Qual agência você gostaria de acessar?");
        Console.WriteLine("001 - Florianópolis");
        Console.WriteLine("002 - Biguaçu");
        Console.WriteLine("003 - São José");
        Console.WriteLine("4 - Listar Todas as Contas");
        Console.WriteLine("5 - Listar Contas Negativas");
        Console.WriteLine("6 - Total do Valor Investido");
        Console.WriteLine("0 - Sair");

        string opcaoAgencia = Console.ReadLine();

        if (opcaoAgencia == "001" || opcaoAgencia == "002" || opcaoAgencia == "003")
        {

            do
            {
                Console.Clear();
                Console.WriteLine("Menu Principal!");
                Console.WriteLine("1 - Criar Conta");
                Console.WriteLine("2 - Acessar Conta");
                Console.WriteLine("3 - Listar Todas as Contas");
                Console.WriteLine("0 - Sair");
                var opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    Conta contaCriada = CriarConta(opcaoAgencia);
                    VincularAgencia(contaCriada, opcaoAgencia, florianopolis, biguacu, saoJose);


                }
                else if (opcao == "2")
                {

                    if (opcaoAgencia == "001")
                    {
                        Conta contaAcessada = AcessarConta(florianopolis);
                        MenuConta(contaAcessada, florianopolis, saoJose, biguacu, dataAtual);
                    }
                    else
                    if (opcaoAgencia == "002")
                    {
                        Conta contaAcessada = AcessarConta(biguacu);
                        MenuConta(contaAcessada, florianopolis, saoJose, biguacu, dataAtual);
                    }
                    else
                    if (opcaoAgencia == "003")
                    {
                        Conta contaAcessada = AcessarConta(saoJose);
                        MenuConta(contaAcessada, florianopolis, saoJose, biguacu, dataAtual);
                    }
                    else
                    {
                        Console.WriteLine("Agência Inexitente");
                    }




                }
                else if (opcao == "3")
                {

                    ListarContas(florianopolis, saoJose, biguacu);

                }

                else if (opcao == "0")

                {
                    break;

                }
                else
                {

                    Console.WriteLine("Opçao selecionada inválida! Tente uma opção Diferente!");

                }
            } while (true);
        }

        else if (opcaoAgencia == "4")
        {
            ListarContas(florianopolis, saoJose, biguacu);
        }

        else if (opcaoAgencia == "5")
        {
            ListarContasNegativas(florianopolis);
            ListarContasNegativas(saoJose);
            ListarContasNegativas(biguacu);
            Continuar();
        }

        else if (opcaoAgencia == "6")
        {

            TotalValorInvestido(florianopolis, biguacu, saoJose);

        }

        else if(opcaoAgencia == "0")
        {
            Console.WriteLine("Obrigado pela preferência! Aguardamos o seu retorno.");
            Continuar();
            break;
        }

        } while (true);
}

Conta CriarConta(string agencia)
{
    try
    {
        Console.Clear();
        Console.WriteLine("Criar Conta:");

        Console.WriteLine("Digite o seu nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o seu CPF:");
        string cpf = ValidarCPF(Console.ReadLine());

        if (cpf == null) 
            throw new Exception("CPF Inválido");

        Console.WriteLine("Digite o seu endereço:");
        string endereco = Console.ReadLine();

        Console.WriteLine("Digite a sua renda mensal:");
        decimal rendaMensal = Convert.ToDecimal(Console.ReadLine());


        do
        {

            Console.WriteLine("Selecione o Tipo da Conta:");
            Console.WriteLine("1 - Conta Corrente");
            Console.WriteLine("2 - Conta Poupança");
            Console.WriteLine("3 - Conta Investimento");
            string selecaoTipoConta = Console.ReadLine();

            if (selecaoTipoConta == "1")
            {
                ContaCorrente contaCriada = new ContaCorrente(nome, cpf, endereco, rendaMensal, agencia);
                Console.WriteLine("Conta criada com SUCESSO!");
                verificarAgencia(agencia);
                return contaCriada;
                break;

            }
            else if (selecaoTipoConta == "2")
            {
                ContaPoupanca contaCriada = new ContaPoupanca(nome, cpf, endereco, rendaMensal, agencia);
                Console.WriteLine("Conta criada com SUCESSO!");
                verificarAgencia(agencia);
                return contaCriada;
                break;

            }
            else if (selecaoTipoConta == "3")
            {
                ContaInvestimento contaCriada = new ContaInvestimento(nome, cpf, endereco, rendaMensal, agencia);
                Console.WriteLine("Conta criada com SUCESSO!");
                verificarAgencia(agencia);
                return contaCriada;
                break;

            }
            else
            {
                Console.WriteLine("Tipo de conta inválido! Selecione uma opção válida!");
                
                return null;
                continue;
            }


        } while (true);

        void verificarAgencia(string agencia)
        {
            if (agencia == "001")
            {
                Console.WriteLine("Conta vinculada à agência Florianópolis.");

            }
            else if (agencia == "002")
            {
                Console.WriteLine("Conta vinculada à agência Biguacu.");
            }
            else if (agencia == "003")
            {
                Console.WriteLine("Conta vinculada à agência São José.");
            }
            Continuar();
        }

    } catch(Exception ex)
    {
        return null;
        Console.WriteLine("Erro no cadastro!");
        Continuar();
    }
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

        if (agencia.ListContas == null)
            throw new Exception("Não há contas nesta agência!");


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
        Continuar();
        return null;
    }
    
}

void MenuConta(Conta conta, Agencia florianopolis, Agencia saoJose, Agencia biguacu, DateTime data)
{
    if(conta is ContaCorrente)
    {
        MenuContaCorrente(conta, florianopolis, saoJose, biguacu, data);

    } else if (conta is ContaPoupanca)
    {

        MenuContaPoupanca(conta, florianopolis, saoJose, biguacu, data);

    } else if (conta is ContaInvestimento)
    {
        MenuContaInvestimento(conta, florianopolis, saoJose, biguacu, data);

    }

}

void MenuContaCorrente(Conta conta, Agencia florianopolis, Agencia saoJose, Agencia biguacu, DateTime data)
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
        else if (opcao == "5")
        {

            Transferencia(conta, florianopolis, saoJose, biguacu, data);

        }
        else if (opcao == "6")
        {

            AlterarDados(conta);

        } else if (opcao =="0"){
            break;
        }


    } while (true);
}

void MenuContaPoupanca(Conta conta, Agencia florianopolis, Agencia saoJose, Agencia biguacu, DateTime data)
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
        Console.WriteLine("7 - Simular Investimento");
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
        else if (opcao == "5")
        {

            Transferencia(conta, florianopolis, saoJose, biguacu, data);

        }

        else if (opcao == "6")
        {

            AlterarDados(conta);   

        }
        else if (opcao == "7")
        {

            SimularInvestimentoPoupanca(conta);

        } else if (opcao =="0"){
            break;
        }


    } while (true);
}

void MenuContaInvestimento(Conta conta, Agencia florianopolis, Agencia saoJose, Agencia biguacu, DateTime data)
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
        Console.WriteLine("7 - Investir/Aplicar");
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
        else if (opcao == "5")
        {

            Transferencia(conta, florianopolis, saoJose, biguacu, data);

        }

        else if (opcao == "6")
        {

            AlterarDados(conta);

        }
        else if (opcao == "7")
        {

            MenuInvestimento(conta, data);

        }
        else if (opcao == "0")
        {
            break;
        }


    } while (true);
}

void Saque(Conta conta)
{
    Console.WriteLine("Digite o valor a ser sacado:");
    decimal valorSaque = Convert.ToDecimal(Console.ReadLine());


    try
    {

        if (conta is ContaCorrente)
        {
            if (valorSaque > conta.Saldo + (conta.RendaMensal * 0.1M))
            {
                throw new Exception("Valor excede Cheque Especial!");
            }
        }
        else
        {
            if (conta.Saldo < valorSaque)
                throw new Exception("Você não possúi saldo suficiente!");
        }

        if (valorSaque <= 0)
            throw new Exception("Valor de saque não pode ser negativo!");

        var saque = conta.Saque(valorSaque, conta);

        

        Console.WriteLine($"O valor: R${valorSaque:N2} foi sacado.");
        Console.WriteLine($"Saldo atual: R${conta.Saldo:N2}");
        Console.ReadLine();

        conta.AdicionarTransacao(saque);
        Continuar();
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

        var deposito = conta.Deposito(valorDeposito, conta);

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

    void ListarSaque(Saque transacao)
    {

        Console.WriteLine("-------------------------------");
        Console.WriteLine("Tipo de Transacao: Saque");
        Console.WriteLine($"Horário: {transacao.Data}");
        Console.WriteLine($"Origem: Titular-> {transacao.Origem.Nome} CPF->{transacao.Origem.CPF} ");
        Console.WriteLine($"Valor: R${transacao.Valor:N2}");
        Console.WriteLine("-------------------------------");

    }

    void ListarDeposito(Deposito transacao) { 

        Console.WriteLine("-------------------------------");
        Console.WriteLine("Tipo de Transacao: Depósito");
        Console.WriteLine($"Horário: {transacao.Data}");
        Console.WriteLine($"Origem: Titular-> {transacao.Origem.Nome} CPF->{transacao.Origem.CPF} ");
        Console.WriteLine($"Valor: R${transacao.Valor:N2}");
        Console.WriteLine("-------------------------------");

    }

    void ListarTransferencia(Transferencias transacao)
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Tipo de Transacao: Transferência");
        Console.WriteLine($"Horário: {transacao.Data}");
        Console.WriteLine($"Origem: {transacao.Origem}");
        Console.WriteLine($"Destino: {transacao.Destino.Nome}");
        Console.WriteLine($"Valor: {transacao.Valor}");


    }

    void ListarInvestimento(Investimento transacao)
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Tipo de Transacao: Investimento");
        Console.WriteLine($"Horário: {transacao.Data}");
        Console.WriteLine($"Origem: {transacao.Origem}");
        Console.WriteLine($"Tipo de Investimento: {transacao.TipoInvestimento}");
        Console.WriteLine($"Valor: {transacao.Valor}");
    }

    try
    {

        if (conta.TransacaoList == null)
            throw new Exception("Não há extrato de transacoes");

        conta.TransacaoList.ForEach(transacao =>
        {
            if(transacao is Deposito)
            {
                ListarDeposito((Deposito)transacao);

            } else if (transacao is Saque)
            {
                ListarSaque((Saque)transacao);
            
            } else if (transacao is Transferencias)
            {
                
                ListarTransferencia((Transferencias)transacao);

            } else if (transacao is Investimento)
            {

                ListarInvestimento((Investimento)transacao);

            }



        });
            Continuar();

    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    

}

void Transferencia(Conta conta, Agencia florianopolis, Agencia SaoJose, Agencia Biguacu, DateTime data)
{
    try
    {
        if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
            throw new Exception("Transferência não pode ser realizada fora de um dia útil!");


        Console.WriteLine("Digite o valor a ser transferido:");
        var valor = Convert.ToDecimal(Console.ReadLine());

        if (conta is ContaCorrente)
        {
            if (valor > conta.Saldo + (conta.RendaMensal * 0.1M))
            {
                throw new Exception("Valor excede Cheque Especial!");
            }
        } else
        {
            if (conta.Saldo < valor)
                throw new Exception("Você não possúi saldo suficiente!");
        }

        if (valor <= 0)
            throw new Exception("Valor inválido!");

        Console.WriteLine("Qual a Agência da conta Destino?");
        Console.WriteLine("001 - Florianópolis");
        Console.WriteLine("002 - São José");
        Console.WriteLine("003 - Biguaçu");
        string opcaoAgencia = Console.ReadLine();

        Console.WriteLine("Digite o CPF da conta Destino");
        var cpf = Console.ReadLine();

        if(cpf == conta.CPF)
            throw new Exception("Não é possível realizar uma transferência para esta conta.");


        if (opcaoAgencia == "001")
        {

            Conta contaDestino = florianopolis.ListContas.FirstOrDefault(conta => conta.CPF == cpf);
            conta.Transferencia(valor, conta, contaDestino);

            Continuar();

        }
        else if (opcaoAgencia == "002")
        {

            Conta contaDestino = SaoJose.ListContas.FirstOrDefault(conta => conta.CPF == cpf);
            conta.Transferencia(valor, conta, contaDestino);

            Continuar();

        }
        else if (opcaoAgencia == "003")
        {

            Conta contaDestino = Biguacu.ListContas.FirstOrDefault(conta => conta.CPF == cpf);
            conta.Transferencia(valor, conta, contaDestino);

            Continuar();
        }

    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Continuar();
    }
}

void AlterarDados(Conta conta){

    try{
    Console.WriteLine("O que você deseja Alterar?");
    Console.WriteLine("1 - Nome");
    Console.WriteLine("2 - Endereco");
    Console.WriteLine("3 - Renda Mensal");
    var opcao = Console.ReadLine();

    if (opcao == "1"){

        Console.WriteLine("Digite o novo nome para Titular da Conta:");
        var nome = Console.ReadLine();
        conta.Nome = nome;

    } else if (opcao == "2"){

        Console.WriteLine("Digite o novo Endereço:");
        var endereco = Console.ReadLine();
        conta.Endereco = endereco;

    } else if (opcao == "3"){

        Console.WriteLine("Digite a Renda Mensal atualizada:");
        var renda = Console.ReadLine();
        conta.RendaMensal = Convert.ToDecimal(renda);

    } else {

        throw new Exception("Opção Inválida!");
        Continuar();
    }
    
    } catch (Exception ex){
        Console.WriteLine(ex.Message);
    }

}

void SimularInvestimentoPoupanca(Conta conta){

    Console.WriteLine("Digite a quantidade de meses para simular o investimento:");
    var meses = Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine("Digite a rentabilidade anual da poupança:");
    var rentabilidadeAnual = Convert.ToDecimal(Console.ReadLine());

    var rentabilidadeMensal = rentabilidadeAnual / 12;

    var resultadoInvestimento = conta.Saldo;

    for (int i = 0; i < meses; i++)
    {

        resultadoInvestimento += (resultadoInvestimento * (rentabilidadeMensal / 100));

    }

    Console.WriteLine($"Seu saldo ao final do período simulado será de R${resultadoInvestimento:N2}");
    Continuar();
}

void Investir(Conta conta, decimal valor,TipoInvestimentoEnum tipoInvestimento)
{

    Investimento investimento1 = new Investimento(conta, valor, tipoInvestimento);
    Investimento investimento2 = new Investimento(conta, valor, tipoInvestimento);


    conta.AdicionarTransacao(investimento1);

    void AdicionarInvestimento(ContaInvestimento conta, Investimento investimento)
    {
        try
        {
            if (conta.Investido != null)
                throw new Exception("Você já possúi um investimento em curso");

            conta.Investido = investimento;

        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    AdicionarInvestimento((ContaInvestimento)conta, investimento2);
}

void SimularInvestimento(Conta conta)
{
    try
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Tipo de Investimento:");

            Console.WriteLine("1 - LCI: 8% ao ano.");
            Console.WriteLine("Aplicação mínima: 6 meses");

            Console.WriteLine("2 - LCA: 9% ao ano.");
            Console.WriteLine("Aplicação mínima: 12 meses");

            Console.WriteLine("3 - CDB: 10% ao ano.");
            Console.WriteLine("Aplicação mínima: 36 meses");

            Console.WriteLine(" ");
            Console.WriteLine("0 - Sair");

            var opcao = Console.ReadLine();

            decimal taxaAnual = 0;

            if (opcao == "1")
            {
                taxaAnual = 8;
                CalcularInvestimento(taxaAnual, TipoInvestimentoEnum.LCI);
                break;

            }
            else if (opcao == "2")
            {
                taxaAnual = 9;
                CalcularInvestimento(taxaAnual, TipoInvestimentoEnum.LCA);
                break;

            }
            else if (opcao == "3")
            {
                taxaAnual = 10;
                CalcularInvestimento(taxaAnual, TipoInvestimentoEnum.CDB);
                break;

            }
            else if (opcao == "0")
            {
                break;
            }

        } while (true);


        void CalcularInvestimento(decimal taxaAnual, TipoInvestimentoEnum tipoInvestimento)
        {

            var taxaDiaria = (taxaAnual / 365) / 100;

            Console.WriteLine("Qual o valor que pretente aplicar?");
            var valorSimulado = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Por quantos meses deseja manter o valor aplicado?");
            var meses = Convert.ToDecimal(Console.ReadLine());

            var dias = meses * 30;

            decimal resultado = 0;
            for (int i = 0; i < dias; i++)
            {
                resultado += (valorSimulado *  taxaDiaria);
            }

            resultado = valorSimulado + resultado;
            Console.WriteLine($"O valor ao final do período será de R${resultado:N2}");


            Console.WriteLine("Deseja aplicar esse valor no investimento selecionado?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            var selecao = Console.ReadLine();

            if (selecao == "1")
            {
                if (conta.Saldo < valorSimulado || valorSimulado == 0)
                    throw new Exception("Saldo incompatível para investir!");

                Investir(conta, valorSimulado, tipoInvestimento);
            }

            else
            {

            }



        }

    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Continuar();
    }
}

string ValidarCPF(string cpf)
{
    try
    {
        if (cpf.Length < 11)
            throw new Exception("Número de CPF insuficiente.");

        decimal primeiroVerificador = 0;
        
        for (int i = 0; i < 9; i++)
        {
            char caractere = cpf[i];
            var number = caractere - '0';

            primeiroVerificador += (number * (i + 1));            
            
        }

        var resto = primeiroVerificador % 11;
        var primeiroDigito = resto.ToString();

        decimal segundoVerificador = 0;

        for (int i = 0; i < 10; i++)
        {
            char caractere = cpf[i];
            var number = caractere - '0';

            segundoVerificador += (number * i);

        }
        
        var resto2 = segundoVerificador % 11;
        var segundoDigito = resto2.ToString();
    

        if (primeiroDigito[primeiroDigito.Length - 1] == cpf[9] && segundoDigito[segundoDigito.Length - 1] == cpf[10])
        {
            return cpf;
        }
        else
        {
            return null;
            throw new Exception("CPF Inválido");
            
        }


    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Continuar();
        return null;
    }


}

void Continuar()
{
    Console.WriteLine("Pessione uma telca para continuar...");
    Console.ReadKey();
}

void ListarContas(Agencia florianopolis, Agencia SaoJose, Agencia Biguacu)
{

    if(florianopolis.ListContas == null)
    {
        Console.WriteLine("Não há contas a serem listadas na Agência Florianopolis!");
    } else
    {
        foreach (Conta conta in florianopolis.ListContas)
        {
            Console.WriteLine("******************************");
            Console.WriteLine($"Titular: {conta.Nome} CPF:{conta.CPF}");
            Console.WriteLine("******************************");
        }
    }

    if (SaoJose.ListContas == null)
    {
        Console.WriteLine("Não há contas a serem listadas na Agência São Jose!");
    }
    else
    {
        foreach (Conta conta in SaoJose.ListContas)
        {
            Console.WriteLine("******************************");
            Console.WriteLine($"Titular: {conta.Nome} CPF:{conta.CPF}");
            Console.WriteLine("******************************");
        }
    }

    if (Biguacu.ListContas == null)
    {
        Console.WriteLine("Não há contas a serem listadas na Agência Biguacu!");
    }
    else
    {
        foreach (Conta conta in Biguacu.ListContas)
        {
            Console.WriteLine("******************************");
            Console.WriteLine($"Titular: {conta.Nome} CPF:{conta.CPF}");
            Console.WriteLine("******************************");
        }
    }

    Continuar();
}

void ListarContasNegativas(Agencia agencia)
{
    try
    {
        if (agencia.ListContas == null)
            throw new Exception($"Não há contas negativas na agência {agencia.Nome}");

        var contasNegativas = agencia.ListContas.Where(conta => conta.Saldo < 0);

        if (contasNegativas == null)
            throw new Exception($"Não há contas negativas na agência {agencia.Nome}");
        

        foreach(Conta conta in contasNegativas)
        {
            Console.WriteLine($"Titular: {conta.Nome}  CPF: {conta.CPF}");
        }
        

    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        
    }
    
    


}

void TempodoSistema()
{
    do
    {
        Console.Clear();
        Console.WriteLine("Defina uma data para iniciar o sistema!");
        Console.WriteLine("1 - Hoje");
        Console.WriteLine("2 - Data Simulada");
        Console.WriteLine("0 - Sair");
        var opcao = Console.ReadLine();

        if (opcao == "1") {

            DateTime data = DateTime.Now;
            MenuPrincipal(data);

        } else if (opcao == "2") {
            Console.WriteLine("Digite o dia:");

            var dia = Console.ReadLine();
            var convertDia = Int32.Parse(dia);
            Console.WriteLine("Digite o mês:");

            var mes = Console.ReadLine();
            var convertMes = Int32.Parse(mes);
            Console.WriteLine("Digite o ano:");

            var ano = Console.ReadLine();
            var convertAno = Int32.Parse(ano);

            DateTime data = new DateTime(convertAno, convertMes, convertDia);

                if (data < DateTime.Now) 
                    throw new Exception("Data não pode ser anterior a atual");


            MenuPrincipal(data);


        } else if (opcao == "0")
        {
            break;
        }

    } while (true);
}

void MenuInvestimento (Conta conta, DateTime data)
{
    do
    {

        Console.WriteLine("1 - Simular Investimento / Investir");
        Console.WriteLine("2 - Extrato Investimento");
        Console.WriteLine("3 - Sacar Investimento");
        Console.WriteLine("0 - Sair");
        var opcao = Console.ReadLine();

        if (opcao == "1")
        {

            SimularInvestimento(conta);


        }
        else if (opcao == "2")
        {

            ExtratoInvestimento((ContaInvestimento)conta, data);


        }
        else if (opcao == "3")
        {

            SacarInvestimento((ContaInvestimento)conta, data);


        }
        else if (opcao == "0")
        {
            break;
        }



    } while (true);
}

void ExtratoInvestimento(ContaInvestimento conta, DateTime data)
{
    try
    {
        if (conta.Investido == null)
            throw new Exception("Não há investimento a ser exibido!");

        if (conta.Investido.TipoInvestimento == TipoInvestimentoEnum.LCI)
        {
            ExibirInvestimento(conta, 8, TipoInvestimentoEnum.LCI, data);

        }

        else if (conta.Investido.TipoInvestimento == TipoInvestimentoEnum.LCA)
        {
            ExibirInvestimento(conta, 9, TipoInvestimentoEnum.LCA, data);

        }

        else if (conta.Investido.TipoInvestimento == TipoInvestimentoEnum.CDB)
        {
            ExibirInvestimento(conta, 10, TipoInvestimentoEnum.CDB, data);

        }

        void ExibirInvestimento(ContaInvestimento conta, decimal taxaAnual, TipoInvestimentoEnum tipoInvestimento, DateTime data)
        {
            var taxaDiaria = (taxaAnual / 365) / 100;

            var dias = (int)data.Subtract(conta.Investido.Data).TotalDays;

            decimal resultado = 0;
            for (int i = 0; i < dias; i++)
            {
                resultado += conta.Investido.Valor * taxaDiaria;
            }

            resultado += conta.Investido.Valor;

            Console.WriteLine($"Investimento do tipo {tipoInvestimento}");
            Console.WriteLine($"Taxa de rendimento anual {taxaAnual}%");
            Console.WriteLine($"Saldo atual do investimento:{resultado:N2}");
        }
    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Continuar();
    }
}

void SacarInvestimento(ContaInvestimento conta, DateTime data)
{
    try
    {

        if (conta.Investido.TipoInvestimento == TipoInvestimentoEnum.LCI)
        {

            if (conta.Investido.Data.Subtract(data).TotalDays < 180)
                throw new Exception("Tempo mínimo de investimento: 6 meses");


        } else if (conta.Investido.TipoInvestimento == TipoInvestimentoEnum.LCA)
        {

            if (conta.Investido.Data.Subtract(data).TotalDays < 360)
                throw new Exception("Tempo mínimo de investimento: 12 meses");


        }
        else if (conta.Investido.TipoInvestimento == TipoInvestimentoEnum.CDB)
        {

            if (conta.Investido.Data.Subtract(data).TotalDays < 1080)
                throw new Exception("Tempo mínimo de investimento: 36 meses");

        }        

            Console.WriteLine("Deseja sacar o valor investido?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            var opcao = Console.ReadLine();

            if(opcao == "1")
            {

                conta.Saldo += conta.Investido.Valor;
                conta.Investido = null;
                Console.WriteLine("Valor sacado com sucesso!");
            } 

            else if (opcao == "2")
            {

                Continuar();
            }



    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Continuar();
    }
    

}

void TotalValorInvestido(Agencia florianopolis, Agencia biguacu, Agencia saojose)
{

    decimal resultado = 0;

    foreach (ContaInvestimento conta in florianopolis.ListContas)
    {
        resultado += conta.Investido.Valor;
    }

    foreach (ContaInvestimento conta in biguacu.ListContas)
    {
        resultado += conta.Investido.Valor;
    }

    foreach (ContaInvestimento conta in saojose.ListContas)
    {
        resultado += conta.Investido.Valor;
    }

    if( resultado == 0)
    {
        Console.WriteLine("Não há valores investidos");
    } else
    {
        Console.WriteLine($"Total investido: R${resultado:N2}");
        Continuar();
    }


}
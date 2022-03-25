// See https://aka.ms/new-console-template for more information
using FintechDevInHouse.Entidades;



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
        Console.WriteLine("002 - São José");
        Console.WriteLine("003 - Biguaçu");
        Console.WriteLine("4 - Listar Todas as Contas");
        Console.WriteLine("5 - Listar Contas Negativas");
        Console.WriteLine("6 - Total do Valor Investido");

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
                        MenuConta(contaAcessada, florianopolis, saoJose, biguacu);
                    }
                    else
                    if (opcaoAgencia == "002")
                    {
                        Conta contaAcessada = AcessarConta(saoJose);
                        MenuConta(contaAcessada, florianopolis, saoJose, biguacu);
                    }
                    else
                    if (opcaoAgencia == "003")
                    {
                        Conta contaAcessada = AcessarConta(biguacu);
                        MenuConta(contaAcessada, florianopolis, saoJose, biguacu);
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
            else if (agencia == "002")
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

void MenuConta(Conta conta, Agencia florianopolis, Agencia saoJose, Agencia biguacu)
{
    if(conta is ContaCorrente)
    {
        MenuContaCorrente(conta, florianopolis, saoJose, biguacu);

    } else if (conta is ContaPoupanca)
    {

        MenuContaPoupanca(conta, florianopolis, saoJose, biguacu);

    } else if (conta is ContaInvestimento)
    {

    }

}

void MenuContaCorrente(Conta conta, Agencia florianopolis, Agencia saoJose, Agencia biguacu)
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

            Transferencia(conta, florianopolis, saoJose, biguacu);

        }
        else if (opcao == "6")
        {

            AlterarDados(conta);

        } else if (opcao =="0"){
            break;
        }


    } while (true);
}

void MenuContaPoupanca(Conta conta, Agencia florianopolis, Agencia saoJose, Agencia biguacu){
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

            Transferencia(conta, florianopolis, saoJose, biguacu);

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

        var saque = conta.Saque(valorSaque, conta);

        Continuar();

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
                Console.WriteLine($"Origem: Titular-> {transacao.Origem.Nome} CPF->{transacao.Origem.CPF} ");
                Console.WriteLine($"Valor: R${transacao.Valor:N2}");
                Console.WriteLine("-------------------------------");

            } else if (transacao is Saque)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Tipo de Transacao: Saque");
                Console.WriteLine($"Origem: Titular-> {transacao.Origem.Nome} CPF->{transacao.Origem.CPF} ");
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

void Transferencia(Conta conta, Agencia florianopolis, Agencia SaoJose, Agencia Biguacu)
{
    try
    {
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

void Investir(Conta conta)
{

}

void SimularInvestimento()
{
    Console.WriteLine("Qual o valor que pretente aplicar?");
    var valor = Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine("Por quantos meses deseja manter o valor aplicado?");
    var meses = Convert.ToDecimal(Console.ReadLine());
    



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
// See https://aka.ms/new-console-template for more information
using FintechDevInHouse.Entidades;
using FintechDevInHouse.Entidades.Agencias;

do {

    Florianopolis florianopolis = new Florianopolis();
    Biguacu biguacu = new Biguacu();
    SaoJose saoJose = new SaoJose();

    Console.WriteLine("Qual agência você gostaria de acessar?");
    Console.WriteLine("001 - Florianópolis");
    Console.WriteLine("002 - São José");
    Console.WriteLine("003 - Biguaçu");
    
    string opcaoAgencia = Console.ReadLine();

    if (opcaoAgencia == "001" || opcaoAgencia == "002" || opcaoAgencia == "003") {

        do { 
        Console.WriteLine("Menu Principal!");
        Console.WriteLine("1 - Criar Conta");
        var opcao = Console.ReadLine();
        if (opcao == "1")
        {
                VincularAgencia(CriarConta(opcaoAgencia),opcaoAgencia, florianopolis, biguacu, saoJose);


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

void VincularAgencia(Conta conta, string agencia, Florianopolis florianopolis, Biguacu biguacu, SaoJose saojose)
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

        Conta contaSelecionada = agencia.Contas.FirstOrDefault(conta => conta.CPF == cpf);

        if(contaSelecionada == null)
        {
            return null;
            throw new Exception("Conta não encontrada!");
        } else
        {
            return contaSelecionada;
        }
    } catch (Exception ex) {

        Console.WriteLine(ex.Message);
        return null;
    }
    
}
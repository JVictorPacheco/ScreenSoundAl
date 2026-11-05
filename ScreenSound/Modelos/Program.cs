using ScreenSound.Modelos;
using ScreenSound.Menus;

Banda coldplay = new Banda("Coldplay");
coldplay.AdicionarNota(new Avaliacao(10));


Banda queens  = new Banda("Queens of the Stone Age");
queens.AdicionarNota(new Avaliacao(10));
queens.AdicionarIntegrantes(5);


Dictionary<string, Banda> bandasRegistradas = new Dictionary<string, Banda>();
bandasRegistradas.Add(coldplay.Nome, coldplay);
bandasRegistradas.Add(queens.Nome, queens);

Banda linkinPark = new Banda("Linkin Park");
linkinPark.AdicionarNota(new Avaliacao(10));
linkinPark.AdicionarNota(new Avaliacao(8));
linkinPark.AdicionarNota(new Avaliacao(6));
bandasRegistradas.Add(linkinPark.Nome, linkinPark);

bandasRegistradas.Add("The Beatles", new Banda("The Beatles"));

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string? opcaoEscolhida = Console.ReadLine();

    if (!int.TryParse(opcaoEscolhida, out int opcaoEscolhidaNumerica)) // Aqui estamos tentando converter a string digitada pelo usuário em um número inteiro. Se a conversão falhar, o método TryParse retorna false e entramos no bloco if.
    {
        Console.WriteLine("Opção inválida. Por favor, digite um número válido.");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu(); // Se a conversão falhar, chamamos novamente a função ExibirOpcoesDoMenu() para que o usuário possa tentar novamente.
        return;
    }

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            RegistrarAlbum();
            break;
        case 3:
            MostrarBandasRegistradas();
            break;
        case 4:
            AvaliarUmaBanda();
            break;
        case 5:
            MenuExibirDetalhes menu = new MenuExibirDetalhes();
            menu.Executar(bandasRegistradas);
            ExibirOpcoesDoMenu();
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarAlbum()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de álbuns");
    Console.Write("Digite a banda cujo álbum deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    Console.Write("Agora digite o título do álbum: ");
    string? tituloAlbum = Console.ReadLine()!;

    /**
     * ESPAÇO RESERVADO PARA COMPLETAR A FUNÇÃO
     */
    Console.WriteLine($"O álbum {tituloAlbum} de {nomeDaBanda} foi registrado com sucesso!");
    Thread.Sleep(4000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    Console.WriteLine("Digite a quantidade integrantes da banda");
    string quantidadeIntegrantes = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"A banda {nomeDaBanda} já está registrada!");
    }
    else
    {
        if (int.TryParse(quantidadeIntegrantes, out int integrantes))
        {
            
            if (integrantes > 0)
            {

                Banda banda = new Banda(nomeDaBanda);
                banda.AdicionarIntegrantes(integrantes);
                bandasRegistradas.Add(nomeDaBanda, banda);
                Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
            } 
            else
            {
                Console.WriteLine("Quantidade de integrantes inválida.");
                Console.Clear();
                ExibirOpcoesDoMenu();
                return;
            }
        }
        else
        {
            Console.WriteLine("Quantidade de integrantes inválida.");
        }
    }
    Thread.Sleep(4000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");

    foreach (string nomeDaBanda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {nomeDaBanda}, Integrantes: {bandasRegistradas[nomeDaBanda].Integrantes}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
        if (nota.Nota < 0 || nota.Nota > 10) // Aqui verificamos se a nota informada está entre 0 e 10.
        {
            Console.WriteLine("Nota inválida. Por favor, digite um número entre 0 e 10.");
            Thread.Sleep(2000);
            Console.Clear();
            ExibirOpcoesDoMenu();
            return;
        }


        bandasRegistradas[nomeDaBanda].AdicionarNota(nota);
        Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}


ExibirOpcoesDoMenu();
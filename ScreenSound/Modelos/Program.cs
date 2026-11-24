using ScreenSound.Modelos;
using ScreenSound.Menus;

Banda coldplay = new Banda("Coldplay");
coldplay.AdicionarNota(new Avaliacao(10));


Banda queens = new Banda("Queens of the Stone Age");
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
            MenuRegistrarBanda menu1 = new MenuRegistrarBanda();
            menu1.Executar(bandasRegistradas);
            ExibirOpcoesDoMenu();
            break; 
        case 2:
            MenuRegistrarAlbum menu2 = new MenuRegistrarAlbum();
            menu2.Executar(bandasRegistradas);
            ExibirOpcoesDoMenu();
            break;
        case 3:
            MenuMostrarBandasRegistradas menu3 = new MenuMostrarBandasRegistradas();
            menu3.Executar(bandasRegistradas);
            ExibirOpcoesDoMenu();
            break;
        case 4:
            MenuAvaliarBanda menu4 = new MenuAvaliarBanda();
            menu4.Executar(bandasRegistradas);
            ExibirOpcoesDoMenu();
            break;
        case 5:
            MenuExibirDetalhes menu5 = new MenuExibirDetalhes();
            menu5.Executar(bandasRegistradas);
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

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}


ExibirOpcoesDoMenu();

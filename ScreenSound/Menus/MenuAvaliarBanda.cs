using ScreendSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuAvaliarBanda : Menu
{
    public void Executar(Dictionary<string, Banda> bandasRegistradas)
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
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

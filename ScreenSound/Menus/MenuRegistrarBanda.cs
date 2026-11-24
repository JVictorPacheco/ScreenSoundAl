using ScreendSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{


    public void Executar()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar:  ");
        string nomeDaBanda = Console.ReadLine()!;
        Console.Write("Digite a quantidade integrantes da banda: ");
        string quantidadeIntegrantes = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"A banda {nomeDaBanda} já está registrada!");
            Thread.Sleep(2000);
            Console.Clear();
            ExibirOpcoesDoMenu();
            return;
        }

        if (!int.TryParse(quantidadeIntegrantes, out int integrantes) || integrantes <= 0)
        {
            Console.WriteLine("Quantidade de integrantes inválida.");
            Console.Clear();
            ExibirOpcoesDoMenu();
            return;
        }

        Banda banda = new Banda(nomeDaBanda);
        banda.AdicionarIntegrantes(integrantes);
        bandasRegistradas.Add(nomeDaBanda, banda);
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

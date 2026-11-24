using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarBandasRegistradas : Menu
{
	public void Executar(Dictionary<string, Banda> bandasRegistradas)
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
    }
}

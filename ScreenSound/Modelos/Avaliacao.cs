namespace ScreenSound.Modelos;

internal class Avaliacao
{
	public Avaliacao(int nota) // Construtor que recebe a nota da avaliação
    {
		Nota = nota;
	}

	public int Nota { get; }


    // Método para exibir a avaliação

    public void ExibirAvaliacao()
    {
        Console.WriteLine($"Nota da avaliação: {Nota}");
    }

    public void RegraDeNegocio()
    {
        if (Nota < 0 || Nota > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(Nota), "A nota deve estar entre 0 e 10.");
        }
    }


    public static Avaliacao Parse(string texto)
    {
        int nota = int.Parse(texto);
        return new Avaliacao(nota);
    }
}

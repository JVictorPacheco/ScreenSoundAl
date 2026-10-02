namespace ScreenSound.Modelos;

class Banda
{

    // Atributos
    private List<Album> albuns = new List<Album>();
    private List<int> notas = new List<int>();

    public Banda(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    public double Media => notas.Average(); // Calcula a média das notas da banda
    public List<Album> Albuns => albuns; // Retorna a lista de álbuns da banda


    // Métodos
    public void AdicionarAlbum(Album album) 
    { 
        albuns.Add(album);
    }

    public void AdicionarNota(int nota)
    {
        notas.Add(nota);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in albuns)
        {
            Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
        }
    }
}

// A classe Banda representa uma banda musical, com propriedades para o nome da banda, uma lista de álbuns e uma lista de notas.
// Ela possui métodos para adicionar álbuns e notas, além de exibir a discografia da banda.
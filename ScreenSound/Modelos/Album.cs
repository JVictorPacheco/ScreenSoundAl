using ScreenSound.Modelos;


namespace ScreenSound.Modelos;


internal class Album
{

    // Propriedades
    private List<Musica> musicas = new List<Musica>();

    public Album(string nome) // Construtor
    {
        Nome = nome; // Inicializa a propriedade Nome com o valor passado como argumento
    }

    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    public List<Musica> Musicas => musicas;


    // Métodos
    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum {Nome}:\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {DuracaoTotal}");
    }
}

// Essa classe album tem como construtor o nome do álbum, e possui uma lista de músicas. Ela também possui métodos para adicionar músicas e exibir as músicas do álbum,
// além de calcular a duração total do álbum com base na soma das durações das músicas.
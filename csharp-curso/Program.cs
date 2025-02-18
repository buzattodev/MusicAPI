using ScreenSound_04.Modelos;
using System.Text.Json;
using ScreenSound_04.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        // LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "Michael Jackson");

        var musicasPreferidasVictor = new MusicasPreferidas("Victor");
        musicasPreferidasVictor.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidasVictor.AdicionarMusicasFavoritas(musicas[8]);
        musicasPreferidasVictor.AdicionarMusicasFavoritas(musicas[11]);
        musicasPreferidasVictor.AdicionarMusicasFavoritas(musicas[15]);
        musicasPreferidasVictor.AdicionarMusicasFavoritas(musicas[19]);

        musicasPreferidasVictor.GerarArquivoJson();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}

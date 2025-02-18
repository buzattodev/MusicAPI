using ScreenSound_04.Modelos;
using System.Text.Json;
using ScreenSound_04.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        Console.WriteLine("Here's the all time top songs!");
        Console.WriteLine("Select a number to execute the function:");
        Console.WriteLine("1 - Filter all musical genders");
        Console.WriteLine("2 - Filter by A-Z artists");
        Console.WriteLine("3 - Filter songs by tone");
        Console.WriteLine("0 - Exit");
        string writeOption = Console.ReadLine();
        int value = Convert.ToInt32(writeOption);

        switch (value)
        {
            case 1:
                LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
                break;
            case 2:
                LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
                break;
            case 3:
                LinqFilter.ListaDeMusicasPorTonalidade(musicas);
                break;
            default:Environment.Exit(0);
                break;
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}

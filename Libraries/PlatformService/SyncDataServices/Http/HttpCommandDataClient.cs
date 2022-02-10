using PlatformService.Dtos;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataServices.Http;

public class HttpCommandDataClient : ICommandDataClient
{
    private readonly HttpClient? httpClient;
    private readonly IConfiguration configuration;

    public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
    {
        this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task SendPlatformToCommand(PlatformReadDto platform)
    {
        var httpContet = new StringContent(
            JsonSerializer.Serialize(platform),
            Encoding.UTF8,
            "application/json");

        var response = await this.httpClient.PostAsync(configuration["CommandService"], httpContet);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Sync post to CommandService was OK");
        }
        else
        {
            Console.WriteLine("Sync post to CommandService was not OK");
        }


    }
}

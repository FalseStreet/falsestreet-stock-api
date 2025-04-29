using stock_core.Domains;
using stock_infra.External;
using System.Text.Json;

namespace stock_infra.Implementations.External
{
    public class FinnhubService : IFinnhubService
    {
        public FinnhubService()
        {
        }
        public async Task<List<Symbols>> GetSymbols(string exchange, string apiKey)
        {
            try
            {
                var finnhubUrl = $"https://finnhub.io/api/v1/stock/symbol?exchange={exchange}&token={apiKey}";
                using HttpClient httpClient = new();
                var respone  = await httpClient.GetAsync(finnhubUrl);
                if (respone.IsSuccessStatusCode)
                {
                    var responseBody = await respone.Content.ReadAsStringAsync();
                    var symbols = JsonSerializer.Deserialize<List<Symbols>>(responseBody);
                    return symbols ?? [];
                }
                else
                {
                    throw new Exception($"Error while fetching symbols from Finnhub: {respone.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching symbols from Finnhub", ex);
            }
        }
    }
}

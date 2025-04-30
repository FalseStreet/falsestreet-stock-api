using stock_core.Domains;
namespace stock_infra.External
{
    public interface IFinnhubService
    {
        Task<List<Symbols>> GetSymbols(string exchange, string apiKey);
    }
}

using Microsoft.AspNetCore.Mvc;
using stock_core.Domains;
using stock_infra.External;

namespace stock_api.Controllers
{
    [ApiController]
    public class QueryController
    {
        private readonly IFinnhubService _finnhubService;
        public QueryController(IFinnhubService finnhubService)
        {
            _finnhubService = finnhubService;
        }
        [HttpGet]
        [Route("symbols")]
        public async Task<List<Symbols>> GetSymbols([FromQuery] string exchange)
        {
            string? finnhubApiKey = Environment.GetEnvironmentVariable("FINNHUB_API_KEY");
            return await _finnhubService.GetSymbols(exchange, finnhubApiKey ?? "");
        }
    }
}

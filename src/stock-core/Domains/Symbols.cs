namespace stock_core.Domains
{
    public class Symbols
    {
        public Guid Id { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string DisplaySymbol { get; set; }
        public string Symbol { get; set; }
    }
}

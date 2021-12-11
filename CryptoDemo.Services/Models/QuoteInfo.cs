namespace CryptoDemo.Services.Models
{

    public class QuoteInfo
    {
        public string? symbol_id { get; set; }
        public DateTime time_exchange { get; set; }
        public DateTime time_coinapi { get; set; }
        public decimal ask_price { get; set; }
        public decimal ask_size { get; set; }
        public decimal bid_price { get; set; }
        public decimal bid_size { get; set; }
        public LastTrade? last_trade { get; set; }
    }

    public class LastTrade
    {
        public DateTime time_exchange { get; set; }
        public DateTime time_coinapi { get; set; }
        public string? uuid { get; set; }
        public decimal price { get; set; }
        public decimal size { get; set; }
        public string? taker_side { get; set; }
    }
}

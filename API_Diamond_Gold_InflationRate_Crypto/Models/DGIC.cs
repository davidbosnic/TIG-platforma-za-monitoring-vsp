using InfluxDB.Client.Core;
using System;

namespace API_Diamond_Gold_InflationRate_Crypto
{
    [Measurement("_diamond_gold_inflation_crypto")]
    public class DGIC
    {
        [Column(IsTimestamp = true)]
        public DateTime Date { get; set; }
        [Column("diamond_price")]
        public double DiamondPrice { get; set; }
        [Column("inflation_rate")]
        public decimal InflationRate { get; set; }
        [Column("gold_price")]
        public double GoldPrice { get; set; }
        [Column("btc_close")]
        public double BTC_Close { get; set; }
        [Column("btc_volume")]
        public double BTC_Volume { get; set; }
        [Column("btc_marketcap")]
        public double BTC_Marketcap { get; set; }
        [Column("eth_close")]
        public double ETH_Close { get; set; }
        [Column("eth_volume")]
        public double ETH_Volume { get; set; }
        [Column("eth_marketcap")]
        public double ETH_Marketcap { get; set; }
        [Column("doge_close")]
        public double DOGE_Close { get; set; }
        [Column("doge_volume")]
        public double DOGE_Volume { get; set; }
        [Column("doge_marketcap")]
        public double DOGE_Marketcap { get; set; }
    }
}

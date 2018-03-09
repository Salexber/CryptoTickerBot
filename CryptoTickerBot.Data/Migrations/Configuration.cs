using System.Collections.Generic;
using System.Data.Entity.Migrations;
using CryptoTickerBot.Data.Domain;
using CryptoTickerBot.Data.Enums;
using CryptoTickerBot.Data.Extensions;
using CryptoTickerBot.Data.Persistence;
using NLog;

namespace CryptoTickerBot.Data.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<CtbContext>
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger ( );

		public Configuration ( )
		{
			AutomaticMigrationsEnabled        = true;
			AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed ( CtbContext context )
		{
			Logger.Info ( "Seeding Database" );

			context.Coins.AddOrUpdate (
				new CryptoCoin ( CryptoCoinId.BTC, "Bitcoin" ),
				new CryptoCoin ( CryptoCoinId.ETH, "Ethereum" ),
				new CryptoCoin ( CryptoCoinId.BCH, "Bitcoin Cash" ),
				new CryptoCoin ( CryptoCoinId.LTC, "Litecoin" ),
				new CryptoCoin ( CryptoCoinId.XRP, "Ripple" ),
				new CryptoCoin ( CryptoCoinId.NEO, "NEO" ),
				new CryptoCoin ( CryptoCoinId.DASH, "Dash" ),
				new CryptoCoin ( CryptoCoinId.XMR, "Monero" ),
				new CryptoCoin ( CryptoCoinId.TRX, "Tron" ),
				new CryptoCoin ( CryptoCoinId.ETC, "Ethereum Classic" ),
				new CryptoCoin ( CryptoCoinId.OMG, "OmiseGo" ),
				new CryptoCoin ( CryptoCoinId.ZEC, "Zcash" ),
				new CryptoCoin ( CryptoCoinId.XLM, "Stellar" ),
				new CryptoCoin ( CryptoCoinId.BNB, "Binance Coin" ),
				new CryptoCoin ( CryptoCoinId.BTG, "Bitcoin Gold" ),
				new CryptoCoin ( CryptoCoinId.BCD, "Bitcoin Diamond" ),
				new CryptoCoin ( CryptoCoinId.IOT, "IOTA" ),
				new CryptoCoin ( CryptoCoinId.DOGE, "Dogecoin" ),
				new CryptoCoin ( CryptoCoinId.STEEM, "Steem" )
			);

			context.Exchanges.AddIfNotExists (
				new CryptoExchange
				(
					CryptoExchangeId.Binance,
					"Binance",
					"https://www.binance.com/",
					"wss://stream2.binance.com:9443/ws/!ticker@arr@3000ms",
					0.1m,
					0.1m,
					withdrawalFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0.001m,
						[CryptoCoinId.ETH] = 0.01m,
						[CryptoCoinId.BCH] = 0.001m,
						[CryptoCoinId.LTC] = 0.01m
					},
					depositFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0,
						[CryptoCoinId.ETH] = 0,
						[CryptoCoinId.BCH] = 0,
						[CryptoCoinId.LTC] = 0
					}
				),
				CryptoExchangeId.Binance
			);

			context.Exchanges.AddIfNotExists (
				new CryptoExchange
				(
					CryptoExchangeId.BitBay,
					"BitBay",
					"https://bitbay.net/en",
					"https://api.bitbay.net/rest/trading/ticker",
					0.3m,
					0.3m,
					withdrawalFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0.0009m,
						[CryptoCoinId.ETH] = 0.00126m,
						[CryptoCoinId.BCH] = 0.0006m,
						[CryptoCoinId.LTC] = 0.005m
					},
					depositFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0,
						[CryptoCoinId.ETH] = 0,
						[CryptoCoinId.BCH] = 0,
						[CryptoCoinId.LTC] = 0
					}
				),
				CryptoExchangeId.BitBay
			);

			context.Exchanges.AddIfNotExists (
				new CryptoExchange
				(
					CryptoExchangeId.Coinbase,
					"Coinbase",
					"https://www.coinbase.com/",
					"wss://ws-feed.gdax.com/",
					0.3m,
					0.3m,
					withdrawalFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0.001m,
						[CryptoCoinId.ETH] = 0.003m,
						[CryptoCoinId.BCH] = 0.001m,
						[CryptoCoinId.LTC] = 0.01m
					},
					depositFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0,
						[CryptoCoinId.ETH] = 0,
						[CryptoCoinId.BCH] = 0,
						[CryptoCoinId.LTC] = 0
					}
				),
				CryptoExchangeId.Coinbase
			);

			context.Exchanges.AddIfNotExists (
				new CryptoExchange
				(
					CryptoExchangeId.CoinDelta,
					"CoinDelta",
					"https://coindelta.com/",
					"https://coindelta.com/api/v1/public/getticker/",
					0.3m,
					0.3m,
					withdrawalFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0.001m,
						[CryptoCoinId.ETH] = 0.001m,
						[CryptoCoinId.BCH] = 0.001m,
						[CryptoCoinId.LTC] = 0.002m
					},
					depositFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0,
						[CryptoCoinId.ETH] = 0,
						[CryptoCoinId.BCH] = 0,
						[CryptoCoinId.LTC] = 0
					}
				),
				CryptoExchangeId.CoinDelta
			);

			context.Exchanges.AddIfNotExists (
				new CryptoExchange
				(
					CryptoExchangeId.Koinex,
					"Koinex",
					"https://koinex.in/",
					"wss://ws-ap2.pusher.com/app/9197b0bfdf3f71a4064e?protocol=7&client=js&version=4.1.0&flash=false",
					0.25m,
					withdrawalFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0.001m,
						[CryptoCoinId.ETH] = 0.003m,
						[CryptoCoinId.BCH] = 0.001m,
						[CryptoCoinId.LTC] = 0.01m
					},
					depositFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0,
						[CryptoCoinId.ETH] = 0,
						[CryptoCoinId.BCH] = 0,
						[CryptoCoinId.LTC] = 0
					}
				),
				CryptoExchangeId.Koinex
			);

			context.Exchanges.AddIfNotExists (
				new CryptoExchange
				(
					CryptoExchangeId.Kraken,
					"Kraken",
					"https://www.kraken.com/",
					"https://api.kraken.com/0/public/Ticker?pair=XBTUSD,BCHUSD,ETHUSD,LTCUSD",
					0.26m,
					0.26m,
					withdrawalFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0.0025m,
						[CryptoCoinId.ETH] = 0.005m,
						[CryptoCoinId.BCH] = 0.001m,
						[CryptoCoinId.LTC] = 0.02m
					},
					depositFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0,
						[CryptoCoinId.ETH] = 0,
						[CryptoCoinId.BCH] = 0,
						[CryptoCoinId.LTC] = 0
					}
				),
				CryptoExchangeId.Kraken
			);

			context.Exchanges.AddIfNotExists (
				new CryptoExchange
				(
					CryptoExchangeId.Bitstamp,
					"Bitstamp",
					"https://www.bitstamp.net/",
					"wss://ws.pusherapp.com/app/de504dc5763aeef9ff52?protocol=7&client=js&version=2.1.6&flash=false",
					0m,
					0m,
					withdrawalFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0m,
						[CryptoCoinId.ETH] = 0m,
						[CryptoCoinId.BCH] = 0m,
						[CryptoCoinId.LTC] = 0m
					},
					depositFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0,
						[CryptoCoinId.ETH] = 0,
						[CryptoCoinId.BCH] = 0,
						[CryptoCoinId.LTC] = 0
					}
				),
				CryptoExchangeId.Bitstamp
			);

			context.Exchanges.AddIfNotExists (
				new CryptoExchange
				(
					CryptoExchangeId.Zebpay,
					"Zebpay",
					"https://www.zebpay.com/",
					"https://www.zebapi.com/api/v1/market/ticker-new/",
					0,
					0,
					withdrawalFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0.0009m,
						[CryptoCoinId.ETH] = 0.002m,
						[CryptoCoinId.BCH] = 0.0001m,
						[CryptoCoinId.LTC] = 0.006m
					},
					depositFees: new Dictionary<CryptoCoinId, decimal>
					{
						[CryptoCoinId.BTC] = 0,
						[CryptoCoinId.ETH] = 0,
						[CryptoCoinId.BCH] = 0,
						[CryptoCoinId.LTC] = 0
					}
				),
				CryptoExchangeId.Zebpay
			);

			context.TeleBotUsers.AddIfNotExists (
				new TeleBotUser ( 295348666, UserRole.Owner, "DevilDaga", "Harsh", "Daga" ),
				295348666
			);
		}
	}
}
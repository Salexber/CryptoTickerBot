﻿using System;
using CryptoTickerBot.GoogleSheets;
using CryptoTickerBot.WebSocket.Services;
using NLog;
using TelegramBot.Core;
using WebSocketSharp.Server;
using LogLevel = WebSocketSharp.LogLevel;

namespace CryptoTickerBot.WebSocket
{
	public class Program
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger ( );

		public static void Main ( )
		{
			AppDomain.CurrentDomain.UnhandledException += ( sender, args ) =>
				Logger.Error ( args );

			Console.Title = "Crypto Ticker Bot";

			var ctb = CryptoTickerBotCore.CreateAndStart ( );

			StartGoogleSheetUpdater ( ctb );

			var teleBot = new TeleBot ( Settings.Instance.BotToken, ctb );
			teleBot.Start ( );
			teleBot.Restart += bot => StartGoogleSheetUpdater ( bot.Ctb );

			try
			{
				var sv = new WebSocketServer ( $"ws://{Settings.Instance.Ip}:{Settings.Instance.Port}" );
				sv.Log.Level = LogLevel.Fatal;
				sv.AddWebSocketService (
					"/telebot",
					( ) => new TeleBotWebSocketService ( teleBot )
				);
				sv.Start ( );
			}
			catch ( Exception e )
			{
				Logger.Error ( e );
				throw;
			}

			Console.ReadLine ( );
		}

		public static GoogleSheetsUpdater StartGoogleSheetUpdater ( CryptoTickerBotCore ctb ) =>
			GoogleSheetsUpdater.Build (
				ctb,
				Settings.Instance.ApplicationName,
				Settings.Instance.SheetName,
				Settings.Instance.SheetId,
				Settings.Instance.SheetsRanges,
				Settings.Instance.SheetUpdateFrequency
			);
	}
}
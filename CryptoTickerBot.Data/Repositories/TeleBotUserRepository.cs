﻿using System;
using System.Data.Entity.Migrations;
using CryptoTickerBot.Data.Domain;
using CryptoTickerBot.Data.Enums;
using CryptoTickerBot.Data.Persistence;
using JetBrains.Annotations;

namespace CryptoTickerBot.Data.Repositories
{
	public class TeleBotUserRepository : Repository<TeleBotUser>, ITeleBotUserRepository
	{
		public TeleBotUserRepository ( [NotNull] CtbContext context ) : base ( context )
		{
		}

		public void AddOrUpdate ( string userName, UserRole role, DateTime? created = null ) =>
			Context.TeleBotUsers.AddOrUpdate ( new TeleBotUser ( userName, role, created ) );

		public void Remove ( string userName ) =>
			Remove ( x => x.UserName.Equals ( userName, StringComparison.InvariantCultureIgnoreCase ) );
	}
}
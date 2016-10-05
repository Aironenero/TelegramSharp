using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core.EventArgs
{
	public class UpdateReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// Message received (contains any media)
		/// </summary>
		public Update Update;

		/// <summary>
		/// The bot which received the message.
		/// </summary>
		public User Bot;

		/// <summary>
		/// Contains data from a telegram update (any media, for only text messages use TextMessageReceived)
		/// </summary>
		/// <param name="bot">The bot</param>
		/// <param name="upd">The Update</param>
		public UpdateReceivedEventArgs(Update upd, User bot) {
			Bot = bot;
			Update = upd;
		}
	}
	}
}


using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core.EventArgs
{
	/// <summary>
	/// The args used by LocationReceivedEvent.
	/// </summary>
	public class LocationMessageReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// The location received.
		/// </summary>
		public Location Location;

		/// <summary>
		/// The user who sent the location.
		/// </summary>
		public User Sender;

		/// <summary>
		/// The bot which received the message.
		/// </summary>
		public User Bot;

		/// <summary>
		/// The ChatID of the chat where the message was sent.
		/// </summary>
		public long ChatID;

		/// <summary>
		/// Contains Location from a telegram message
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="bot">The bot.</param>
		public LocationMessageReceivedEventArgs(Message msg, User bot) {
			Location = msg.Location;
			Sender = msg.From;
			Bot = bot;
			ChatID = msg.Chat.Id;
		}
	}
}


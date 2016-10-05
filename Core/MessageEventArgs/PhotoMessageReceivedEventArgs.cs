using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core.MessageEventArgs
{
	/// <summary>
	/// The args used by PhotoReceivedEvent.
	/// </summary>
	public class PhotoMessageReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// The photo received.
		/// </summary>
		public PhotoSize[] Photo;

		/// <summary>
		/// The user who sent the photo.
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
		/// Contains Photo from a telegram message
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="bot">The bot.</param>
		public PhotoMessageReceivedEventArgs(Message msg, User bot) {
			Photo = msg.Photo;
			Sender = msg.From;
			Bot = bot;
			ChatID = msg.Chat.Id;
		}
	}
}


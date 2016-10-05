using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core.MessageEventArgs
{
	/// <summary>
	/// Args used by DocumentReceivedEvent.
	/// </summary>
	public class DocumentMessageReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// The document received.
		/// </summary>
		public Document Document;

		/// <summary>
		/// The user who sent the document.
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
		/// Contains a document from a telegram message.
		/// </summary>
		/// <param name="msg">The message.</param>
		/// <param name="bot">The bot.</param>
		public DocumentMessageReceivedEventArgs(Message msg, User bot) {
			Document = msg.Document;
			Sender = msg.From;
			Bot = bot;
			ChatID = msg.Chat.Id;
		}
	}
}


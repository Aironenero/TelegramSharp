using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core.EventArgs
{
	/// <summary>
	/// Args used by ContactReceivedEvent.
	/// </summary>
	public class ContactMessageReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// The contact received.
		/// </summary>
		public Contact Contact;

		/// <summary>
		/// The user who sent the contact.
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
		/// Contains a contact from a telegram message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="bot">The bot.</param>
		public ContactMessageReceivedEventArgs(Message msg, User bot) {
			Contact = msg.Contact;
			Sender = msg.From;
			Bot = bot;
			ChatID = msg.Chat.Id;
		}
	}
}
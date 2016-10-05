using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core.MessageEventArgs
{
	/// <summary>
	/// Args used by TextMessageReceived
	/// </summary>
	public class TextMessageReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// Text of the message
		/// </summary>
		public string MessageText;

		/// <summary>
		/// Sender of the message
		/// </summary>
		public User Sender;

		/// <summary>
		/// Bot which received the message
		/// </summary>
		public User Bot;

		/// <summary>
		/// Chat ID from where this message have been sent
		/// </summary>
		public long ChatID;


		/// <summary>
		/// Contains text message from a telegram update (only thext, for any media use UpdateReceived)
		/// </summary>
		/// <param name="msg">The text message</param>
		/// <param name="bot">The bot</param>
		public TextMessageReceivedEventArgs(Message msg, User bot) {
			Bot = bot;
			Sender = msg.From;
			MessageText = msg.Text;
			ChatID = msg.Chat.Id;
		}
	}
}		




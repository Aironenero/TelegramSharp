using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core.EventArgs
{
	/// <summary>
	/// The args used by StickerReceivedEvent.
	/// </summary>
	public class StickerMessageReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// The sticker received.
		/// </summary>
		public Sticker Sticker;

		/// <summary>
		/// The user who sent the sticker.
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
		/// Contains Sticker from a telegram message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="bot">The bot.</param>
		public StickerMessageReceivedEventArgs(Message msg, User bot) {
			Sticker = msg.Sticker;
			Sender = msg.From;
			Bot = bot;
			ChatID = msg.Chat.Id;
		}
	}
}


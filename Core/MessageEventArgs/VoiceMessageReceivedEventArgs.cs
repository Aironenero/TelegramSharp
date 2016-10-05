using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core.MessageEventArgs
{
	/// <summary>
	/// The args used by VoiceReceivedEvent.
	/// </summary>
	public class VoiceMessageReceivedEventArgs
	{
		/// <summary>
		/// The received voice message.
		/// </summary>
		public Voice Voice;

		/// <summary>
		/// The user who sent the voice message.
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
		/// Contains audio from a telegram message
		/// </summary>
		/// <param name="msg">The message.</param>
		/// <param name="bot">The bot.</param>
		public VoiceMessageReceivedEventArgs(Message msg, User bot) {
			Voice = msg.Voice;
			Sender = msg.From;
			Bot = bot;
			ChatID = msg.Chat.Id;
		}
	}
}


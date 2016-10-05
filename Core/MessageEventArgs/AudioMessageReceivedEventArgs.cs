using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core.MessageEventArgs
{
	/// <summary>
	/// Args used by AudioReceivedEvent.
	/// </summary>
	public class AudioMessageReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// The audio message received.
		/// </summary>
		public Audio AudioMessage;

		/// <summary>
		/// The user who sent the audio.
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
		/// <param name="msg">The message</param>
		/// <param name="bot">The bot</param>
		public AudioMessageReceivedEventArgs(Message msg, User bot) {
			AudioMessage = msg.Audio;
			Sender = msg.From;
			Bot = bot;
			ChatID = msg.Chat.Id;
		}
	}
}


using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core.MessageEventArgs
{    /// <summary>
	/// The args used by VideoReceivedEvent.
	/// </summary>
	public class VideoMessageReceivedEventArgs
	{
		/// <summary>
		/// The video received.
		/// </summary>
		public Video Video;

		/// <summary>
		/// The user who sent the video.
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
		/// Contains Video from a telegram message
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="bot">The bot.</param>
		public VideoMessageReceivedEventArgs(Message msg, User bot) {
			Video = msg.Video;
			Sender = msg.From;
			Bot = bot;
			ChatID = msg.Chat.Id;
		}
	}
}


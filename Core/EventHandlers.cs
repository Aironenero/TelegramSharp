using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core
{
    /// <summary>
    /// Contains data from a telegram update (any media, for only text messages use TextMessageReceived)
    /// </summary>
    public class UpdateReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Message received (contains any media)
        /// </summary>
        public Message Message;

        /// <summary>
        /// Bot to this message belongs
        /// </summary>
        public User FromBot;

        /// <summary>
        /// Chat ID from where this message have been sent
        /// </summary>
        public long ChatID;

        /// <summary>
        /// Contains data from a telegram update (any media, for only text messages use TextMessageReceived)
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="bot">The bot</param>
        public UpdateReceivedEventArgs(Message msg, User bot)
        {
            Message = msg;
            FromBot = bot;
            ChatID = msg.Chat.Id;
        }
    }

    /// <summary>
    /// Contains text message from a telegram update (only thext, for any media use UpdateReceived)
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
        /// Bot to this message belongs
        /// </summary>
        public User FromBot;

        /// <summary>
        /// Chat ID from where this message have been sent
        /// </summary>
        public long ChatID;

        /// <summary>
        /// Contains text message from a telegram update (only thext, for any media use UpdateReceived)
        /// </summary>
        /// <param name="msg">The text message</param>
        /// <param name="bot">The bot</param>
        public TextMessageReceivedEventArgs(Message msg, User bot)
        {
            FromBot = bot;
            Sender = msg.From;
            MessageText = msg.Text;
            ChatID = msg.Chat.Id;
        }
    }
}

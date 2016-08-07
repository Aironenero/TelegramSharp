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
    /// Contains text message from a telegram update
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

    /// <summary>
    /// Args used by the AudioReceivedEvent.
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
        /// The constructor for the args.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="bot">The bot</param>
        public AudioMessageReceivedEventArgs(Message message, User bot)
        {
            AudioMessage = message.Audio;
            Sender = message.From;
            Bot = bot;
            ChatID = message.Chat.Id;
        }
    }

    /// <summary>
    /// Args used by the ContactReceivedEvent.
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
        /// The constructor for the args.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="bot">The bot.</param>
        public ContactMessageReceivedEventArgs(Message message, User bot)
        {
            Contact = message.Contact;
            Sender = message.From;
            Bot = bot;
            ChatID = message.Chat.Id;
        }
    }

    /// <summary>
    /// Args used by the DocumentReceivedEvent.
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
        /// The constructor for the args.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="bot">The bot.</param>
        public DocumentMessageReceivedEventArgs(Message message, User bot)
        {
            Document = message.Document;
            Sender = message.From;
            Bot = bot;
            ChatID = message.Chat.Id;
        }
    }

    /// <summary>
    /// The args used by the LocationReceivedEvent.
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
        /// The constructor for the args.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="bot">The bot.</param>
        public LocationMessageReceivedEventArgs(Message message, User bot)
        {
            Location = message.Location;
            Sender = message.From;
            Bot = bot;
            ChatID = message.Chat.Id;
        }
    }

    /// <summary>
    /// The args used by the PhotoReceivedEvent.
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
        /// The constructor for the args.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="bot">The bot.</param>
        public PhotoMessageReceivedEventArgs(Message message, User bot)
        {
            Photo = message.Photo;
            Sender = message.From;
            Bot = bot;
            ChatID = message.Chat.Id;
        }
    }

    /// <summary>
    /// The args used by the StickerReceivedEvent.
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
        /// The constructor for the args.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="bot">The bot.</param>
        public StickerMessageReceivedEventArgs(Message message, User bot)
        {
            Sticker = message.Sticker;
            Sender = message.From;
            Bot = bot;
            ChatID = message.Chat.Id;
        }
    }

    /// <summary>
    /// The args used by the VideoReceivedEvent.
    /// </summary>
    public class VideoMessageReceivedEventArgs : EventArgs
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
        /// The constructor for the args.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="bot">The bot.</param>
        public VideoMessageReceivedEventArgs(Message message, User bot)
        {
            Video = message.Video;
            Sender = message.From;
            Bot = bot;
            ChatID = message.Chat.Id;
        }
    }

    /// <summary>
    /// The args used by the VoiceReceivedEvent.
    /// </summary>
    public class VoiceMessageReceivedEventArgs : EventArgs
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
        /// The constructor for the args.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="bot">The bot.</param>
        public VoiceMessageReceivedEventArgs(Message message, User bot)
        {
            Voice = message.Voice;
            Sender = message.From;
            Bot = bot;
            ChatID = message.Chat.Id;
        }
    }
}

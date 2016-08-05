using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core
{
    public partial class MessageParser
    {


        /// <summary>
        /// Called when an telegram update (containing any media) is received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void UpdateReceivedHandler(object sender, UpdateReceivedEventArgs e);

        /// <summary>
        /// Called when an telegram update (containing any media) is received.
        /// </summary>
        public event UpdateReceivedHandler UpdateReceived;

        /// <summary>
        /// Called when an telegram update (containing any media) is received.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="bot">The bot</param>
        protected virtual void OnUpdateReceived(Message message, User bot)
        {
            UpdateReceived?.Invoke(this, new UpdateReceivedEventArgs(message, bot));
        }

        /// <summary>
        /// Called when an telegram update (containing only text) is received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void TextMessageReceived(object sender, TextMessageReceivedEventArgs e);

        /// <summary>
        ///
        /// </summary>
        public event TextMessageReceived TextMessageReceivedEvent;

        /// <summary>
        /// Called when an telegram update (containing only text) is received.
        /// </summary>
        /// <param name="msg">The text message</param>
        /// <param name="bot">The bot</param>
        protected virtual void OnTextMessageReceived(Message msg, User bot)
        {
            TextMessageReceivedEvent?.Invoke(this, new TextMessageReceivedEventArgs(msg, bot));
        }

        public delegate void AudioReceivedEventHandler(object sender, AudioMessageReceivedEventArgs args);
        public event AudioReceivedEventHandler AudioReceived;
        protected virtual void OnAudioReceived(User bot, Message message)
        {
            AudioReceived?.Invoke(this, new AudioMessageReceivedEventArgs(message, bot));
        }

        public delegate void ContactReceivedEventHandler(object sender, ContactMessageReceivedEventArgs args);
        public event ContactReceivedEventHandler ContactReceived;
        protected virtual void OnContactReceived(User bot, Message message)
        {
            ContactReceived?.Invoke(this, new ContactMessageReceivedEventArgs(message, bot));
        }

        public delegate void DocumentReceivedEventHandler(object sender, DocumentMessageReceivedEventArgs args);
        public event DocumentReceivedEventHandler DocumentReceived;
        protected virtual void OnDocumentReceived(User bot, Message message)
        {
            DocumentReceived?.Invoke(this, new DocumentMessageReceivedEventArgs(message, bot));
        }

        public delegate void LocationReceivedEventHandler(object sender, LocationMessageReceivedEventArgs args);
        public event LocationReceivedEventHandler LocationReceived;
        protected virtual void OnLocationReceived(User bot, Message message)
        {
            LocationReceived?.Invoke(this, new LocationMessageReceivedEventArgs(message, bot));
        }

        public delegate void PhotoReceivedEventHandler(object sender, PhotoMessageReceivedEventArgs args);
        public event PhotoReceivedEventHandler PhotoReceived;
        protected virtual void OnPhotoReceived(User bot, Message message)
        {
            PhotoReceived?.Invoke(this, new PhotoMessageReceivedEventArgs(message, bot));
        }

        public delegate void StickerReceivedEventHandler(object sender, StickerMessageReceivedEventArgs args);
        public event StickerReceivedEventHandler StickerReceived;
        protected virtual void OnStickerReceived(User bot, Message message)
        {
            StickerReceived?.Invoke(this, new StickerMessageReceivedEventArgs(message, bot));
        }

        public delegate void VideoReceivedEventHandler(object sender, VideoMessageReceivedEventArgs args);
        public event VideoReceivedEventHandler VideoReceived;
        protected virtual void OnVideoReceived(User bot, Message message)
        {
            VideoReceived?.Invoke(this, new VideoMessageReceivedEventArgs(message, bot));
        }

        public delegate void VoiceReceivedEventHandler(object sender, VoiceMessageReceivedEventArgs args);
        public event VoiceReceivedEventHandler VoiceReceived;
        protected virtual void OnVoiceReceived(User bot, Message message)
        {
            VoiceReceived?.Invoke(this, new VoiceMessageReceivedEventArgs(message, bot));
        }


    }
}

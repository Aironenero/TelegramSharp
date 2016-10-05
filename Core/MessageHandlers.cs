using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core {

    public partial class MessageParser {

        /// <summary>
        /// Called when an telegram update (containing any media) is received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void UpdateReceivedHandler(object sender, MessageEventArgs.UpdateReceivedEventArgs e);
        
        public event UpdateReceivedHandler UpdateReceived;

        /// <summary>
        /// Called when an telegram update (containing any media) is received.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="bot">The bot</param>
        public virtual void OnUpdateReceived(Message message, User bot, Update update) {
			UpdateReceived?.Invoke(this, new MessageEventArgs.UpdateReceivedEventArgs(update, bot));
        }

        /// <summary>
        /// Called when an telegram update (containing only text) is received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void TextMessageReceivedEventHandler(object sender, MessageEventArgs.TextMessageReceivedEventArgs e);

        /// <summary>
        ///
        /// </summary>
        public event TextMessageReceivedEventHandler TextMessageReceived;

        /// <summary>
        /// Called when an telegram update (containing only text) is received.
        /// </summary>
        /// <param name="msg">The text message</param>
        /// <param name="bot">The bot</param>
        protected virtual void OnTextMessageReceived(Message msg, User bot) {
			TextMessageReceived?.Invoke(this, new MessageEventArgs.TextMessageReceivedEventArgs(msg, bot));
        }

		public delegate void AudioReceivedEventHandler(object sender, MessageEventArgs.AudioMessageReceivedEventArgs args);

        public event AudioReceivedEventHandler AudioReceived;

        protected virtual void OnAudioReceived(User bot, Message message) {
			AudioReceived?.Invoke(this, new MessageEventArgs.AudioMessageReceivedEventArgs(message, bot));
        }

		public delegate void ContactReceivedEventHandler(object sender, MessageEventArgs.ContactMessageReceivedEventArgs args);

        public event ContactReceivedEventHandler ContactReceived;

        protected virtual void OnContactReceived(User bot, Message message) {
			ContactReceived?.Invoke(this, new MessageEventArgs.ContactMessageReceivedEventArgs(message, bot));
        }

        public delegate void DocumentReceivedEventHandler(object sender, MessageEventArgs.DocumentMessageReceivedEventArgs args);

        public event DocumentReceivedEventHandler DocumentReceived;

        protected virtual void OnDocumentReceived(User bot, Message message) {
			DocumentReceived?.Invoke(this, new MessageEventArgs.DocumentMessageReceivedEventArgs(message, bot));
        }

		public delegate void LocationReceivedEventHandler(object sender, MessageEventArgs.LocationMessageReceivedEventArgs args);

        public event LocationReceivedEventHandler LocationReceived;

        protected virtual void OnLocationReceived(User bot, Message message) {
			LocationReceived?.Invoke(this, new MessageEventArgs.LocationMessageReceivedEventArgs(message, bot));
        }

		public delegate void PhotoReceivedEventHandler(object sender, MessageEventArgs.PhotoMessageReceivedEventArgs args);

        public event PhotoReceivedEventHandler PhotoReceived;

        protected virtual void OnPhotoReceived(User bot, Message message) {
			PhotoReceived?.Invoke(this, new MessageEventArgs.PhotoMessageReceivedEventArgs(message, bot));
        }

		public delegate void StickerReceivedEventHandler(object sender, MessageEventArgs.StickerMessageReceivedEventArgs args);

        public event StickerReceivedEventHandler StickerReceived;

        protected virtual void OnStickerReceived(User bot, Message message) {
			StickerReceived?.Invoke(this, new MessageEventArgs.StickerMessageReceivedEventArgs(message, bot));
        }

		public delegate void VideoReceivedEventHandler(object sender, MessageEventArgs.VideoMessageReceivedEventArgs args);

        public event VideoReceivedEventHandler VideoReceived;

        protected virtual void OnVideoReceived(User bot, Message message) {
			VideoReceived?.Invoke(this, new MessageEventArgs.VideoMessageReceivedEventArgs(message, bot));
        }

		public delegate void VoiceReceivedEventHandler(object sender, MessageEventArgs.VoiceMessageReceivedEventArgs args);

        public event VoiceReceivedEventHandler VoiceReceived;

        protected virtual void OnVoiceReceived(User bot, Message message) {
			VoiceReceived?.Invoke(this, new MessageEventArgs.VoiceMessageReceivedEventArgs(message, bot));
        }
    }
}
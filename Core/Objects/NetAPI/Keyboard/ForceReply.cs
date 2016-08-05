namespace TelegramSharp.Core.Objects.NetAPI.Keyboard
{
    internal class ForceReply : IReplyMarkup
    {
        /// <summary>
        /// Upon receiving a message with this object, Telegram clients will display a reply interface to the user (act as if the user has selected the bot‘s message and tapped 'Reply').
        /// </summary>
        [JsonProperty(PropertyName = "force_reply")]
        public bool ForceRep = true;

        /// <summary>
        /// Returns true on whether the object is selective.
        /// </summary>
        [JsonProperty(PropertyName = "selective")]
        public bool Selective { get; set; }

        public string serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

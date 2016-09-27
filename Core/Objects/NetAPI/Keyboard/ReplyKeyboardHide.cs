using Newtonsoft.Json;

namespace TelegramSharp.Core.Objects.NetAPI.Keyboard {

    public class ReplyKeyboardHide : IReplyMarkup {

        /// <summary>
        /// Always true. This object hides a keyboard after being used.
        /// </summary>
        [JsonProperty(PropertyName = "hide_keyboard")]
        public bool HideKeyboard = true;

        /// <summary>
        /// Returns true if the Reply Markup is selective.
        /// </summary>
        [JsonProperty(PropertyName = "selective")]
        public bool Selective { get; set; }

        public string serialize() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
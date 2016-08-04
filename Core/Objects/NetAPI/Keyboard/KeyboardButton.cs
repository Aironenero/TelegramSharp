using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSharp.Core.Objects.NetAPI.Keyboard
{
    public class KeyboardButton
    {

        /// <summary>
        /// This is the text shown on the button. When pressed, a message is sent with the text of the button.
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Returns true if the button should reque
        /// </summary>
        [JsonProperty(PropertyName = "request_location")]
        public bool RequestLocation { get; set; }

        /// <summary>
        /// Returns true if the button should return a contact.
        /// </summary>
        [JsonProperty(PropertyName = "request_contact")]
        public bool RequestContact { get; set; }

    }
}

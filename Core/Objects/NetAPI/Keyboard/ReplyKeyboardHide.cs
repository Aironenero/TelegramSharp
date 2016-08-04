using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSharp.Core.Objects.NetAPI.Keyboard
{
    public class ReplyKeyboardHide : IReplyMarkup
    {
        [JsonProperty(PropertyName = "hide_keyboard")]
        public bool HideKeyboard = true;

        [JsonProperty(PropertyName = "selective")]
        public bool Selective { get; set; }

        public string serialize()
        {
            throw new NotImplementedException();
        }
    }
}

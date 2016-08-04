using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSharp.Core.Objects.NetAPI.Keyboard
{
    public class KeyboardRow
    {

        public List<KeyboardButton> Buttons = null;

        public KeyboardRow()
        {
            this.Buttons = new List<KeyboardButton>();
        }

        public void AddButtons(params KeyboardButton[] buttons)
        {
            Buttons.AddRange(buttons);
        }

        [JsonProperty]
        public KeyboardButton[] KeyboardButtonArray { get { return Buttons.ToArray(); } }

    }
}

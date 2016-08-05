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

        /// <summary>
        /// Creates a KeyboardRow object.
        /// </summary>
        public KeyboardRow()
        {
            this.Buttons = new List<KeyboardButton>();
        }

        /// <summary>
        /// Adds the buttons to the Row.
        /// </summary>
        /// <param name="buttons">The buttons to add.</param>
        public void AddButtons(params KeyboardButton[] buttons)
        {
            foreach(KeyboardButton button in buttons)
            {
                Buttons.Add(button);
            }
        }

        /// <summary>
        /// Returns an array version of the KeyboardButton list
        /// </summary>
        [JsonProperty]
        public KeyboardButton[] KeyboardButtonArray { get { return Buttons.ToArray(); } }

    }
}

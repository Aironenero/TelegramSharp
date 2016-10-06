//TelegramSharp - A library to make telegram bots
//Copyright (C) 2016  Samuele Lorefice, Niccolò Mattei, Fabio De Simone
//
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TelegramSharp.Core.Objects.NetAPI.Keyboard {

    public class KeyboardRow {
        public List<KeyboardButton> Buttons = null;

        /// <summary>
        /// Creates a KeyboardRow object.
        /// </summary>
        public KeyboardRow() {
            this.Buttons = new List<KeyboardButton>();
        }

        /// <summary>
        /// Adds the buttons to the Row.
        /// </summary>
        /// <param name="buttons">The buttons to add.</param>
        public void AddButtons(params KeyboardButton[] buttons) {
            foreach (KeyboardButton button in buttons) {
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
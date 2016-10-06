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

namespace TelegramSharp.Core.Objects.NetAPI.Keyboard {

    public class KeyboardButton {

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
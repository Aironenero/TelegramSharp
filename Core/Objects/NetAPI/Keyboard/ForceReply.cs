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

    internal class ForceReply : IReplyMarkup {

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

        public string serialize() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
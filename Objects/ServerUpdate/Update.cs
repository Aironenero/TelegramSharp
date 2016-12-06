//TelegramSharp - A library to make telegram bots
//Copyright (C) 2016  Samuele Lorefice, Niccolò Mattei
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
using System.Runtime.Serialization;

namespace TelegramSharp.Objects
{
    /// <summary>
    /// Update.
    /// </summary>
    [DataContract]
    public class Update
    {
        /// <summary>
        /// Gets or sets the update identifier.
        /// </summary>
        /// <value>The update identifier.</value>
        [DataMember(Name = "update_id")]
        public int UpdateId { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [DataMember(Name = "message", IsRequired = false)]
        public Message Message { get; set; }

        /// <summary>
        /// An edited message.
        /// </summary>
        [DataMember(Name = "edited_message", IsRequired = false)]
        public Message EditedMessage { get; set; }

        /// <summary>
        /// Gets or sets the bot info.
        /// </summary>
        /// <value>The bot info.</value>
        [DataMember(Name = "bot_info", IsRequired = false)]
        public User BotInfo { get; set; }
    }
}

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
using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {

    public class CallbackQuery {

        [DataMember(Name = "id", IsRequired = true)]
        public string Id { get; set; }

        [DataMember(Name = "from", IsRequired = true)]
        public User From { get; set; }

        [DataMember(Name = "message", IsRequired = false)]
        public Message Message { get; set; }

        [DataMember(Name = "inline_message_id", IsRequired = false)]
        public string InlineMessageId { get; set; }

        [DataMember(Name = "data", IsRequired = true)]
        public string Data { get; set; }
    }
}
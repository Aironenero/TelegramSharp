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

    [DataContract]
    public class MessageEntity {

        [DataMember(Name = "type", IsRequired = true)]
        public string Type { get; set; }

        [DataMember(Name = "offset", IsRequired = true)]
        public int Offset { get; set; }

        [DataMember(Name = "length", IsRequired = true)]
        public int Lenght { get; set; }

        [DataMember(Name = "url", IsRequired = false)]
        public string Url { get; set; }

        [DataMember(Name = "user", IsRequired = false)]
        public User User { get; set; }
    }
}
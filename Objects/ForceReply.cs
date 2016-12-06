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
    /// Force reply.
    /// </summary>
    [DataContract]
    public class ForceReply
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="Core.Objects.NetAPI.ForceReply"/> force reply.
        /// </summary>
        /// <value><c>true</c> if force reply; otherwise, <c>false</c>.</value>
        [DataMember(Name = "force_reply")]
        public bool forceReply { get { return true; } }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ForceReply"/> is selective.
        /// </summary>
        /// <value><c>true</c> if selective; otherwise, <c>false</c>.</value>
        [DataMember(Name = "name", IsRequired = false)]
        public bool Selective { get; set; }
    }
}

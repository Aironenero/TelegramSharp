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
    /// A server update containing the bot user informations.
    /// </summary>
    [DataContract]
    public class GetMeServerUpdate
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.GetMeServerUpdate"/> is ok.
        /// </summary>
        /// <value><c>true</c> if ok; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool Ok { get; set; }

        /// <summary>
        /// Gets or sets the get me.
        /// </summary>
        /// <value>The get me.</value>
        [DataMember(Name = "result", IsRequired = false)]
        public User GetMe { get; set; }
    }
}

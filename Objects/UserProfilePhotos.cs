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
    /// User profile photos.
    /// </summary>
    [DataContract]
    public class UserProfilePhotos
    {
        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>The total count.</value>
        [DataMember(Name = "total_count")]
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the photos.
        /// </summary>
        /// <value>The photos.</value>
        [DataMember(Name = "photos")]
        public PhotoSize[][] Photos { get; set; }
    }
}

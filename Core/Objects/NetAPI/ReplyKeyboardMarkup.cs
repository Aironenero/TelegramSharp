//TelegramSharp - A library to make telegram bots
//Copyright (C) 2016  Samuele Lorefice
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

namespace TelegramSharp.Core.Objects.NetAPI
{
    /// <summary>
    /// Reply keyboard markup.
    /// </summary>
    [DataContract]
    public class ReplyKeyboardMarkup
    {
        /// <summary>
        /// Gets or sets the keyboard.
        /// </summary>
        /// <value>The keyboard.</value>
        [DataMember(Name = "keyboard")]
        public string[][] Keyboard { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ReplyKeyboardMarkup"/> resize keyboard.
        /// </summary>
        /// <value><c>true</c> if resize keyboard; otherwise, <c>false</c>.</value>
        [DataMember(Name = "resize_keyboard", IsRequired = false)]
        public bool ResizeKeyboard { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ReplyKeyboardMarkup"/> one time keyboard.
        /// </summary>
        /// <value><c>true</c> if one time keyboard; otherwise, <c>false</c>.</value>
        [DataMember(Name = "one_time_keyboard", IsRequired = false)]
        public bool OneTimeKeyboard { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ReplyKeyboardMarkup"/> is selective.
        /// </summary>
        /// <value><c>true</c> if selective; otherwise, <c>false</c>.</value>
        [DataMember(Name = "selective", IsRequired = false)]
        public bool Selective { get; set; }
    }
}

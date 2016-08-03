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
    /// Reply keyboard hide.
    /// </summary>
    [DataContract]
    public class ReplyKeyboardHide
    {
        [DataMember(Name = "hide_keyboard")]
        private bool _hideKeyboard = true;

        [DataMember(Name = "selective", IsRequired = false)]
        private bool _selective;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ReplyKeyboardHide"/> hide keyboard.
        /// </summary>
        /// <value><c>true</c> if hide keyboard; otherwise, <c>false</c>.</value>
        public bool HideKeyboard
        {
            get
            {
                return _hideKeyboard;
            }

            set
            {
                _hideKeyboard = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ReplyKeyboardHide"/> is selective.
        /// </summary>
        /// <value><c>true</c> if selective; otherwise, <c>false</c>.</value>
        public bool Selective
        {
            get
            {
                return _selective;
            }

            set
            {
                _selective = value;
            }
        }
    }
}

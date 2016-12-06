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
    /// Message server update.
    /// </summary>
    [DataContract]
    public class MessageServerUpdate
    {
        [DataMember(Name = "ok")]
        private bool _ok;

        [DataMember(Name = "result", IsRequired = false)]
        private Update[] _result;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.MessageServerUpdate"/> is ok.
        /// </summary>
        /// <value><c>true</c> if ok; otherwise, <c>false</c>.</value>
        public bool Ok
        {
            get
            {
                return _ok;
            }

            set
            {
                _ok = value;
            }
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public Update[] Result
        {
            get
            {
                return _result;
            }

            set
            {
                _result = value;
            }
        }
    }
}

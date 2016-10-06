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
using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core.MessageEventArgs
{
    /// <summary>
    /// The args used by UpdateReceived.
    /// </summary>
	public class UpdateReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// Message received (contains any media)
		/// </summary>
		public Update Update;

		/// <summary>
		/// The bot which received the message.
		/// </summary>
		public User Bot;

		/// <summary>
		/// Contains data from a telegram update (any media, for only text messages use TextMessageReceived)
		/// </summary>
		/// <param name="bot">The bot</param>
		/// <param name="upd">The Update</param>
		public UpdateReceivedEventArgs(Update upd, User bot) {
			Bot = bot;
			Update = upd;
		}
	}
}



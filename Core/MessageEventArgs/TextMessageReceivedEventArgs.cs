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
	/// Args used by TextMessageReceived
	/// </summary>
	public class TextMessageReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// Text of the message
		/// </summary>
		public string MessageText;

		/// <summary>
		/// Sender of the message
		/// </summary>
		public User Sender;

		/// <summary>
		/// Bot which received the message
		/// </summary>
		public User Bot;

		/// <summary>
		/// Chat ID from where this message have been sent
		/// </summary>
		public long ChatID;


		/// <summary>
		/// Contains text message from a telegram update (only thext, for any media use UpdateReceived)
		/// </summary>
		/// <param name="msg">The text message</param>
		/// <param name="bot">The bot</param>
		public TextMessageReceivedEventArgs(Message msg, User bot) {
			Bot = bot;
			Sender = msg.From;
			MessageText = msg.Text;
			ChatID = msg.Chat.Id;
		}
	}
}		




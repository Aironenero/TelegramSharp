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
	/// Args used by DocumentReceivedEvent.
	/// </summary>
	public class DocumentMessageReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// The document received.
		/// </summary>
		public Document Document;

		/// <summary>
		/// The user who sent the document.
		/// </summary>
		public User Sender;

		/// <summary>
		/// The bot which received the message.
		/// </summary>
		public User Bot;

		/// <summary>
		/// The ChatID of the chat where the message was sent.
		/// </summary>
		public long ChatID;

		/// <summary>
		/// Contains a document from a telegram message.
		/// </summary>
		/// <param name="msg">The message.</param>
		/// <param name="bot">The bot.</param>
		public DocumentMessageReceivedEventArgs(Message msg, User bot) {
			Document = msg.Document;
			Sender = msg.From;
			Bot = bot;
			ChatID = msg.Chat.Id;
		}
	}
}


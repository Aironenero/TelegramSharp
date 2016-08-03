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
using System;
using System.Text.RegularExpressions;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core
{
    /// <summary>
    /// Message parser.
    /// </summary>
    public class MessageParser
    {
        /// <summary>
        /// The parsed messages count.
        /// </summary>
        public int parsedMessagesCount = 0;

        /// <summary>
        /// The commands parsed count.
        /// </summary>
        public int commandsParsed = 0;

        /// <summary>
        /// Called when an telegram update (containing any media) is received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void UpdateReceivedHandler(object sender, UpdateReceivedEventArgs e);

        /// <summary>
        /// Called when an telegram update (containing any media) is received.
        /// </summary>
        public event UpdateReceivedHandler UpdateReceived;

        /// <summary>
        /// Called when an telegram update (containing any media) is received.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="bot">The bot</param>
        protected virtual void OnUpdateReceived(Message message, User bot)
        {
            UpdateReceived?.Invoke(this, new UpdateReceivedEventArgs(message, bot));
        }

        /// <summary>
        /// Called when an telegram update (containing only text) is received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void TextMessageReceived(object sender, TextMessageReceivedEventArgs e);

        /// <summary>
        ///
        /// </summary>
        public event TextMessageReceived TextMessageReceivedEvent;

        /// <summary>
        /// Called when an telegram update (containing only text) is received.
        /// </summary>
        /// <param name="msg">The text message</param>
        /// <param name="bot">The bot</param>
        protected virtual void OnTextMessageReceived(Message msg, User bot)
        {
            TextMessageReceivedEvent?.Invoke(this, new TextMessageReceivedEventArgs(msg, bot));
        }

        private static long ToUnixTime(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        }

        /// <summary>
        /// Parses the message.
        /// </summary>
        /// <param name="msg">Message to parse.</param>
        /// <param name="bot">Bot that should parse the message.</param>
        public void ParseMessage(Message msg, TelegramService bot)
        {
            parsedMessagesCount++;
            if (msg.Text != null && msg.Date >= ToUnixTime(DateTime.UtcNow) - 120)
            {
                OnUpdateReceived(msg, bot.BotIdentity);
                OnTextMessageReceived(msg, bot.BotIdentity);
            }
        }

        /// <summary>
        /// Check the presence of a trigger in the string
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="msg"></param>
        /// <param name="bot"></param>
        /// <param name="onlyCommand"></param>
        /// <returns></returns>
        public bool CheckForString(string trigger, string msg, TelegramService bot, bool onlyCommand = false)
        {
            string _trigger = trigger.ToLower();
            string _msg = msg.ToLower();
            Regex alone = new Regex(String.Format(@"^\/{0}", _trigger), RegexOptions.IgnoreCase);
            if (alone.IsMatch(_msg))
                return true;
            Regex alonePlusUser = new Regex(String.Format(@"^\/({0})({1})", _trigger, "@" + bot.BotIdentity.Username), RegexOptions.IgnoreCase);
            if (alonePlusUser.IsMatch(_msg))
                return true;
            if (!onlyCommand)
            {
                Regex singleWord = new Regex(String.Format(@"\b({0})\b", _trigger));
                if (singleWord.IsMatch(_msg))
                    return true;
            }
            return false;
        }
    }
}

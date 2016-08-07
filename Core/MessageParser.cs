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
using System;
using System.Text.RegularExpressions;
using TelegramSharp.Core;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core
{
    /// <summary>
    /// Message parser.
    /// </summary>
    public partial class MessageParser
    {
        /// <summary>
        /// The parsed messages count.
        /// </summary>
        public int parsedMessagesCount = 0;

        /// <summary>
        /// The commands parsed count.
        /// </summary>
        public int commandsParsed = 0;

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
            OnUpdateReceived(msg, bot.BotIdentity);
            if (msg.Date >= ToUnixTime(DateTime.UtcNow) - 120)
            {
                if (msg.Text != null)
                {
                    OnTextMessageReceived(msg, bot.BotIdentity);
                }
                else if (msg.Audio != null)
                {
                    OnAudioReceived(bot.BotIdentity, msg);
                } else if(msg.Contact != null)
                {
                    OnContactReceived(bot.BotIdentity, msg);
                } else if(msg.Document != null)
                {
                    OnDocumentReceived(bot.BotIdentity, msg);
                } else if(msg.Location != null) 
                {
                    OnLocationReceived(bot.BotIdentity, msg);
                } else if(msg.Photo != null)
                {
                    OnPhotoReceived(bot.BotIdentity, msg);
                } else if(msg.Sticker != null)
                {
                    OnStickerReceived(bot.BotIdentity, msg);
                } else if(msg.Video != null)
                {
                    OnVideoReceived(bot.BotIdentity, msg);
                } else if(msg.Voice != null)
                {
                    OnVoiceReceived(bot.BotIdentity, msg);
                }
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

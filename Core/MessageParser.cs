//TelegramSharp - A library to make telegram bots
//Copyright (C) 2016  Samuele Lorefice, Niccol� Mattei
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

namespace TelegramSharp.Core {

    /// <summary>
    /// Message parser.
    /// </summary>
    public partial class MessageParser {

        /// <summary>
        /// The parsed messages count.
        /// </summary>
        public int parsedMessagesCount = 0;

        /// <summary>
        /// The commands parsed count.
        /// </summary>
        public int commandsParsed = 0;

        private static long ToUnixTime(DateTime date) {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        }

        /// <summary>
        /// Parses the message.
        /// </summary>
        /// <param name="upd">Message to parse.</param>
        /// <param name="bot">Bot that should parse the message.</param>
        public void ParseMessage(Update upd, TelegramService bot) {
            parsedMessagesCount++;
            OnUpdateReceived(upd.Message, bot.BotIdentity, upd);
            //TODO => add venue and other missing callbacks
            if (upd?.Message?.Date != null && upd.Message.Date >= ToUnixTime(DateTime.UtcNow) - 120) {
                if (upd.Message.Text != null) {
                    OnTextMessageReceived(upd.Message, bot.BotIdentity);
                }
                else if (upd.Message.Audio != null) {
                    OnAudioReceived(bot.BotIdentity, upd.Message);
                }
                else if (upd.Message.Contact != null) {
                    OnContactReceived(bot.BotIdentity, upd.Message);
                }
                else if (upd.Message.Document != null) {
                    OnDocumentReceived(bot.BotIdentity, upd.Message);
                }
                else if (upd.Message.Location != null) {
                    OnLocationReceived(bot.BotIdentity, upd.Message);
                }
                else if (upd.Message.Photo != null) {
                    OnPhotoReceived(bot.BotIdentity, upd.Message);
                }
                else if (upd.Message.Sticker != null) {
                    OnStickerReceived(bot.BotIdentity, upd.Message);
                }
                else if (upd.Message.Video != null) {
                    OnVideoReceived(bot.BotIdentity, upd.Message);
                }
                else if (upd.Message.Voice != null) {
                    OnVoiceReceived(bot.BotIdentity, upd.Message);
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
        public bool CheckForString(string trigger, string msg, TelegramService bot, bool onlyCommand = false) {
            string _trigger = trigger.ToLower();
            string _msg = msg.ToLower();
            Regex alone = new Regex(String.Format(@"^\/{0}", _trigger), RegexOptions.IgnoreCase);
            if (alone.IsMatch(_msg))
                return true;
            Regex alonePlusUser = new Regex(String.Format(@"^\/({0})({1})", _trigger, "@" + bot.BotIdentity.Username), RegexOptions.IgnoreCase);
            if (alonePlusUser.IsMatch(_msg))
                return true;
            if (!onlyCommand) {
                Regex singleWord = new Regex(String.Format(@"\b({0})\b", _trigger));
                if (singleWord.IsMatch(_msg))
                    return true;
            }
            return false;
        }
    }
}
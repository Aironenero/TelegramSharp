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
using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects {

    /// <summary>
    /// Message parse mode.
    /// </summary>
    public enum ParseMode {

        /// <summary>
        /// Parse the message as containing markdown
        /// </summary>
        MarkDown,

        /// <summary>
        /// Parse the message as containing HTML
        /// </summary>
        HTML
    }

    /// <summary>
    /// Outgoing message.
    /// </summary>
    [DataContract]
    public class OutgoingMessage {

        [DataMember(Name = "chat_id")]
        private int _chatId;

        [DataMember(Name = "text")]
        private string _text;

        [DataMember(Name = "parse_mode")]
        private ParseMode _parseMode;

        [DataMember(Name = "disable_web_page_preview")]
        private bool _disableWebPagePreview;

        [DataMember(Name = "reply_to_message_id")]
        private int _replyToMessageId;

        /// <summary>
        /// Gets or sets the chat identifier.
        /// </summary>
        /// <value>The chat identifier.</value>
        public int ChatId {
            get {
                return _chatId;
            }

            set {
                _chatId = value;
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text {
            get {
                return _text;
            }

            set {
                _text = value;
            }
        }

        /// <summary>
        /// Gets or sets the parse mode.
        /// </summary>
        /// <value>The parse mode.</value>
        public string ParseMode {
            get {
                if (_parseMode == Objects.ParseMode.MarkDown)
                    return _parseMode.ToString();
                return "";
            }

            set {
                _parseMode = (ParseMode)Enum.Parse(typeof(ParseMode), value, true);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Core.Objects.OutgoingMessage"/> disable web page preview.
        /// </summary>
        /// <value><c>true</c> if disable web page preview; otherwise, <c>false</c>.</value>
        public bool DisableWebPagePreview {
            get {
                return _disableWebPagePreview;
            }

            set {
                _disableWebPagePreview = value;
            }
        }

        /// <summary>
        /// Gets or sets the reply to message identifier.
        /// </summary>
        /// <value>The reply to message identifier.</value>
        public int ReplyToMessageId {
            get {
                return _replyToMessageId;
            }

            set {
                _replyToMessageId = value;
            }
        }
    }
}
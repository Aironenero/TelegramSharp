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

namespace TelegramSharp.Objects
{
    /// <summary>
    /// Message.
    /// </summary>
    [DataContract]
    public class Message
    {
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>The message identifier.</value>
        [DataMember(Name = "message_id")]
        public int MessageId { get; set; }

        /// <summary>
        /// Gets or sets who sent the message.
        /// </summary>
        /// <value>From.</value>
        [DataMember(Name = "from")]
        public User From { get; set; }

        /// <summary>
        /// Gets or sets the date in wich the message have been sent.
        /// </summary>
        /// <value>The date.</value>
        [DataMember(Name = "date")]
        public int Date { get; set; }

        /// <summary>
        /// Gets or sets the chat.
        /// </summary>
        /// <value>The chat.</value>
        [DataMember(Name = "chat")]
        public Chat Chat { get; set; }

        /// <summary>
        /// Gets or sets from who this message have been forwarded.
        /// </summary>
        /// <value>The forward from.</value>
        [DataMember(Name = "forward_from", IsRequired = false)]
        public User ForwardFrom { get; set; }

        /// <summary>
        /// Gets or sets the forward date.
        /// </summary>
        /// <value>The forward date.</value>
        [DataMember(Name = "forward_date", IsRequired = false)]
        public int ForwardDate { get; set; }

        /// <summary>
        /// Gets or sets the reply to message.
        /// </summary>
        /// <value>The reply to message.</value>
        [DataMember(Name = "reply_to_message", IsRequired = false)]
        public Message ReplyToMessage { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [DataMember(Name = "text", IsRequired = false)]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the audio.
        /// </summary>
        /// <value>The audio.</value>
        [DataMember(Name = "audio", IsRequired = false)]
        public Audio Audio { get; set; }

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        /// <value>The document.</value>
        [DataMember(Name = "document", IsRequired = false)]
        public Document Document { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        /// <value>The photo.</value>
        [DataMember(Name = "photo", IsRequired = false)]
        public PhotoSize[] Photo { get; set; }

        /// <summary>
        /// Gets or sets the sticker.
        /// </summary>
        /// <value>The sticker.</value>
        [DataMember(Name = "sticker", IsRequired = false)]
        public Sticker Sticker { get; set; }

        /// <summary>
        /// Gets or sets the video.
        /// </summary>
        /// <value>The video.</value>
        [DataMember(Name = "video", IsRequired = false)]
        public Video Video { get; set; }

        /// <summary>
        /// Gets or sets the voice.
        /// </summary>
        /// <value>The voice.</value>
        [DataMember(Name = "voice", IsRequired = false)]
        public Voice Voice { get; set; }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        [DataMember(Name = "caption", IsRequired = false)]
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>The contact.</value>
        [DataMember(Name = "contact", IsRequired = false)]
        public Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [DataMember(Name = "location", IsRequired = false)]
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the new chat participant.
        /// </summary>
        /// <value>The new chat participant.</value>
        [DataMember(Name = "new_chat_partecipant", IsRequired = false)]
        public User NewChatParticipant { get; set; }

        /// <summary>
        /// Gets or sets the left chat participant.
        /// </summary>
        /// <value>The left chat participant.</value>
        [DataMember(Name = "left_chat_partecipant", IsRequired = false)]
        public User LeftChatParticipant { get; set; }

        /// <summary>
        /// Gets or sets the new chat title.
        /// </summary>
        /// <value>The new chat title.</value>
        [DataMember(Name = "new_chat_title", IsRequired = false)]
        public string NewChatTitle { get; set; }

        /// <summary>
        /// Gets or sets the new chat photo.
        /// </summary>
        /// <value>The new chat photo.</value>
        [DataMember(Name = "new_chat_photo", IsRequired = false)]
        public PhotoSize[] NewChatPhoto { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.Message"/> deleted the chat photo.
        /// </summary>
        /// <value><c>true</c> if delete chat photo; otherwise, <c>false</c>.</value>
        [DataMember(Name = "delete_chat_photo", IsRequired = false)]
        public bool DeleteChatPhoto { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this group chat have been created.
        /// </summary>
        /// <value><c>true</c> if group chat created; otherwise, <c>false</c>.</value>
        [DataMember(Name = "group_chat_created", IsRequired = false)]
        public bool GroupChatCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this super group chat have been created.
        /// </summary>
        /// <value><c>true</c> if super group chat created; otherwise, <c>false</c>.</value>
        [DataMember(Name = "super_group_chat_created", IsRequired = false)]
        public bool SuperGroupChatCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this channel chat have been created.
        /// </summary>
        /// <value><c>true</c> if channel chat created; otherwise, <c>false</c>.</value>
        [DataMember(Name = "channel_chat_created", IsRequired = false)]
        public bool ChannelChatCreated { get; set; }

        /// <summary>
        /// Gets or sets the migrate to chat identifier.
        /// </summary>
        /// <value>The migrate to chat identifier.</value>
        [DataMember(Name = "migrate_to_chat_id", IsRequired = false)]
        public Int64 MigrateToChatId { get; set; }

        /// <summary>
        /// Gets or sets the migrate from chat identifier.
        /// </summary>
        /// <value>The migrate from chat identifier.</value>
        [DataMember(Name = "migrate_from_chat_id", IsRequired = false)]
        public int MigrateFromChatId { get; set; }
    }
}

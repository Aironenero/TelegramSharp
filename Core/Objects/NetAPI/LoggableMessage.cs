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

namespace TelegramSharp.Core.Objects.NetAPI
{
    /// <summary>
    /// Loggable message.
    /// </summary>
    public class LoggableMessage : Message
    {
        /// <summary>
        /// Signs if the message have been logged.
        /// </summary>
        public bool Logged = false;

        /// <summary>
        /// Bot that have received this message.
        /// </summary>
        public User FromBot = new User();

        /// <summary>
        /// Initializes a new instance of the <see cref="Core.Objects.NetAPI.LoggableMessage"/> class.
        /// </summary>
        /// <param name="msg">Message to log.</param>
        /// <param name="bot">Bot that received this message.</param>
        public LoggableMessage(Message msg, User bot)
        {
            MessageId = msg.MessageId;
            From = msg.From;
            Date = msg.Date;
            Chat = msg.Chat;
            ForwardFrom = msg.ForwardFrom;
            ForwardDate = msg.ForwardDate;
            ReplyToMessage = msg.ReplyToMessage;
            Text = msg.Text;
            Audio = msg.Audio;
            Document = msg.Document;
            Photo = msg.Photo;
            Sticker = msg.Sticker;
            Video = msg.Video;
            Voice = msg.Voice;
            Caption = msg.Caption;
            Contact = msg.Contact;
            Location = msg.Location;
            NewChatParticipant = msg.NewChatParticipant;
            LeftChatParticipant = msg.LeftChatParticipant;
            NewChatTitle = msg.NewChatTitle;
            NewChatPhoto = msg.NewChatPhoto;
            DeleteChatPhoto = msg.DeleteChatPhoto;
            GroupChatCreated = msg.GroupChatCreated;
            SuperGroupChatCreated = msg.SuperGroupChatCreated;
            ChannelChatCreated = msg.ChannelChatCreated;
            MigrateToChatId = msg.MigrateToChatId;
            MigrateFromChatId = msg.MigrateFromChatId;

            Logged = false;
            FromBot = bot;
        }
    }
}

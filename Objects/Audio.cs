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
    /// Audio.
    /// </summary>
    [DataContract]
    public class Audio
    {
        /// <summary>
        /// Gets or sets the file identifier.
        /// </summary>
        /// <value>The file identifier.</value>
        [DataMember(Name = "file_id")]
        public string FileId { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        [DataMember(Name = "duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the performer.
        /// </summary>
        /// <value>The performer.</value>
        [DataMember(Name = "performer", IsRequired = false)]
        public string Performer { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataMember(Name = "title", IsRequired = false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>The type of the MIME.</value>
        [DataMember(Name = "mime_type", IsRequired = false)]
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the size of the file.
        /// </summary>
        /// <value>The size of the file.</value>
        [DataMember(Name = "file_size", IsRequired = false)]
        public int FileSize { get; set; }
    }
}

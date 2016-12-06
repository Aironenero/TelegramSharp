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
    /// Video.
    /// </summary>
    [DataContract]
    public class Video
    {
        /// <summary>
        /// Gets or sets the file identifier.
        /// </summary>
        /// <value>The file identifier.</value>
        [DataMember(Name = "file_id")]
        public string FileId { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        [DataMember(Name = "width")]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        [DataMember(Name = "height")]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        [DataMember(Name = "duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the thumb.
        /// </summary>
        /// <value>The thumb.</value>
        [DataMember(Name = "thumb", IsRequired = false)]
        public PhotoSize Thumb { get; set; }

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

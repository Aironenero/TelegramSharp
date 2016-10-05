using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
    [DataContract]
    public class MessageEntity
    {
        [DataMember(Name = "type", IsRequired = true)]
        public string Type { get; set; }

        [DataMember(Name = "offset", IsRequired = true)]
        public int Offset { get; set; }

        [DataMember(Name = "length",IsRequired = true)]
        public int Lenght { get; set; }

        [DataMember(Name = "url", IsRequired = false)]
        public string Url { get; set; }

        [DataMember(Name = "user", IsRequired = false)]
        public User User { get; set; }
    }
}

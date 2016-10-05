using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
    [DataContract]
    public class ChatMember {
        [DataMember(Name = "user")]
        public User User { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}

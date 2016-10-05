using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {

    [DataContract]
    public class ResponseParameters {

        [DataMember(Name = "migrate_to_chat_id", IsRequired = false)]
        public int MigrateToChatId { get; set; }

        [DataMember(Name = "retry_after", IsRequired = false)]
        public int RetryAfter { get; set; }
    }
}
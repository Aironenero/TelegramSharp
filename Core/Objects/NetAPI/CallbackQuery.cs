using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSharp.Core.Objects.NetAPI
{
    public class CallbackQuery
    {
        
        [DataMember(Name = "id", IsRequired = true)]
        public string Id { get; set; }
        [DataMember(Name = "from", IsRequired = true)]
        public User From { get; set; }
        [DataMember(Name = "message", IsRequired = false)]
        public Message Message { get; set; }
        [DataMember(Name = "inline_message_id", IsRequired = false)]
        public string InlineMessageId { get; set; }
        [DataMember(Name = "data", IsRequired = true)]
        public string Data { get; set; }

    }
}

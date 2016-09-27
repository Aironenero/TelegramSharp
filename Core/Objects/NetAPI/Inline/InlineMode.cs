using Newtonsoft.Json;
using System;

namespace TelegramSharp.Core.Objects.NetAPI.Inline {

    public class InlineQuery {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "sender")]
        public User Sender { get; set; }

        [JsonProperty(PropertyName = "location", Required = Required.DisallowNull)]
        public Location Location { get; set; }

        [JsonProperty(PropertyName = "query")]
        public string Query { get; set; }

        [JsonProperty(PropertyName = "offset")]
        public string Offset { get; set; }
    }

    public class AnswerInlineQuery {

        [JsonProperty(PropertyName = "inline_query_id")]
        public string InlineQueryId { get; set; }

        //TODO => [JsonProperty(PropertyName = "results")]
        //TODO => results public InlineQueryResult[] Results { get; set; }
        [JsonProperty(PropertyName = "cache_time")]
        public int CacheTime { get; set; }

        [JsonProperty(PropertyName = "is_personal")]
        public bool IsPersonal { get; set; }

        [JsonProperty(PropertyName = "next_offset")]
        public string NextOffset { get; set; }

        [JsonProperty(PropertyName = "switch_pm_text")]
        public string SwitchPmText { get; set; }

        [JsonProperty(PropertyName = "switch_pm_parameter")]
        public string SwitchPmParameter { get; set; }
    }

    public class InlineQueryResult {
        public string Type { get; set; }
        public Int64 Id { get; set; }
        public InputMessageContent InputMessageContent { get; set; }
    }
}
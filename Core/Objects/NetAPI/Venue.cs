using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
    [DataContract]
    public class Venue {
        [DataMember(Name = "location")]
        public Location Location { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name =  "address")]
        public string Address { get; set; }

        [DataMember(Name = "foursquare_id", IsRequired = false)]
        public string FourSquareID { get; set; }

    }
}

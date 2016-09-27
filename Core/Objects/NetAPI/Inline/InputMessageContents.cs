namespace TelegramSharp.Core.Objects.NetAPI.Inline {

    public interface InputMessageContent {
    }

    public class InputTextMessageContent : InputMessageContent {
        public string MessageText { get; set; }

        //optional
        public string ParseMode { get; set; }

        //optional
        public bool DisableWebPagePreview { get; set; }
    }

    public class InputLocationMessageContent : InputMessageContent {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }

    public class InputVenueMessageContent : InputLocationMessageContent {
        public string Title { get; set; }
        public string Address { get; set; }

        //optional
        public string ForsquareId { get; set; }
    }

    public class InputContactMessageContent : InputMessageContent {
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }

        //optional
        public string LastName { get; set; }
    }
}
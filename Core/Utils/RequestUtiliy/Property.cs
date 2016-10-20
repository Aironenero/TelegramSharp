namespace TelegramSharp.Core.Utils
{
    public class Property {
        public string Value { get; set; }
        public PropertyValue PropertyValue { get; set; }

        public Property(string Value, PropertyValue PropertyValue) {
            this.Value = Value;
            this.PropertyValue = PropertyValue;
        }
    }
}
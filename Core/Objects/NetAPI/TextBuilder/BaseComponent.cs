namespace TelegramSharp.Core.Objects.NetAPI.TextBuilder {

    public interface IBaseComponent {

        /// <summary>
        /// Makes the message with the markup. If no markup is applied, it will return a string with no markup.
        /// </summary>
        /// <returns>Returns the string with markup.</returns>
        string Make();

        /// <summary>
        /// Gets the ParsingMode used to parse the message.
        /// </summary>
        /// <returns></returns>
        ParsingMode GetParsingMode();
    }
}
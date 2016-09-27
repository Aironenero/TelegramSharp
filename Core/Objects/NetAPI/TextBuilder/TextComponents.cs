using System.Collections.Generic;

namespace TelegramSharp.Core.Objects.NetAPI.TextBuilder {

    /// <summary>
    /// TextComponent is the class that represents a complex message with markup on other stuff.
    /// </summary>
    public class TextComponent : IBaseComponent {

        /// <summary>
        /// The parsing used to parse the message.
        /// </summary>
        public ParsingMode Mode { get; set; }

        private List<TextArea> Elements = null;

        public TextComponent(ParsingMode Mode = ParsingMode.NONE, params TextArea[] Elements) {
            this.Mode = Mode;
            this.Elements = new List<TextArea>();
            this.Elements.AddRange(Elements);
        }

        public string Make() {
            string Res = "";
            foreach (TextArea Element in Elements) {
                Res += Element.Make(Mode);
            }
            return Res;
        }

        public ParsingMode GetParsingMode() {
            return Mode;
        }
    }

    /// <summary>
    /// With RawTextComponent you can type your custom message and apply the markup yourself. Just select the parsing mode.
    /// </summary>
    public class RawTextComponent : IBaseComponent {
        public ParsingMode Mode { get; set; }
        public string RawText { get; set; }

        public RawTextComponent(ParsingMode Mode, string Text) {
            this.Mode = Mode;
            this.RawText = Text;
        }

        public string Make() {
            return RawText;
        }

        public ParsingMode GetParsingMode() {
            return Mode;
        }
    }

    /// <summary>
    /// Parsing modes that you can use. Can be MARKDOWN, HTML and NONE for no markup at all.
    /// </summary>
    public enum ParsingMode {
        MARKDOWN, HTML, NONE
    }
}
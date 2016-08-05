using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSharp.Core.Objects.NetAPI.TextBuilder
{

    public interface TextArea
    {

        /// <summary>
        /// Applys the markup to this part of text.
        /// </summary>
        /// <param name="Mode">The parsing mode selected.</param>
        /// <returns></returns>
        string Make(ParsingMode Mode);

    }

    /// <summary>
    /// TextElement is a part of the message with a specific markup on. Can be BOLD, ITALIC, CODE, PRE_FORMATTED_CODE and PLAIN which will print a normal message.
    /// </summary>
    public class TextElement : TextArea
    {

        public string Text = "";
        public TextType Type = null;

        /// <summary>
        /// The constructor for the object.
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="Type">The TextType. Can be BOLD, ITALIC, CODE, PRE_FORMATTED_CODE and PLAIN which will print a normal message</param>
        public TextElement(string Text, TextType Type)
        {
            this.Text = Text;
            this.Type = Type;
        }

        public string Make(ParsingMode Mode)
        {
            string Res = "";
            switch(Mode)
            {
                case ParsingMode.HTML:
                    Res += Type.HtmlStart;
                    Res += Text.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;");
                    Res += Type.HtmlEnd;
                    break;
                case ParsingMode.MARKDOWN:
                    Res += Type.MarkdownSymbol;
                    Res += Text;
                    Res += Type.MarkdownSymbol;
                    break;
                case ParsingMode.NONE:
                    Res += Text;
                    break;
                default:
                    return null;
            }
            return Res;
        }

    }

    /// <summary>
    /// This object represents an hyperlink. An hyperlink cannot have markup, like regular messages do.
    /// </summary>
    public class TextHyperlink : TextArea
    {

        public string Text = "";
        public string Url = "";

        /// <summary>
        /// The constructor for the object.
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="Url">The url.</param>
        public TextHyperlink(string Text, string Url)
        {
            this.Text = Text;
            this.Url = Url;
        }

        public string Make(ParsingMode Mode)
        {
            string Res = "";
            switch(Mode)
            {
                case ParsingMode.HTML:
                    Res += "<a href=\"" + Url + "\">" + Text + "</a>";
                    break;
                case ParsingMode.MARKDOWN:
                    Res += "[" + Text + "](" + Url + ")";
                    break;
                default:
                    return null;

            }
            return Res;
        }
    }

    /// <summary>
    /// TextTypes for the strings.
    /// </summary>
    public class TextType
    {

        public static TextType BOLD = new TextType(@"<b>", @"</b>", @"*");
        public static TextType ITALIC = new TextType(@"<i>", @"</i>", @"_");
        public static TextType CODE = new TextType("@<code>", "@</code>", @"`");
        public static TextType PRE_FORMATTED_CODE = new TextType(@"<pre>", @"</pre>", @"```");
        public static TextType PLAIN = new TextType(@"", @"", @"");

        /// <summary>
        /// Returns the start symbol for html markup.
        /// </summary>
        public string HtmlStart { get; }
        /// <summary>
        /// Returns the end symbol for html markup.
        /// </summary>
        public string HtmlEnd { get; }
        /// <summary>
        /// Returns the markdown symbol.
        /// </summary>
        public string MarkdownSymbol { get; }

        TextType(string HtmlStart, string HtmlEnd, string MarkdownSymbol)
        {
            this.HtmlStart = HtmlStart;
            this.HtmlEnd = HtmlEnd;
            this.MarkdownSymbol = MarkdownSymbol;
        }

    }
}

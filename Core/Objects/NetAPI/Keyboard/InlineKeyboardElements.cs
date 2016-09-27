using Newtonsoft.Json;
using System.Collections.Generic;

namespace TelegramSharp.Core.Objects.NetAPI.Keyboard {

    /// <summary>
    /// Represents the InlineKeyboardMarkup object in the telegram api
    /// </summary>
    public class InlineKeyboard : IReplyMarkup {

        [JsonProperty(PropertyName = "inline_keyboard")]
        public InlineKeyboardButton[][] InlineKeyboardArray { get; set; }

        /// <summary>
        /// Returns a builder for the inline keyboard
        /// </summary>
        /// <returns></returns>
        public static InlineKeyboardBuilder Builder() {
            return new InlineKeyboardBuilder();
        }

        public string serialize() {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class InlineKeyboardButton {

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "url", Required = Required.Default)]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "callback_data", Required = Required.Default)]
        public string CallbackData { get; set; }

        [JsonProperty(PropertyName = "switch_inline_query", Required = Required.Default)]
        public string SwitchInlineQuery { get; set; }

        /// <summary>
        /// Constructor for the button. Text is a required parameter.
        /// </summary>
        /// <param name="text">The text for the button</param>
        public InlineKeyboardButton(string text) {
            Text = text;
            Url = "";
            CallbackData = "";
            SwitchInlineQuery = "";
        }

        /// <summary>
        /// Sets the url for the button
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public InlineKeyboardButton WithUrl(string Url) {
            this.Url = Url;
            return this;
        }

        /// <summary>
        /// Sets the Callback data for the button
        /// </summary>
        /// <param name="CallbackData"></param>
        /// <returns></returns>
        public InlineKeyboardButton WithCallbackData(string CallbackData) {
            this.CallbackData = CallbackData;
            return this;
        }

        /// <summary>
        /// Sets the switch inline query for the button
        /// </summary>
        /// <param name="SwitchInlineQuery"></param>
        /// <returns></returns>
        public InlineKeyboardButton WithSwitchInlineQuery(string SwitchInlineQuery) {
            this.SwitchInlineQuery = SwitchInlineQuery;
            return this;
        }
    }

    /// <summary>
    /// Represents a row of the keyboard. Mainly used for simplicity.
    /// </summary>
    public class InlineKeyboardRow {
        public List<InlineKeyboardButton> buttons = null;
        private InlineKeyboardBuilder inlineKeyboardBuilder;

        public InlineKeyboardRow(InlineKeyboardBuilder inlineKeyboardBuilder) {
            this.inlineKeyboardBuilder = inlineKeyboardBuilder;
            this.buttons = new List<InlineKeyboardButton>();
        }

        /// <summary>
        /// Adds a button to the row
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns></returns>
        public InlineKeyboardRow AddButton(InlineKeyboardButton button) {
            this.buttons.Add(button);
            return this;
        }

        /// <summary>
        /// Finishes the rows and add it to the builder.
        /// </summary>
        /// <returns></returns>
        public InlineKeyboardBuilder Complete() {
            this.inlineKeyboardBuilder.rows.Add(this);
            return inlineKeyboardBuilder;
        }

        public InlineKeyboardButton[] toButtonArray() {
            return buttons.ToArray();
        }
    }

    public class InlineKeyboardBuilder {
        public List<InlineKeyboardRow> rows;

        public InlineKeyboardBuilder() {
            rows = new List<InlineKeyboardRow>();
        }

        /// <summary>
        /// Creates an InlineKeyboardRow object wich then you can add your buttons.
        /// </summary>
        /// <returns></returns>
        public void AddRow() {
            rows.Add(new InlineKeyboardRow(this));
            //return new InlineKeyboardRow(this);
        }

        /// <summary>
        /// Finishes the keyboard and returns the finished object.
        /// </summary>
        /// <returns></returns>
        public InlineKeyboard Finish() {
            InlineKeyboard inlineKeyboard = new InlineKeyboard();

            inlineKeyboard.InlineKeyboardArray = new InlineKeyboardButton[rows.Count][];

            for (int i = 0; i < rows.Count; i++) {
                inlineKeyboard.InlineKeyboardArray[i] = rows[i].toButtonArray();
            }

            return inlineKeyboard;
        }
    }
}
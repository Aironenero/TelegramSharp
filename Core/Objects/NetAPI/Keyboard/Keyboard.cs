using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace TelegramSharp.Core.Objects.NetAPI.Keyboard {

    /// <summary>
    /// This class represents a ReplyKeyboardMarkup object. Also
    /// </summary>
    public class Keyboard : IReplyMarkup {

        /// <summary>
        /// Returns a multidimensional array of the buttons. The first array represents the row, while the second, the button.
        /// </summary>
        [JsonProperty(PropertyName = "keyboard")]
        public KeyboardButton[][] Buttons { get; set; }

        /// <summary>
        /// Returns true if the keyboard should be resized.
        /// </summary>
        [JsonProperty(PropertyName = "resize_keyboard")]
        public bool ResizeKeyboard { get; set; }

        /// <summary>
        /// Returns true if the keyboard can be used only once.
        /// </summary>
        [JsonProperty(PropertyName = "one_time_keyboard")]
        public bool OneTimeKeyboard { get; set; }

        /// <summary>
        /// Returns true if the keyboard should be shown only to certain users.
        /// </summary>
        [JsonProperty(PropertyName = "selective")]
        public bool Selective { get; set; }

        /// <summary>
        /// Return a Keyboard Builder object.
        /// </summary>
        /// <param name="request_contact">The buttons should return a contact when pressed.</param>
        /// <param name="request_location">The buttons should return a location when pressed.</param>
        /// <returns></returns>
        public static KeyboardBuilder Builder(bool request_contact = false, bool request_location = false) {
            return new KeyboardBuilder(request_contact, request_location);
        }

        public string serialize() {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class KeyboardBuilder {
        private List<KeyboardRow> Rows = new List<KeyboardRow>();

        private bool RequestContact { get; set; }
        private bool RequestLocation { get; set; }
        private bool ResizeKeyboard = false;
        private bool OneTimeKeyboard = false;
        private bool Selective = false;

        /// <summary>
        /// Creates a new KeyboardBuilder object.
        /// </summary>
        /// <param name="request_contact">The buttons should return a contact when pressed.</param>
        /// <param name="request_location">The buttons should return a location when pressed.</param>
        public KeyboardBuilder(bool request_contact = false, bool request_location = false) {
            this.RequestContact = request_contact;
            this.RequestLocation = request_location;
        }

        /// <summary>
        /// Sets the ResizeKeyboard value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public KeyboardBuilder SetResizeKeyboard(bool value) {
            this.ResizeKeyboard = value;
            return this;
        }

        /// <summary>
        /// Sets the OneTimeKeyboard value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public KeyboardBuilder SetOneTimeKeyboard(bool value) {
            this.OneTimeKeyboard = value;
            return this;
        }

        /// <summary>
        /// Sets the Selective value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public KeyboardBuilder SetSelective(bool value) {
            this.Selective = value;
            return this;
        }

        /// <summary>
        /// Adds a row with the specified buttons (in the params).
        /// </summary>
        /// <param name="buttons">The buttons to be added with the row.</param>
        /// <returns></returns>
        public KeyboardBuilder AddRow(params string[] buttons) {
            KeyboardRow row = new KeyboardRow();
            foreach (string text in buttons) {
                KeyboardButton button = new KeyboardButton();
                button.Text = text;
                button.RequestLocation = RequestLocation;
                button.RequestContact = RequestContact;

                row.AddButtons(button);
            }
            Rows.Add(row);
            return this;
        }

        /// <summary>
        /// Returns the finished keyboard.
        /// </summary>
        /// <returns>The finishied keyboard.</returns>
        public Keyboard Build() {
            Keyboard res = new Keyboard();

            res.OneTimeKeyboard = OneTimeKeyboard;
            res.ResizeKeyboard = ResizeKeyboard;
            res.Selective = Selective;

            res.Buttons = getMultidimensionalButtonArray();

            return res;
        }

        private KeyboardButton[][] getMultidimensionalButtonArray() {
            KeyboardButton[][] Res = null;

            Res = new KeyboardButton[Rows.Count][];

            for (int i = 0; i < Rows.Count; i++) {
                Res[i] = Rows.ElementAt(i).KeyboardButtonArray;
            }

            return Res;
        }
    }
}
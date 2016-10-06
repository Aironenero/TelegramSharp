﻿//TelegramSharp - A library to make telegram bots
//Copyright (C) 2016  Samuele Lorefice, Niccolò Mattei, Fabio De Simone
//
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TelegramSharp.Core.Objects.NetAPI.Keyboard
{
    /// <summary>
    /// Represents the InlineKeyboardMarkup object in the telegram api
    /// </summary>
    public class InlineKeyboard : IReplyMarkup
    {
        [JsonProperty(PropertyName = "inline_keyboard")]
        public InlineKeyboardButton[][] InlineKeyboardArray { get; set; }

        /// <summary>
        /// Returns a builder for the inline keyboard
        /// </summary>
        /// <returns></returns>
        public static InlineKeyboardBuilder Builder()
        {
            return new InlineKeyboardBuilder();
        }

        public string serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class InlineKeyboardButton
    {
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
        public InlineKeyboardButton(string text)
        {
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
        public InlineKeyboardButton WithUrl(string Url)
        {
            this.Url = Url;
            return this;
        }

        /// <summary>
        /// Sets the Callback data for the button
        /// </summary>
        /// <param name="CallbackData"></param>
        /// <returns></returns>
        public InlineKeyboardButton WithCallbackData(string CallbackData)
        {
            this.CallbackData = CallbackData;
            return this;
        }

        /// <summary>
        /// Sets the switch inline query for the button
        /// </summary>
        /// <param name="SwitchInlineQuery"></param>
        /// <returns></returns>
        public InlineKeyboardButton WithSwitchInlineQuery(string SwitchInlineQuery)
        {
            this.SwitchInlineQuery = SwitchInlineQuery;
            return this;
        }
    }

    /// <summary>
    /// Represents a row of the keyboard. Mainly used for simplicity.
    /// </summary>
    public class InlineKeyboardRow
    {
        public List<InlineKeyboardButton> buttons = null;


        public InlineKeyboardRow(params InlineKeyboardButton[] buttons)
        {
            this.buttons = new List<InlineKeyboardButton>(buttons);
        }

        public InlineKeyboardButton[] toButtonArray()
        {
            return buttons.ToArray();
        }
    }

    public class InlineKeyboardBuilder
    {
        public List<InlineKeyboardRow> rows;

        public InlineKeyboardBuilder()
        {
            rows = new List<InlineKeyboardRow>();
        }

        /// <summary>
        /// Creates an InlineKeyboardRow object wich then you can add your buttons.
        /// </summary>
        /// <returns></returns>
        public void AddRow(params InlineKeyboardButton[] buttons)
        {
            rows.Add(new InlineKeyboardRow(buttons));
        }

        /// <summary>
        /// Finishes the keyboard and returns the finished object.
        /// </summary>
        /// <returns></returns>
        public InlineKeyboard Finish()
        {
            InlineKeyboard inlineKeyboard = new InlineKeyboard();

            inlineKeyboard.InlineKeyboardArray = new InlineKeyboardButton[rows.Count][];

            for (int i = 0; i < rows.Count; i++)
            {
                inlineKeyboard.InlineKeyboardArray[i] = rows[i].toButtonArray();
            }

            return inlineKeyboard;
        }
    }
}
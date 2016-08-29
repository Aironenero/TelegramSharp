using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSharp.Core.Objects.NetAPI.Keyboard
{
    public class InlineKeyboard
    {
        public InlineKeyboardButton[][] InlineKeyboardArray { get; set; }
    }

    public class InlineKeyboardButton
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public string CallbackData { get; set; }
        public string SwitchInlineQuert { get; set; }
    }
}

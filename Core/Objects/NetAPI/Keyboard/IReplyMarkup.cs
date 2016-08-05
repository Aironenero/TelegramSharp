using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSharp.Core.Objects.NetAPI.Keyboard
{
    public interface IReplyMarkup
    {

        /// <summary>
        /// Returns a serialized version of the class.
        /// </summary>
        /// <returns></returns>
        string serialize();

    }
}

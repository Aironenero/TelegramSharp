//TelegramSharp - A library to make telegram bots
//Copyright (C) 2016  Samuele Lorefice, Niccolò Mattei
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
using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core
{
    /// <summary>
    /// Json data manager.
    /// </summary>
    public class JsonDataManager
    {
        /// <summary>
        /// The offset of last requested update
        /// </summary>
        public int Offset;

        /// <summary>
        /// Deserializes the and parse messages.
        /// </summary>
        /// <param name="inJson">JSON to deserialize.</param>
        /// <param name="bot">Bot that should parse the message.</param>
        public void DeserializeAndParseMessages(string inJson, TelegramService bot)
        {
            try
            {
                MessageServerUpdate serverUpdate = JsonConvert.DeserializeObject<MessageServerUpdate>(inJson);
                if (serverUpdate.Result != null)
                {
                    foreach (Update upd in serverUpdate.Result)
                    {

                        Offset = upd.UpdateId;
                        if (upd.Message != null)
                        {
                            bot.Parser.ParseMessage(upd.Message, bot);
                            Logger.LogConsoleWrite(upd.Message, bot.BotIdentity);
                        }
                        if (upd.EditedMessage != null)
                        {
                            bot.Parser.ParseMessage(upd.EditedMessage, bot);
                            Logger.LogConsoleWrite(upd.EditedMessage, bot.BotIdentity);
                        }
                        if (upd.CallbackQuery != null)
                        {
                            bot.Parser.HandleUpdate(upd, bot);
                        }
                    }
                }
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine("ERROR: Server not returned a valid JSON, check your token and connection. A newer version of this library may be needed");
                Console.WriteLine("Returned from the website: " + inJson);
                System.IO.File.AppendAllText("Error" +
                                            DateTime.Now.Day.ToString() + "-" +
                                            DateTime.Now.Month.ToString() + "-" +
                                            DateTime.Now.Year.ToString() + "_" +
                                            DateTime.Now.Hour.ToString() + "-" +
                                            DateTime.Now.Minute.ToString() + "-" +
                                            DateTime.Now.Second.ToString() + "-" +
                                            DateTime.Now.Millisecond.ToString() + ".log",
                                            "\nError generated on " + DateTime.Now.ToString() + "\n" + e.ToString());
                System.IO.File.WriteAllText("FaultyJSON.log", inJson);
                System.Threading.Thread.Sleep(100000);
            }
        }

        /// <summary>
        /// Deserializes the and parse a get me.
        /// </summary>
        /// <returns>Bot user information</returns>
        /// <param name="inJson">JSON to deserialize.</param>
        /// <param name="bot">Bot that should parse the message.</param>
        public User DeserializeAndParseGetMe(string inJson, TelegramService bot)
        {
            try
            {
                GetMeServerUpdate serverUpdate = JsonConvert.DeserializeObject<GetMeServerUpdate>(inJson);
                if (serverUpdate.GetMe != null)
                    Logger.LogWrite(serverUpdate.GetMe);
                bot.BotIdentity = serverUpdate.GetMe;
                return serverUpdate.GetMe;
            }
            catch (JsonReaderException)
            {
                Console.WriteLine("ERROR: Server not returned a valid JSON, chek your token and connection.");
                Console.WriteLine("Returned from the website: " + inJson);
                System.Threading.Thread.Sleep(100000);
            }
            return null;
        }
    }
}

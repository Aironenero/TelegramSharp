//TelegramSharp - A library to make telegram bots
//Copyright (C) 2016  Samuele Lorefice
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
using System;
using System.IO;
using System.Net;
using System.Text;
using TelegramSharp.Core.Objects.NetAPI.Keyboard;
using TelegramSharp.Core.Objects.NetAPI.TextBuilder;
using TelegramSharp.Core.Utils;

namespace TelegramSharp.Core
{
    /// <summary>
    /// Network operations.
    /// </summary>
    public class NetworkSender
    {
        /// <summary>
        /// Gets the updates containing messages.
        /// </summary>
        /// <returns>The updates.</returns>
        /// <param name="token">Bot Token.</param>
        /// <param name="offset">Update offset.</param>
        /// <param name="limit">Limit of messages in a update.</param>
        /// <param name="timeout">Request timeout (if 0 short polling, else long polling).</param>
        public static string GetUpdates(string token, int offset = 0, int limit = 100, int timeout = 60)
        {
            try
            {
                // Create a request
                WebRequest request = WebRequest.Create(CombineUri("https://api.telegram.org/bot", token) + "/getUpdates");
                request.Method = "POST"; // Set the Method property of the request to POST.
                string postData = "offset=" + offset + "&limit=" + limit + "&timeout=" + timeout; // Create POST data
                byte[] byteArray = Encoding.UTF8.GetBytes(postData); //Convert it to a byte array.
                request.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
                request.ContentLength = byteArray.Length; // Set the ContentLength property of the WebRequest.
                Stream dataStream = request.GetRequestStream(); // Get the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length); // Write the data to the request stream.
                dataStream.Close(); // Close the Stream object.
                WebResponse response = request.GetResponse(); // Get the response.
                Console.WriteLine("GetUpdates request status:" + ((HttpWebResponse)response).StatusDescription); // Display the status.
                dataStream = response.GetResponseStream(); // Get the stream containing content returned by the server.
                StreamReader reader = new StreamReader(dataStream); // Open the stream using a StreamReader for easy access.
                string _out = reader.ReadToEnd(); // Read the content.
                reader.Close(); // Clean up the streams.
                response.Close();
                return _out; // Return the value
            }
            catch (WebException e)
            {
                Console.WriteLine("Exception generated, see Error.log");
                System.IO.File.AppendAllText("Error" +
                            DateTime.Now.Day.ToString() + "-" +
                            DateTime.Now.Month.ToString() + "-" +
                            DateTime.Now.Year.ToString() + "_" +
                            DateTime.Now.Hour.ToString() + "-" +
                            DateTime.Now.Minute.ToString() + "-" +
                            DateTime.Now.Second.ToString() + "-" +
                            DateTime.Now.Millisecond.ToString() + ".log",
                            "\nError generated on " + DateTime.Now.ToString() + "\n" + e.ToString());
                System.Threading.Thread.Sleep(100000);
            }
            return null;
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="token">Bot Token.</param>
        /// <param name="chatId">Chat identifier.</param>
        /// <param name="component">The component used to send the message.</param>
        /// <param name="disableWebPagePreview">If set to <c>true</c> disable web page preview.</param>
        /// <param name="replyToMessageId">Reply to message identifier.</param>
        /// <param name="markup">Sends a reply markup to a user.</param>
        [Obsolete("This method uses the old 'way' of doing a post request. Please use the newer method.")]
        public static void SendMessage_Deprecated(string token, long chatId, IBaseComponent component, bool disableWebPagePreview = false, int replyToMessageId = 0, IReplyMarkup markup = null)
        {
            try
            {
                // Create a request
                WebRequest request = WebRequest.Create(CombineUri("https://api.telegram.org/bot", token) + "/sendMessage");
                request.Method = "POST"; // Set the Method property of the request to POST.
                string markupString = markup == null ? "" : markup.serialize(); // Checks if the markup is null. If not null it proceeds to serialize it.
                string parsingMode = component.GetParsingMode() == ParsingMode.NONE ? "" : component.GetParsingMode().ToString().ToLower();
                string postData = "chat_id=" + chatId + "&text=" + component.Make() + "&parse_mode=" + parsingMode + "&disable_web_page_preview=" + disableWebPagePreview.ToString().ToLower() + "&reply_to_message_id=" + replyToMessageId + "&reply_markup=" + markupString; // Create POST data
                byte[] byteArray = Encoding.UTF8.GetBytes(postData); //Convert it to a byte array.
                request.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
                request.ContentLength = byteArray.Length; // Set the ContentLength property of the WebRequest.
                Stream dataStream = request.GetRequestStream(); // Get the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length); // Write the data to the request stream.
                dataStream.Close(); // Close the Stream object.
                Console.WriteLine("Sending message...");
                WebResponse response = request.GetResponse(); // Get the response.
                Console.WriteLine("Send message request status:" + ((HttpWebResponse)response).StatusDescription); // Display the status.
                dataStream = response.GetResponseStream(); // Get the stream containing content returned by the server.
                StreamReader reader = new StreamReader(dataStream); // Open the stream using a StreamReader for easy access.
                reader.Close(); // Clean up the streams.
                response.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine("Exception generated, see Error.log");
                System.IO.File.AppendAllText("Error" +
                            DateTime.Now.Day.ToString() + "-" +
                            DateTime.Now.Month.ToString() + "-" +
                            DateTime.Now.Year.ToString() + "_" +
                            DateTime.Now.Hour.ToString() + "-" +
                            DateTime.Now.Minute.ToString() + "-" +
                            DateTime.Now.Second.ToString() + "-" +
                            DateTime.Now.Millisecond.ToString() + ".log",
                            "\nError generated on " + DateTime.Now.ToString() + "\n" + e.ToString());
                System.Threading.Thread.Sleep(100000);
            }
        }

        /// <summary>
        /// Forwards a message to a chat
        /// </summary>
        /// <param name="token">Bot token</param>
        /// <param name="chatId">id of the chat where you want to forward the message</param>
        /// <param name="fromChatId">chat from where the message was sent</param>
        /// <param name="messageId">id of the message to forward</param>
        public static void ForwardMessage(string token, long chatId, long fromChatId, long messageId)
        {
            try
            {
                // Create a request
                WebRequest request = WebRequest.Create(CombineUri("https://api.telegram.org/bot", token) + "/forwardMessage");
                request.Method = "POST"; // Set the Method property of the request to POST.
                string postData = "chat_id=" + chatId.ToString() + "&from_chat_id=" + fromChatId.ToString() + "&message_id=" + messageId.ToString(); // Create POST data
                Console.WriteLine(postData);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData); //Convert it to a byte array.
                request.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
                request.ContentLength = byteArray.Length; // Set the ContentLength property of the WebRequest.
                Stream dataStream = request.GetRequestStream(); // Get the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length); // Write the data to the request stream.
                dataStream.Close(); // Close the Stream object.
                Console.WriteLine("Forwarding message...");
                WebResponse response = request.GetResponse(); // Get the response.
                Console.WriteLine("Send message request status:" + ((HttpWebResponse)response).StatusDescription); // Display the status.
                dataStream = response.GetResponseStream(); // Get the stream containing content returned by the server.
                StreamReader reader = new StreamReader(dataStream); // Open the stream using a StreamReader for easy access.
                reader.Close(); // Clean up the streams.
                response.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine("Exception generated, see Error.log");
                System.IO.File.AppendAllText("Error" +
                            DateTime.Now.Day.ToString() + "-" +
                            DateTime.Now.Month.ToString() + "-" +
                            DateTime.Now.Year.ToString() + "_" +
                            DateTime.Now.Hour.ToString() + "-" +
                            DateTime.Now.Minute.ToString() + "-" +
                            DateTime.Now.Second.ToString() + "-" +
                            DateTime.Now.Millisecond.ToString() + ".log",
                            "\nError generated on " + DateTime.Now.ToString() + "\n" + e.ToString());
                System.Threading.Thread.Sleep(100000);
            }
        }

        public static void SendMessage(string token, long chatId, IBaseComponent component, bool disableWebPagePreview = false, int replyToMessageId = 0, IReplyMarkup markup = null)
        {
            string markupString = markup == null ? "" : markup.serialize();
            string parsingMode = component.GetParsingMode() == ParsingMode.NONE ? "" : component.GetParsingMode().ToString().ToLower();
            Request.Builder(CombineUri("https://api.telegram.org/bot", token) + "/sendMessage").AddParameter("chat_id", chatId + "")
                .AddParameter("parse_mode", parsingMode)
                .AddParameter("text", component.Make())
                .AddParameter("disable_web_page_preview", disableWebPagePreview + "")
                .AddParameter("reply_to_message_id", replyToMessageId + "")
                .AddParameter("reply_markup", markupString)
                .Build()
                .Execute();
        }

        public static void SendPhoto(string token, long chatId, Property property, string caption = "", bool disableNotification = false, int replyToMessageId = 0, IReplyMarkup markup = null)
        {

            string markupString = markup == null ? "" : markup.serialize();
            if (property.PropertyValue == PropertyValue.FILE && File.Exists(property.Value)) {
                string res = Request.Builder(CombineUri("https://api.telegram.org/bot", token) + "/sendPhoto")
                    .AddParameter("chat_id", chatId + "")
                    .SetMultipartParameter("photo", property.Value)
                    .AddParameter("caption", caption)
                    .AddParameter("disable_notification", disableNotification + "")
                    .AddParameter("reply_to_message_id", replyToMessageId + "")
                    .AddParameter("reply_markup", markupString)
                    .Build()
                    .Execute();
                Console.WriteLine("Result from request:" + res);
            } else
            {
                Request.Builder(CombineUri("https://api.telegram.org/bot", token) + "/sendPhoto")
                    .AddParameter("chat_id", chatId + "")
                    .AddParameter("photo", property.Value)
                    .AddParameter("caption", caption)
                    .AddParameter("disable_notification", disableNotification + "")
                    .AddParameter("reply_to_message_id", replyToMessageId + "")
                    .AddParameter("reply_markup", markupString)
                    .Build()
                    .Execute();
            }

        }

        /// <summary>
        /// Gets Bot user information.
        /// </summary>
        /// <returns>The <c>User</c> containing the bot acocunt infos.</returns>
        /// <param name="token">Bot token.</param>
        public static string GetMe(string token)
        {
            try
            {
                // Create a request
                WebRequest request = WebRequest.Create(CombineUri("https://api.telegram.org/bot", token) + "/getMe");
                request.Method = "POST"; // Set the Method property of the request to POST.
                string postData = ""; // Create POST data
                byte[] byteArray = Encoding.UTF8.GetBytes(postData); //Convert it to a byte array.
                request.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
                request.ContentLength = byteArray.Length; // Set the ContentLength property of the WebRequest.
                Stream dataStream = request.GetRequestStream(); // Get the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length); // Write the data to the request stream.
                dataStream.Close(); // Close the Stream object.
                Console.WriteLine("Getting Bot infos");
                WebResponse response = request.GetResponse(); // Get the response.
                Console.WriteLine("GetMe request status:" + ((HttpWebResponse)response).StatusDescription); // Display the status.
                dataStream = response.GetResponseStream(); // Get the stream containing content returned by the server.
                StreamReader reader = new StreamReader(dataStream); // Open the stream using a StreamReader for easy access.
                string _out = reader.ReadToEnd(); // Read the content.
                reader.Close(); // Clean up the streams.
                response.Close();
                return _out; // Return the value
            }
            catch (WebException e)
            {
                Console.WriteLine("Exception generated, see Error.log");
                System.IO.File.AppendAllText("Error" +
                            DateTime.Now.Day.ToString() + "-" +
                            DateTime.Now.Month.ToString() + "-" +
                            DateTime.Now.Year.ToString() + "_" +
                            DateTime.Now.Hour.ToString() + "-" +
                            DateTime.Now.Minute.ToString() + "-" +
                            DateTime.Now.Second.ToString() + "-" +
                            DateTime.Now.Millisecond.ToString() + ".log",
                            "\nError generated on " + DateTime.Now.ToString() + "\n" + e.ToString());
                System.Threading.Thread.Sleep(100000);
            }
            return null;
        }

        //Ottiene gli URL a cui inviare le richieste
        private static string CombineUri(string url, string token)
        {
            return url + token;
        }
    }
}

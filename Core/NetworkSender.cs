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

namespace TelegramSharp.Core {
	/// <summary>
	/// Network operations.
	/// </summary>
	public class NetworkSender {
		/// <summary>
		/// Gets the updates containing messages.
		/// </summary>
		/// <returns>The updates.</returns>
		/// <param name="token">Bot Token.</param>
		/// <param name="offset">Update offset.</param>
		/// <param name="limit">Limit of messages in a update.</param>
		/// <param name="timeout">Request timeout (if 0 short polling, else long polling).</param>
		public static string GetUpdates (string token, int offset = 0, int limit = 100, int timeout = 60) {
			try {
				// Create a request
				WebRequest request = WebRequest.Create (CombineUri ("https://api.telegram.org/bot", token) + "/getUpdates");
				request.Method = "POST"; // Set the Method property of the request to POST.
				string postData = CombineParams (offset: offset, limit: limit, timeout: timeout); // Create POST data
				byte[] byteArray = Encoding.UTF8.GetBytes (postData); //Convert it to a byte array.
				request.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
				request.ContentLength = byteArray.Length; // Set the ContentLength property of the WebRequest.
				Stream dataStream = request.GetRequestStream (); // Get the request stream.
				dataStream.Write (byteArray, 0, byteArray.Length); // Write the data to the request stream.
				dataStream.Close (); // Close the Stream object.
			    WebResponse response = request.GetResponse (); // Get the response.
				Console.WriteLine ("GetUpdates request status:" + ((HttpWebResponse)response).StatusDescription); // Display the status.
				dataStream = response.GetResponseStream (); // Get the stream containing content returned by the server.
				StreamReader reader = new StreamReader (dataStream); // Open the stream using a StreamReader for easy access.
				string _out = reader.ReadToEnd (); // Read the content.
				reader.Close (); // Clean up the streams.
				response.Close ();
				return _out; // Return the value
			} catch (WebException e) {
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
            }
			return null;
		}

		/// <summary>
		/// Sends the message.
		/// </summary>
		/// <param name="token">Bot Token.</param>
		/// <param name="chatId">Chat identifier.</param>
		/// <param name="text">Message text.</param>
		/// <param name="parseMode">Parse mode.</param>
		/// <param name="disableWebPagePreview">If set to <c>true</c> disable web page preview.</param>
		/// <param name="replyToMessageId">Reply to message identifier.</param>
		public static void SendMessage (string token, long chatId, string text, string parseMode = "", bool disableWebPagePreview = false, int replyToMessageId = 0) {
			try {
				// Create a request
				WebRequest request = WebRequest.Create (CombineUri ("https://api.telegram.org/bot", token) + "/sendMessage");
				request.Method = "POST"; // Set the Method property of the request to POST.
				string postData = CombineParams (chatId, text, parseMode, disableWebPagePreview, replyToMessageId); // Create POST data
				byte[] byteArray = Encoding.UTF8.GetBytes (postData); //Convert it to a byte array.
				request.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
				request.ContentLength = byteArray.Length; // Set the ContentLength property of the WebRequest.
				Stream dataStream = request.GetRequestStream (); // Get the request stream.
				dataStream.Write (byteArray, 0, byteArray.Length); // Write the data to the request stream.
				dataStream.Close (); // Close the Stream object.
                Console.WriteLine("Sending message...");
				WebResponse response = request.GetResponse (); // Get the response.
				Console.WriteLine ("Send message request status:" + ((HttpWebResponse)response).StatusDescription); // Display the status.
				dataStream = response.GetResponseStream (); // Get the stream containing content returned by the server.
				StreamReader reader = new StreamReader (dataStream); // Open the stream using a StreamReader for easy access.
				reader.Close (); // Clean up the streams.
				response.Close ();
			} catch (WebException e) {
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
            }
		}

        /// <summary>
        /// Gets Bot user information.
        /// </summary>
        /// <returns>The <c>User</c> containing the bot acocunt infos.</returns>
        /// <param name="token">Bot token.</param>
        public static string GetMe (string token) {
			try {
				// Create a request
				WebRequest request = WebRequest.Create (CombineUri ("https://api.telegram.org/bot", token) + "/getMe");
				request.Method = "POST"; // Set the Method property of the request to POST.
				string postData = ""; // Create POST data
				byte[] byteArray = Encoding.UTF8.GetBytes (postData); //Convert it to a byte array.
				request.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
				request.ContentLength = byteArray.Length; // Set the ContentLength property of the WebRequest.
				Stream dataStream = request.GetRequestStream (); // Get the request stream.
				dataStream.Write (byteArray, 0, byteArray.Length); // Write the data to the request stream.
				dataStream.Close (); // Close the Stream object.
                Console.WriteLine("Getting Bot infos");
				WebResponse response = request.GetResponse (); // Get the response.
				Console.WriteLine ("GetMe request status:" + ((HttpWebResponse)response).StatusDescription); // Display the status.
				dataStream = response.GetResponseStream (); // Get the stream containing content returned by the server.
				StreamReader reader = new StreamReader (dataStream); // Open the stream using a StreamReader for easy access.
				string _out = reader.ReadToEnd (); // Read the content.
				reader.Close (); // Clean up the streams.
				response.Close ();
				return _out; // Return the value
			} catch (WebException e) {
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
            }
			return null;
		}

		//Ottiene gli URL a cui inviare le richieste
		private static string CombineUri (string url, string token) {
			return url + token;
		}

		//chat_id text parse_mode disable_web_page_preview reply_to_message_id offset limit timeout from_chat_id message_id
		private static string CombineParams (long chatId = 0, string text = "", string parseMode = "", bool disableWebPagePreview = false, int replyToMessageId = 0, int offset = 0, int limit = 0, int timeout = 0, int fromChatId = 0, int messageId = 0) {
			//get update offset, limit, timeout
			if (chatId == 0 && text == "" && parseMode == "" && disableWebPagePreview == false && replyToMessageId == 0 && fromChatId == 0 && messageId == 0) {
				return "offset=" + offset + "&limit=" + limit + "&timeout=" + timeout;
			}
			//send message signature: chat_id text  (parse_mode disable_web_page_preview reply_to_message_id)
			if (offset == 0 && limit == 0 && timeout == 0) {
				string _out = "chat_id=" + chatId + "&text=" + text;
				if (parseMode != "") {
					_out += "&parse_mode=" + parseMode;
				}
				if (disableWebPagePreview) {
					_out += "&disable_web_page_preview=true";
				}
				if (replyToMessageId != 0) {
					_out += "&reply_to_message_id=" + replyToMessageId;
				}
				return _out;
			}

			return null;
		}
	}
}
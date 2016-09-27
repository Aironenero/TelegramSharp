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
using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp {

    /// <summary>
    /// Message Logger.
    /// </summary>
    public static class Logger {

        /// <summary>
        /// Logs a message to the console.
        /// </summary>
        /// <param name="msgToLog">Message to log.</param>
        /// <param name="Bot">Bot</param>
        public static void LogConsoleWrite(Message msgToLog, User Bot) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(String.Format("{0},", DateTime.Now.ToString()));
            Console.Write(String.Format("{0}|INFO|", DateTime.Now.Millisecond));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(String.Format("{0}|", Bot.Username));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(String.Format("From chat {0},", msgToLog.Chat.Title + " " + msgToLog.Chat.Username));
            Console.Write(String.Format("by {0}|", msgToLog.From.Id + " " + msgToLog.From.FirstName + " " + msgToLog.From.LastName));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("Message: {0}", msgToLog.Text));
            Console.ForegroundColor = ConsoleColor.Green;
        }

        /// <summary>
        /// Logs the bot identity.
        /// </summary>
        /// <param name="getMe">Get me.</param>
        public static void LogWrite(User getMe) {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***Received Bot Identity***");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Name: " + getMe.FirstName + " " + getMe.LastName);
            Console.WriteLine("Username: @" + getMe.Username + " ID: " + getMe.Id);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***End of Bot Identity***");
            Console.WriteLine("");
        }
    }
}
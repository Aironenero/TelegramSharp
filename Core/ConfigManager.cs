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
using Newtonsoft.Json;
using System;
using TelegramSharp.Core.Objects;

namespace TelegramSharp.Core
{
    /// <summary>
    /// Bot configuration manager.
    /// </summary>
    public static class ConfigManager
    {
        private static string configPath;

        /// <summary>
        /// Loads the configuration from the specified file path.
        /// </summary>
        /// <returns>The config.</returns>
        /// <param name="ConfigPath">Config path.</param>
        public static BotSetup LoadConfig(string ConfigPath = "TelegramBotConfig.json")
        {
            configPath = ConfigPath;
            BotSetup config = new BotSetup();
            if (System.IO.File.Exists(configPath))
            {
                string jsonconfig = System.IO.File.ReadAllText(configPath);

                try
                {
                    config = JsonConvert.DeserializeObject<BotSetup>(jsonconfig);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return config;
            }
            config = new BotSetup();
            config.BotToken = "your token here";
            SaveConfig(config);
            return null;
        }

        /// <summary>
        /// Loads the configuration from the specified file path.
        /// </summary>
        /// <returns></returns>
        public static BotSetup LoadConfig()
        {
            configPath = "TelegramBotConfig.json";
            BotSetup config = new BotSetup();
            if (System.IO.File.Exists(configPath))
            {
                string jsonconfig = System.IO.File.ReadAllText(configPath);

                try
                {
                    config = JsonConvert.DeserializeObject<BotSetup>(jsonconfig);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return config;
            }
            config = new BotSetup();
            config.BotToken = "your token here";
            SaveConfig(config);
            return null;
        }

        /// <summary>
        /// Saves the config.
        /// </summary>
        /// <param name="config">Config.</param>
        public static void SaveConfig(BotSetup config)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            System.IO.File.WriteAllText(configPath, json);
        }
    }
}

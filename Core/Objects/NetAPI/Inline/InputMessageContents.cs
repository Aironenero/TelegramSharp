//TelegramSharp - A library to make telegram bots
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
namespace TelegramSharp.Core.Objects.NetAPI.Inline {

    public interface InputMessageContent {
    }

    public class InputTextMessageContent : InputMessageContent {
        public string MessageText { get; set; }

        //optional
        public string ParseMode { get; set; }

        //optional
        public bool DisableWebPagePreview { get; set; }
    }

    public class InputLocationMessageContent : InputMessageContent {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }

    public class InputVenueMessageContent : InputLocationMessageContent {
        public string Title { get; set; }
        public string Address { get; set; }

        //optional
        public string ForsquareId { get; set; }
    }

    public class InputContactMessageContent : InputMessageContent {
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }

        //optional
        public string LastName { get; set; }
    }
}
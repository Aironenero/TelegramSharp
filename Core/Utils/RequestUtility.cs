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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSharp.Core.Utils {

    public class Property {
        public string Value { get; set; }
        public PropertyValue PropertyValue { get; set; }

        public Property(string Value, PropertyValue PropertyValue) {
            this.Value = Value;
            this.PropertyValue = PropertyValue;
        }
    }

    public enum PropertyValue {
        FILE, STRING
    }

    public class Request {

        protected class FileToSend {
            public string Filename { get; set; }
            public Stream Content { get; set; }

            public FileToSend(string Filename, Stream Content) {
                this.Filename = Filename;
                this.Content = Content;
            }
        }

        public string Url { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public MultiObject<string, string> MultipartParameter { get; set; }
        public bool IsMultipart = false;

        public string Execute() {
            return ExecuteRequest().Result;
        }

        private async Task<string> ExecuteRequest() {
            using (HttpClient Client = new HttpClient()) {
                List<string> keyToRemove = new List<string>();
                foreach (KeyValuePair<string, string> keyValuePair in Parameters) {
                    if (keyValuePair.Value == "0" || keyValuePair.Value == null) {
                        keyToRemove.Add(keyValuePair.Key);
                    }
                }
                foreach (string s in keyToRemove) {
                    Parameters.Remove(s);
                }

                if (!IsMultipart) {
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var postString = "?";

                    for (int i = 0; i < Parameters.Count; i++) {
                        string prm = Parameters.Keys.ElementAt(i);
                        string value = Parameters.Values.ElementAt(i);

                        postString += prm + "=" + Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(value));

                        if (i != Parameters.Count -1) {
                            postString += "&";
                        }
                    }

                    var formUrlEncoded = new FormUrlEncodedContent(Parameters);

                    HttpResponseMessage Message = await Client.PostAsync(Url, formUrlEncoded);

                    Message.EnsureSuccessStatusCode();

                    var res = await Message.Content.ReadAsStringAsync();

                    return res;
                }
                else {
                    if (File.Exists(MultipartParameter.Object2)) {
                        using (var MultipartContent =
                            new MultipartFormDataContent()) {
                            foreach (string Key in Parameters.Keys) {
                                string Value = Parameters[Key];
                                MultipartContent.Add(new StringContent(Value, Encoding.UTF8, "application/json"), Key);
                            }

                            FileToSend Content = new FileToSend(Path.GetFileName(MultipartParameter.Object2), File.Open(MultipartParameter.Object2, FileMode.Open));
                            Console.WriteLine("Creating byte array for file...");
                            Console.WriteLine("Key: " + MultipartParameter.Object1 + " - Value: " + MultipartParameter.Object2);
                            MultipartContent.Add(new StreamContent(Content.Content), MultipartParameter.Object1, Content.Filename);

                            HttpResponseMessage Message = await Client.PostAsync(Url, MultipartContent);

                            try {
                                Message.EnsureSuccessStatusCode();
                            }
                            catch (Exception e) {
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

                            var res = await Message.Content.ReadAsStringAsync();

                            return res;
                        }
                    }
                    else {
                        Console.WriteLine("File was not found! Cannot send request!");
                        return null;
                    }
                }
            }
        }

        public static RequestBuilder Builder(string Url) {
            return new RequestBuilder(Url);
        }

        private static byte[] GetBytes(string str) {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }

    public class MultiObject<K, V> {
        public K Object1 { get; set; }
        public V Object2 { get; set; }

        public MultiObject(K Object1, V Object2) {
            this.Object1 = Object1;
            this.Object2 = Object2;
        }

        public void SetObjects(K Object1, V Object2) {
            this.Object1 = Object1;
            this.Object2 = Object2;
        }

        public MultiObject() {
            this.Object1 = default(K);
            this.Object2 = default(V);
        }
    }

    public class RequestBuilder {
        public string Url = "";
        public Dictionary<string, string> Parameters = null;
        public MultiObject<string, string> MultipartParameter = null;
        public bool IsMultipart = false;

        public RequestBuilder(string Url) {
            this.Url = Url;
            this.Parameters = new Dictionary<string, string>();
            this.MultipartParameter = new MultiObject<string, string>();
        }

        public RequestBuilder AddParameter(string Key, string Value) {
            this.Parameters.Add(Key, Value);
            return this;
        }

        public RequestBuilder SetMultipartParameter(string Key, string ValuePath) {
            this.MultipartParameter.SetObjects(Key, ValuePath);
            this.IsMultipart = true;
            return this;
        }

        public Request Build() {
            Request req = new Request();
            req.Url = Url;
            req.Parameters = this.Parameters;
            req.MultipartParameter = this.MultipartParameter;
            req.IsMultipart = IsMultipart;

            return req;
        }
    }
}
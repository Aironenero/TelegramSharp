using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelegramSharp.Core.Utils
{
    public class Property
    {
        public string Value { get; set; }
        public PropertyValue PropertyValue { get; set; }

        public Property(string Value, PropertyValue PropertyValue)
        {
            this.Value = Value;
            this.PropertyValue = PropertyValue;
        }
    }

    public enum PropertyValue
    {
        FILE, STRING
    }

    public class Request
    {
        public string Url { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public MultiObject<string, string> MultipartParameter { get; set; }
        public bool IsMultipart = false;

        public string Execute()
        {
            return ExecuteRequest().Result;
        }

        private async Task<string> ExecuteRequest()
        {
            using (HttpClient Client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new FormUrlEncodedContent(Parameters);

                HttpResponseMessage Message = await Client.PostAsync(Url, content);

                Message.EnsureSuccessStatusCode();

                var res = await Message.Content.ReadAsStringAsync();

                return res;
            }
        }

        public static RequestBuilder Builder(string Url)
        {
            return new RequestBuilder(Url);
        }
    }

    public class MultiObject<K, V>
    {
        public K Object1 { get; set; }
        public V Object2 { get; set; }

        public MultiObject(K Object1, V Object2)
        {
            this.Object1 = Object1;
            this.Object2 = Object2;
        }

        public void SetObjects(K Object1, V Object2)
        {
            this.Object1 = Object1;
            this.Object2 = Object2;
        }

        public MultiObject()
        {
            this.Object1 = default(K);
            this.Object2 = default(V);
        }
    }

    public class RequestBuilder
    {
        public string Url = "";
        public Dictionary<string, string> Parameters = null;
        public MultiObject<string, string> MultipartParameter = null;
        public bool IsMultipart = false;

        public RequestBuilder(string Url)
        {
            this.Url = Url;
            this.Parameters = new Dictionary<string, string>();
            this.MultipartParameter = new MultiObject<string, string>();
        }

        public RequestBuilder AddParameter(string Key, string Value)
        {
            this.Parameters.Add(Key, Value);
            return this;
        }

        public RequestBuilder SetMultipartParameter(string Key, string ValuePath)
        {
            this.MultipartParameter.SetObjects(Key, ValuePath);
            this.IsMultipart = true;
            return this;
        }

        public Request Build()
        {
            Request req = new Request();
            req.Url = Url;
            req.Parameters = this.Parameters;
            req.MultipartParameter = this.MultipartParameter;
            req.IsMultipart = IsMultipart;

            return req;
        }
    }
}

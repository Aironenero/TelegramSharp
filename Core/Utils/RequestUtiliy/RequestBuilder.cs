using System.Collections.Generic;

namespace TelegramSharp.Core.Utils
{
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
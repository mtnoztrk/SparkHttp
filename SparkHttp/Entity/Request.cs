using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkHttp.Entity
{
    public enum Type
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public class Request
    {
        private Dictionary<string,string> headers = new Dictionary<string, string>();

        public Guid Id { get; set; }
        public Type RequestType { get; set; }
        public Bitmap TypeIcon { get; set; }
        public string TargetAddress { get; set; }
        public Version RequestVersion { get; set; }
        public Dictionary<string, string> Headers { get => headers; set => headers = value; }
        public string Content { get; set; }
        public string RawText { get; set; }

        public Request()
        {
            Id = Guid.NewGuid();
        }
    }
}

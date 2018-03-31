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
        Get,
        Post,
        Put,
        Delete
    }
    public class Request
    {
        private NameValueCollection headers = new NameValueCollection();

        public Type RequestType { get; set; }
        public Bitmap TypeIcon { get; set; }
        public string TargetAddress { get; set; }
        public string Body { get; set; }
        public NameValueCollection Headers { get => headers; set => headers = value; }
    }
}

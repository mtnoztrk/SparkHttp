using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SparkHttp.Entity;

namespace SparkHttp.Service
{
    public abstract class BaseService : IService
    {
        public void FillHeaders(HttpWebRequest request, Request input)
        {
            foreach (KeyValuePair<string, string> header in input.Headers)
            {
                if (header.Key == "Host")
                    request.Host = header.Value;
                else if (header.Key == "Connection")
                {
                    if (header.Value == "keep-alive")
                        request.KeepAlive = true;
                    else
                        request.Connection = header.Value;
                }
                else if (header.Key == "Accept")
                {
                    request.Accept = header.Value;
                }
                else if (header.Key == "Content-Type")
                {
                    request.ContentType = header.Value;
                }
                else if (header.Key == "Content-Length")
                {
                    long.TryParse(header.Value, out long result);
                    request.ContentLength = result;
                }
                else
                    request.Headers[header.Key] = header.Value;
            }
        }
        public abstract Task<string> Send(Request request);
    }
}

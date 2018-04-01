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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void FillHeaders(HttpWebRequest request, Request input)
        {
            foreach (KeyValuePair<string, string> header in input.Headers)
            {
                if (header.Key == "Host")
                    request.Host = header.Value;
                else if (header.Key == "Connection")
                {
                    if (header.Value.ToLower() == "close")
                        request.KeepAlive = false;
                    else
                        request.KeepAlive = true;
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
                else if (header.Key == "If-Modified-Since")
                {
                    if (DateTime.TryParse(header.Value, out DateTime dt))
                        request.IfModifiedSince = dt;
                    else
                        log.Error($"Error parsing Date: {header.Value}");
                }
                else if (header.Key == "Referer")
                {
                    request.Referer = header.Value;
                }
                else if (header.Key == "Transfer-Encoding")
                {
                    if(header.Value.ToLower() == "chunked")
                        request.SendChunked = true;
                    else
                        request.TransferEncoding = header.Value;
                }
                else if (header.Key == "User-Agent")
                {
                    request.UserAgent = header.Value;
                }
                else if (header.Key == "Expect")
                {
                    if (header.Value.ToLower() == "100-continue")
                        request.ServicePoint.Expect100Continue = true;
                    else
                        request.ServicePoint.Expect100Continue = false;
                }
                else if (header.Key == "Date")
                {
                    if (DateTime.TryParse(header.Value, out DateTime dt))
                        request.Date = dt;
                    else
                        log.Error($"Error parsing Date: {header.Value}");
                }
                else
                {
                    try
                    {
                        request.Headers[header.Key] = header.Value;
                    }
                    catch (Exception ex)
                    {
                        log.Error($"Header: {header.Key}: {header.Value} is not added.\n{ex.ToString()}");
                    }
                }
            }
        }
        public abstract Task<string> Send(Request request);
    }
}

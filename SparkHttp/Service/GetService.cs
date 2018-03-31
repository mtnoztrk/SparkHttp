using SparkHttp.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparkHttp.Service
{
    public class GetService : IService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<string> Send(Request input)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(input.TargetAddress);
                request.Method = input.RequestType.ToString();
                //request.ContentType = "application/x-www-form-urlencoded";
                //request.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //request.Headers.Add(input.Headers);
                var items = input.Headers.AllKeys.SelectMany(input.Headers.GetValues, (k, v) => new { key = k, value = v });
                foreach (var item in items)
                {
                    if (item.key == "Host")
                        request.Host = item.value;
                    else if (item.key == "Connection")
                    {
                        if (item.value == "keep-alive")
                            request.KeepAlive = true;
                        else
                            request.Connection = item.value;
                    }
                    else if (item.key == "Accept")
                    {
                        request.Accept = item.value;
                    }
                    else
                        request.Headers[item.key] = item.value;
                }
                //byte[] _byteVersion = Encoding.ASCII.GetBytes(string.Concat("content=", dlc_content));

                //request.ContentLength = _byteVersion.Length;

                //Stream stream = request.GetRequestStream();
                //stream.Write(_byteVersion, 0, _byteVersion.Length);
                //stream.Close();

                var response = await request.GetResponseAsync();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                log.Error($"Connection error: {ex.ToString()}");
                return string.Empty;
            }
        }
    }
}

using SparkHttp.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SparkHttp.Service
{
    public class PostOrPutService : BaseService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override async Task<string> Send(Request input)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(input.TargetAddress);
                request.Method = input.RequestType.ToString();
                request.ProtocolVersion = input.RequestVersion;

                FillHeaders(request, input);

                byte[] contentBytes;
                if (request.ContentType == "application/octet-stream")
                    contentBytes = HexadecimalStringToByteArray_Rev4(input.Content);
                else
                    contentBytes = Encoding.ASCII.GetBytes(input.Content);
                //checking content length
                if (request.ContentLength != contentBytes.Length)
                {
                    request.ContentLength = contentBytes.Length;
                    log.Info("Content-Length overriden.");
                }

                Stream stream = request.GetRequestStream();
                stream.Write(contentBytes, 0, contentBytes.Length);
                stream.Close();

                var response = await request.GetResponseAsync();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                log.Error($"Connection error: {ex.ToString()}");
                return Resources.ErrorResource.ErrorSend;
            }
        }

        //taken from : https://stackoverflow.com/questions/311165/how-do-you-convert-a-byte-array-to-a-hexadecimal-string-and-vice-versa/26304129#26304129
        private static byte[] HexadecimalStringToByteArray_Rev4(string input)
        {
            var outputLength = input.Length / 2;
            var output = new byte[outputLength];
            using (var sr = new StringReader(input))
            {
                for (var i = 0; i < outputLength; i++)
                    output[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
            }
            return output;
        }
    }
}

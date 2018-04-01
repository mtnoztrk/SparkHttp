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
    public class DeleteService : BaseService
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
    }
}

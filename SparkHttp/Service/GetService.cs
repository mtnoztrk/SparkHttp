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
        public async Task Send(Request input)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(input.TargetAddress);
            request.Method = input.RequestType.ToString();
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            try
            {
                request.Headers.Add(input.Headers);

            }
            catch (Exception e)
            {

                throw e;
            }            //byte[] _byteVersion = Encoding.ASCII.GetBytes(string.Concat("content=", dlc_content));

            //request.ContentLength = _byteVersion.Length;

            //Stream stream = request.GetRequestStream();
            //stream.Write(_byteVersion, 0, _byteVersion.Length);
            //stream.Close();

            var response = await request.GetResponseAsync();

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                MessageBox.Show(reader.ReadToEnd());
            }
        }
    }
}

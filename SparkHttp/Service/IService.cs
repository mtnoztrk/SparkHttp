using SparkHttp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SparkHttp.Service
{
    public interface IService
    {
        void FillHeaders(HttpWebRequest request, Request input);
        //Request Parse(string input);
        Task<string> Send(Request request);
    }
}

using SparkHttp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkHttp.Service
{
    public interface IService
    {
        //Request Parse(string input);
        Task<string> Send(Request request);
    }
}

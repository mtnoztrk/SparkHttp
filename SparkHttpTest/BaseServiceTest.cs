using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkHttp.Entity;
using SparkHttp.Helper;
using SparkHttp.Service;

namespace SparkHttpTest
{
    [TestClass]
    public class BaseServiceTest
    {
        [TestMethod]
        public void FillHeadersTest()
        {
            string input = "GET http://localhost:8000/150m3w91 HTTP/1.1\n" +
                "Host: localhost:8000\n" +
                "Connection: keep-alive\n" +
                "Accept: text/html,application/xhtml+xml,application/xml?q=0.9,image/webp,*/*?q=0.8\n" +
                "UserAgent: Mozilla/5.0 (Windows NT 10.0? WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.109 Safari/537.36\n" +
                "AcceptEncoding: gzip, deflate\n" +
                "AcceptLanguage: enUS, en?q=0.8\n";
            Request request = RequestParser.Parse(input);
            IService service = ServiceFactory.GetService(request.RequestType);
            var response = service.Send(request);
            Assert.AreEqual("ok\n", response.Result);
        }
    }
}

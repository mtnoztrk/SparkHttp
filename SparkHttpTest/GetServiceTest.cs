using System;
using System.Configuration;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkHttp.Entity;
using SparkHttp.Helper;
using SparkHttp.Service;

namespace SparkHttpTest
{
    [TestClass]
    public class GetServiceTest
    {
        private string hostAddress;
        [TestInitialize()]
        public void Initialize()
        {
            hostAddress = ConfigurationManager.AppSettings["testUrl"];
        }

        [TestMethod]
        public void SendGetTest()
        {
            string input = $"GET {hostAddress} HTTP/1.1\n" +
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

        [TestMethod]
        public void SendGetTestFail()
        {
            string input = "GET http://denemeMetin.com HTTP/1.1\n" +
                "Host: localhost:8000\n" +
                "Connection: keep-alive\n" +
                "Accept: text/html,application/xhtml+xml,application/xml?q=0.9,image/webp,*/*?q=0.8\n" +
                "UserAgent: Mozilla/5.0 (Windows NT 10.0? WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.109 Safari/537.36\n" +
                "AcceptEncoding: gzip, deflate\n" +
                "AcceptLanguage: enUS, en?q=0.8\n";
            Request request = RequestParser.Parse(input);
            IService service = ServiceFactory.GetService(request.RequestType);
            var response = service.Send(request);
            Assert.AreEqual("Sending request failed!", response.Result);
        }
    }
}

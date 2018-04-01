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
    public class PostOrPutServiceTest
    {
        private string hostAddress;
        [TestInitialize()]
        public void Initialize()
        {
            hostAddress = ConfigurationManager.AppSettings["testUrl"];
        }

        [TestMethod]
        public void SendPostTestFail()
        {
            string input = $"POST {hostAddress} HTTP/1.1\n";
            Request request = RequestParser.Parse(input);
            IService service = ServiceFactory.GetService(request.RequestType);
            var response = service.Send(request);
            Assert.AreEqual("Sending request failed!", response.Result);
        }

        [TestMethod]
        public void SendPutTestFail()
        {
            string input = $"PUT {hostAddress} HTTP/1.1\n";
            Request request = RequestParser.Parse(input);
            IService service = ServiceFactory.GetService(request.RequestType);
            var response = service.Send(request);
            Assert.AreEqual("Sending request failed!", response.Result);
        }
        [TestMethod]
        public void SendPostTest()
        {
            string input = $"POST {hostAddress} HTTP/1.1\n" +
                "Content-Type: application/x-www-form-urlencoded\n" +
                "Content-Length: 32\n" +
                "\n" +
                "deneme=Deneme&deneme%20deneme=DenemeDeneme\n";
            Request request = RequestParser.Parse(input);
            IService service = ServiceFactory.GetService(request.RequestType);
            var response = service.Send(request);
            Assert.AreEqual("ok\n", response.Result);
        }

        [TestMethod]
        public void SendPutTest()
        {
            string input = $"PUT {hostAddress} HTTP/1.1\n" +
                "Content-Type: application/x-www-form-urlencoded\n" +
                "Content-Length: 44\n" +
                "\n" +
                "{\n" +
                "\"deneme\": \"Deneme\",\n" +
                "\"deneme deneme\": \"DenemeDeneme\"\n" +
                "}";
            Request request = RequestParser.Parse(input);
            IService service = ServiceFactory.GetService(request.RequestType);
            var response = service.Send(request);
            Assert.AreEqual("ok\n", response.Result);
        }
    }
}

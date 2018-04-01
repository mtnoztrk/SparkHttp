using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkHttp.Entity;
using SparkHttp.Helper;
using SparkHttp.Service;

namespace SparkHttpTest
{
    [TestClass]
    public class RequestParserTest
    {
        [TestMethod]
        public void RequestParserParse()
        {
            string input = "GET https://www.google.com/ HTTP/1.1\n" +
                "Host: www.google.com\n" +
                "Connection: keep-alive\n" +
                "Accept: text/html,application/xhtml+xml,application/xml?q=0.9,image/webp,*/*?q=0.8\n" +
                "UserAgent: Mozilla/5.0 (Windows NT 10.0? WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.109 Safari/537.36\n" +
                "AcceptEncoding: gzip, deflate\n" +
                "AcceptLanguage: enUS, en?q=0.8\n";
            Request request = RequestParser.Parse(input);
            Assert.AreEqual(SparkHttp.Entity.Type.GET, request.RequestType);
            Assert.AreEqual("https://www.google.com/", request.TargetAddress);
            Assert.AreEqual("www.google.com", request.Headers["Host"]);
            Assert.AreEqual("keep-alive", request.Headers["Connection"]);
            Assert.AreEqual("text/html,application/xhtml+xml,application/xml?q=0.9,image/webp,*/*?q=0.8", request.Headers["Accept"]);
            Assert.AreEqual("Mozilla/5.0 (Windows NT 10.0? WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.109 Safari/537.36", request.Headers["UserAgent"]);
            Assert.AreEqual("gzip, deflate", request.Headers["AcceptEncoding"]);
            Assert.AreEqual("enUS, en?q=0.8", request.Headers["AcceptLanguage"]);
        }

        [TestMethod]
        public void RequestParserParseContent()
        {
            string input = "POST http://localhost:8000/1bmyfxm1 HTTP/1.0\n" +
                "Content-Type: application/x-www-form-urlencoded\n" +
                "Content-Length: 32\n" +
                "\n" +
                "home=Cosby&favorite+flavor=flies\n";
            Request request = RequestParser.Parse(input);
            Assert.AreEqual(SparkHttp.Entity.Type.POST, request.RequestType);
            Assert.AreEqual("http://localhost:8000/1bmyfxm1", request.TargetAddress);
            Assert.AreEqual(HttpVersion.Version10, request.RequestVersion);
            Assert.AreEqual("application/x-www-form-urlencoded", request.Headers["Content-Type"]);
            Assert.AreEqual("32", request.Headers["Content-Length"]);
            Assert.AreEqual("home=Cosby&favorite+flavor=flies", request.Content);
        }

        [TestMethod]
        public void RequestParserParseContentJson()
        {
            string input = "PUT http://localhost:8000/1bmyfxm1 HTTP/1.0\n" +
                "Content-Type: application/x-www-form-urlencoded\n" +
                "Content-Length: 44\n" +
                "\n" +
                "{\n" +
                "\"home\": \"Cosby\",\n" +
                "\"favorete flavor\": \"flies\"\n" +
                "}";
            Request request = RequestParser.Parse(input);
            Assert.AreEqual(SparkHttp.Entity.Type.PUT, request.RequestType);
            Assert.AreEqual("http://localhost:8000/1bmyfxm1", request.TargetAddress);
            Assert.AreEqual(HttpVersion.Version10, request.RequestVersion);
            Assert.AreEqual("application/json", request.Headers["Content-Type"]);
            Assert.AreEqual("44", request.Headers["Content-Length"]);
            Assert.AreEqual("{\"home\": \"Cosby\",\"favorete flavor\": \"flies\"}", request.Content);
        }
    }
}

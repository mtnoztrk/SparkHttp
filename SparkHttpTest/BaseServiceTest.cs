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
                "Accept-Charset: iso-8859-5, unicode-1-1;q=0.8\n" +
                "Accept-Encoding: compress, gzip\n" +
                "Expires: Thu, 01 Dec 1994 16:00:00 GMT\n" +
                "If-Match: \"xyzzy\"" +
                "Connection: close\n" +
                "Content-Language: da\n" +
                "Content-Length: 3495\n" +
                "Content-Location\n" +
                "Content-Range: bytes 21010-47021/47022\n" +
                "Date: Tue, 15 Nov 1994 08:12:31 GMT\n" +
                "ETag: \"xyzzy\"\n" +
                "From: webmaster@w3.org\n" +
                "Host: www.w3.org\n" +
                "If-Modified-Since: Sat, 29 Oct 1994 19:43:31 GMT\n" +
                "If-None-Match: \"xyzzy\"\n" +
                "If-Unmodified-Since: Sat, 29 Oct 1994 19:43:31 GMT\n" +
                "Last-Modified: Tue, 15 Nov 1994 12:45:26 GMT\n" +
                "Location: http://www.w3.org/pub/WWW/People.html\n" +
                "Referer: http://www.w3.org/hypertext/DataSources/Overview.html\n" +
                "Retry-After: 120\n" +
                "Server: CERN/3.0 libwww/2.17\n" +
                "TE: trailers, deflate;q=0.5\n" +
                "Transfer-Encoding: chunked\n" +
                "Upgrade: HTTP/2.0, SHTTP/1.3, IRC/6.9, RTA/x11\n" +
                "User-Agent: CERN-LineMode/2.15 libwww/2.17b3\n" +
                "Via: 1.0 fred, 1.1 nowhere.com (Apache/1.1)\n" +
                "Expect: 100-continue\n" +
                "Warning: 199 Miscellaneous warning\n" +
                "WWW-Authenticate: Basic\n" +
                "Pragma: no-cache\n" +
                "Proxy-Authenticate: Basic\n" +
                "Proxy-Authorization: Basic QWxhZGRpbjpvcGVuIHNlc2FtZQ==\n" +
                "Trailer: Max-Forwards\n" +
                "Vary: *\n" +
                "Max-Forwards: 10\n" +
                "Authorization: Basic QWxhZGRpbjpvcGVuIHNlc2FtZQ==\n" +
                "Cookie: $Version=1; Skin=new;\n" +
                "Cache-Control: no-cache\n" +
                "Content-Encoding: gzip";
            Request request = RequestParser.Parse(input);
            IService service = ServiceFactory.GetService(request.RequestType);
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(request.TargetAddress);
            service.FillHeaders(httpRequest, request);
        }
    }
}

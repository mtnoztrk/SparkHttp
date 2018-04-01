using SparkHttp.Entity;
using SparkHttp.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparkHttp.Helper
{
    public class RequestParser
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Parse Http Request from raw request.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Request Parse(string input)
        {
            string firstLinePattern = @"(GET|POST|PUT|DELETE) (\S+) (\S+)";
            string headerPattern = @"([a-zA-Z0-9- ]+): (.+)";
            string contentPattern = @"((\w+(\+|%20)*\w*)=(\w+(\+|%20)*\w*)&*)";
            Request request = new Request();

            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            #region FirstLine
            if (!Regex.IsMatch(lines[0], firstLinePattern))
            {
                MessageBox.Show(ErrorResource.WrongInput);
                log.Error($"Error parsing line '{lines[0]}'");
                return null;
            }

            var regexResult = Regex.Split(lines[0], firstLinePattern);

            //getting type of the request.
            if (!Enum.TryParse(regexResult[1], out Entity.Type type))
            {
                MessageBox.Show(ErrorResource.NotSupported);
                log.Error($"Request type is not supported: '{regexResult[1]}'");
                return null;
            }

            request.RequestType = type;
            request.TargetAddress = regexResult[2];

            //getting type icon for grid view.
            request.TypeIcon = getTypeIcon(type);

            //getting request version
            if (regexResult[3] == "HTTP/1.1")
                request.RequestVersion = HttpVersion.Version11;
            else if (regexResult[3] == "HTTP/1.0")
                request.RequestVersion = HttpVersion.Version10;
            else
            {
                MessageBox.Show(ErrorResource.WrongInput);
                log.Error($"Wrong request version: '{regexResult[3]}'");
                return null;
            }
            #endregion

            #region ParsingLines
            //if content type is json this will be used.
            StringBuilder jsonContent = null;
            //if content type is octet-stream this will be used.
            StringBuilder binaryContent = null;
            //if there are any header lines.
            if (lines.Length > 1)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    if (Regex.IsMatch(lines[i], headerPattern))
                    {
                        var headerResult = Regex.Split(lines[i], headerPattern);
                        //overrides previous value if there are duplicate headers.
                        request.Headers[headerResult[1]] = headerResult[2];
                        //octet-stream is being used for binary data
                        if (headerResult[1] == "Content-Type" && headerResult[2] == "application/octet-stream")
                            binaryContent = new StringBuilder();
                    }
                    else if (binaryContent != null)
                    {
                        binaryContent.Append(lines[i]);
                    }
                    else if (Regex.Matches(lines[i], contentPattern).Count > 0) // content type application/x-www-form-urlencoded
                    {
                        request.Content = lines[i];
                        overrideHeader(request.Headers, "Content-Type", "application/x-www-form-urlencoded");
                    }
                    else if (lines[i].StartsWith("{") || jsonContent != null) // content type application/json
                    {
                        if (jsonContent == null)
                        {
                            jsonContent = new StringBuilder();
                            overrideHeader(request.Headers, "Content-Type", "application/json");
                        }
                        jsonContent.Append(lines[i]);
                    }
                    else
                    {
                        MessageBox.Show(ErrorResource.WrongInput);
                        log.ErrorFormat("Error parsing line '{0}'", lines[i]);

                    }
                }
            }
            if (binaryContent != null)
                request.Content = binaryContent.ToString();
            if (jsonContent != null)
                request.Content = jsonContent.ToString();
            #endregion

            //storing raw http request for saving.
            request.RawText = input;
            return request;
        }

        private static Bitmap getTypeIcon(Entity.Type type)
        {
            switch (type)
            {
                case Entity.Type.GET:
                    return Properties.Resources.get;
                case Entity.Type.POST:
                    return Properties.Resources.post;
                case Entity.Type.PUT:
                    return Properties.Resources.put;
                case Entity.Type.DELETE:
                    return Properties.Resources.delete;
                default:
                    return Properties.Resources.get;
            }
        }

        private static void overrideHeader(Dictionary<string, string> dictionary, string key, string value)
        {
            if (dictionary[key] != value)
            {
                dictionary[key] = value;
                log.Info($"Header: {key} overridden as '{value}'");
            }
        }
    }
}

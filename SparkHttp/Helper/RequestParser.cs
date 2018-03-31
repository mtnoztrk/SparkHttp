using SparkHttp.Entity;
using SparkHttp.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
            Request request = new Request();

            string[] lines = input.Split('\n');

            if (!Regex.IsMatch(lines[0], firstLinePattern))
            {
                MessageBox.Show(ErrorResource.WrongInput);
                log.Error($"Error parsing line '{lines[0]}'");
                return null;
            }

            var regexResult = Regex.Split(lines[0], firstLinePattern);

            //getting type of the request.
            if (Enum.TryParse(regexResult[1], out Entity.Type type))
            {
                MessageBox.Show(ErrorResource.NotSupported);
                log.Error($"Request type is not supported: '{regexResult[1]}'");
                return null;
            }
            
            request.RequestType = type;
            request.TargetAddress = regexResult[2];
            //getting type icon for grid view.
            request.TypeIcon = getTypeIcon(type);

            //if there any header lines.
            if (lines.Length > 1)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    if (!Regex.IsMatch(lines[i], headerPattern))
                    {
                        MessageBox.Show(ErrorResource.WrongInput);
                        log.Error($"Error parsing line '{lines[i]}'");
                    }
                    else
                    {
                        var headerResult = Regex.Split(lines[i], headerPattern);
                        request.Headers.Add(headerResult[1], headerResult[2]);
                    }
                } 
            }
            request.RawText = input;
            return request;
        }

        private static Bitmap getTypeIcon(Entity.Type type)
        {
            switch (type)
            {
                case Entity.Type.Get:
                    return Properties.Resources.get;
                case Entity.Type.Post:
                    return Properties.Resources.post;
                case Entity.Type.Put:
                    return Properties.Resources.put;
                case Entity.Type.Delete:
                    return Properties.Resources.delete;
                default:
                    return Properties.Resources.get;
            }
        }
    }
}

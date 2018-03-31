using SparkHttp.Entity;
using SparkHttp.Resources;
using System;
using System.Collections.Generic;
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
        public static Request Parse(string input)
        {
            string firstLinePattern = @"(GET|POST|PUT|DELETE) (\S+) (\S+)";
            string headerPattern = @"([a-zA-Z0-9- ]+): (.+)";
            Request request = new Request();

            string[] lines = input.Split('\n');

            if (!Regex.IsMatch(lines[0], firstLinePattern))
            {
                MessageBox.Show(ErrorResource.NotSupported);
                return null;
            }

            var regexResult = Regex.Split(lines[0], firstLinePattern);
            Enum.TryParse(regexResult[1], out Entity.Type type);
            request.RequestType = type;
            request.TargetAddress = regexResult[2];
            request.TypeIcon = getTypeIcon(type);

            for (int i = 1; i < lines.Length; i++)
            {
                if (!Regex.IsMatch(lines[i], headerPattern))
                    MessageBox.Show(string.Format(ErrorResource.WrongInput, lines[i]));
                else
                {
                    var headerResult = Regex.Split(lines[i], headerPattern);
                    request.Headers.Add(headerResult[1], headerResult[2]);
                }
            }

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

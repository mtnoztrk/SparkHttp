using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SparkHttp.Entity;
using SparkHttp.Resources;

namespace SparkHttp.Service
{
    public abstract class BaseService : IService
    {
        public Request Parse(string input)
        {
            string firstLinePattern = @"(GET|POST|PUT|DELETE) (\S+) (\S+)";
            string headerPattern = @"([a-zA-Z0-9- ]+): (.+)";
            Request request = new Request();

            string[] lines = input.Split('\n');

            if (!Regex.IsMatch(lines[0], firstLinePattern))
                MessageBox.Show(ErrorResource.NotSupported);

            var regexResult = Regex.Split(lines[0], firstLinePattern);
            Enum.TryParse(regexResult[1], out Entity.Type type);
            request.RequestType = type;
            request.TargetAddress = regexResult[2];

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

        public abstract Task Send(Request request);
    }
}

using System.Text.RegularExpressions;
using AwsAuthUtility.Infrastructure.Parsers.Interfaces;

namespace AwsAuthUtility.Infrastructure.Parsers
{
    public class CodeParser : IParser
    {
        public string Parse(string origin)
        {
            if (string.IsNullOrEmpty(origin)) return string.Empty;

            var parsedPattern = @"(\d{6})";
            var code = Regex.Match(origin, parsedPattern).Value;
            return code;   
        }
    }
}

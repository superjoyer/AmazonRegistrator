using AmazonRegistrator.Infrastructure.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace AmazonRegistrator.Infrastructure.Classes
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

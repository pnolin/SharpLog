using System.Collections.Generic;

namespace SharpLog.FrontEnd.Extensions
{
    public static class StringExtensions
    {
        public static Dictionary<string, string> ToDictionary(this string value, char itemsSeperator)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            var separated = value.Split(itemsSeperator);

            foreach (var item in separated)
            {
                var keyValue = item.Split("=");
                dictionary.Add(keyValue[0].Trim(), keyValue[1].Trim());
            }

            return dictionary;
        }
    }
}
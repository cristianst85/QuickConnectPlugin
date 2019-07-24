using System.Text.RegularExpressions;
using System.Web;

namespace QuickConnectPlugin.Commons
{
    public static class HttpUtilityEx
    {
        public static string UrlEncodeUpperCase(string value)
        {
            value = HttpUtility.UrlEncode(value);
            return Regex.Replace(value, "(%[0-9a-f][0-9a-f])", c => c.Value.ToUpper());
        }
    }
}

using System;

namespace QuickConnectPlugin
{
    public class RdpPlusOptionsParser
    {
        public static bool TryParse(String str, out RdpPlusOptions options)
        {
            return internalParse(str, out options);
        }

        private static bool internalParse(String str, out RdpPlusOptions options)
        {
            options = new RdpPlusOptions();
            if (str == null)
            {
                return false;
            }
            if (str.Trim().Length == 0)
            {
                return false;
            }
            String[] tokens = str.Split(';');
            foreach (String token in tokens)
            {
                if (token.Contains(":"))
                {
                    String[] optionNameValue = token.Split(':');

                    if (optionNameValue.Length != 2)
                    {
                        continue;
                    }

                    var xValue = optionNameValue[1].Trim().Trim('\"').Trim();
                    var xKey = optionNameValue[0].Trim();
                    if (xKey.Equals("rdgateway"))
                    {
                        options.RDGateway = xValue;
                    }
                    else if (xKey.Equals("useSameCredentials"))
                    {
                        options.UseSameCredentials = xValue == "yes";
                    }
                }
            }
            return true;
        }
    }
}
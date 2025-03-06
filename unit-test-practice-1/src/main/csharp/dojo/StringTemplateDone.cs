using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Dojo;

public class StringTemplate
{
    public string Render(string pattern, params object[] parameters)
    {
        if (pattern == null)
            return null; 

        return Regex.Replace(pattern, "\\$\\{(\\d+)\\}", match =>
        {
            int index = int.Parse(match.Groups[1].Value);
            if (index >= parameters.Length)
                return match.Value; 

            object value = parameters[index];
            if (value == null)
                return "";

            if (value is double or float or decimal)
            {
                return ((decimal)Convert.ToDouble(value)).ToString("0.00", new CultureInfo("hu-HU"));
            }

            if (value is DateTime dateTime)
                return dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);

            return value.ToString();
        });
    }
}

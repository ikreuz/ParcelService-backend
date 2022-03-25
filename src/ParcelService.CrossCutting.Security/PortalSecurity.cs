using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ParcelService.CrossCutting.Security
{
    public class PortalSecurity
    {
        private static readonly Regex StripTagsRegex = new Regex("<[^<>*>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex BadStatementRegex = new Regex(BadStatementExpression, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex[] RxListStrings = new[]
        {
            new Regex("<script[^>]*>.*?</script[^><]*>", RxOptions),
            new Regex("<script", RxOptions),
            new Regex("<input[^>]*>.*?</input[^><]*>", RxOptions),
            new Regex("<object[^>]*>.*?</object[^><]*>", RxOptions),
            new Regex("<embed[^>]*>.*?</embed[^><]*>", RxOptions),
            new Regex("<applet[^>]*>.*?</applet[^><]*>", RxOptions),
            new Regex("<form[^>]*>.*?</form[^><]*>", RxOptions),
            new Regex("<option[^>]*>.*?</option[^><]*>", RxOptions),
            new Regex("<select[^>]*>.*?</select[^><]*>", RxOptions),
            new Regex("<iframe[^>]*>.*?</iframe[^><]*>", RxOptions),
            new Regex("<iframe.*?<", RxOptions),
            new Regex("<iframe.*?", RxOptions),
            new Regex("<ilayer[^>]*>.*?</ilayer[^><]*>", RxOptions),
            new Regex("<form[^>]*>", RxOptions),
            new Regex("</form[^><]*>", RxOptions),
            new Regex("onerror", RxOptions),
            new Regex("onmouseover", RxOptions),
            new Regex("javascript:", RxOptions),
            new Regex("vbscript:", RxOptions),
            new Regex("unescape", RxOptions),
            new Regex("alert[\\s(&nbsp;)]*\\([\\s(&nbsp;)]*'?[\\s(&nbsp;)]*[\"(&quot;)]?", RxOptions),
            new Regex(@"eval*.\(", RxOptions),
            new Regex("onload", RxOptions),
        };

        const RegexOptions RxOptions = RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled;
        const string BadStatementExpression = ";|--|\bcreate\b|\bdrop\b|\bselect\b|\binsert\b|\bdelete\b|\bupdate\b|\bunion\b|sp_|xp_|\bexec\b|\bexecute\b|/\\*.*\\*/|\bdeclare\b|\bwaitfor\b|%|&";

        public enum FilterFlag
        {
            MultiLine = 1,
            Nomarkup = 2,
            NoScripting = 4,
            NoSQL = 8
        }

        public string InputFilter(string userInput, FilterFlag filterType)
        {
            if (userInput == null) return "";

            var tempInput = userInput;

            if ((filterType & FilterFlag.NoSQL) == FilterFlag.NoSQL) tempInput = FormatRemoveSQL(tempInput);

            if ((filterType & FilterFlag.Nomarkup) == FilterFlag.Nomarkup && IncludesMarkup(tempInput))
                tempInput = HttpUtility.HtmlEncode(tempInput);

            if ((filterType & FilterFlag.NoScripting) == FilterFlag.NoScripting)
                tempInput = FormatDisableScripting(tempInput);

            if ((filterType & FilterFlag.MultiLine) == FilterFlag.MultiLine)
                tempInput = FormatMultiLine(tempInput);

            return tempInput;
        }


        private static bool IncludesMarkup(string strInput)
        {
            return StripTagsRegex.IsMatch(strInput);
        }

        private string FormatDisableScripting(string strInput)
        {
            string tempInput = strInput;
            if (strInput == " " || String.IsNullOrEmpty(strInput)) return tempInput;
            tempInput = FilterString(tempInput);
            return tempInput;
        }

        private static string FilterString(string strInput)
        {
            string tempInput = strInput;
            const string replacement = " ";

            if (tempInput.Contains("&gt;") || tempInput.Contains("&lt;"))
            {
                tempInput = HttpUtility.HtmlDecode(tempInput);
                tempInput = RxListStrings.Aggregate(tempInput, (current, s) => s.Replace(current, replacement));

                tempInput = HttpUtility.HtmlEncode(tempInput);
            }
            else
            {
                tempInput = RxListStrings.Aggregate(tempInput, (current, s) => s.Replace(current, replacement));
            }

            return tempInput;
        }

        private static string FormatMultiLine(string strInput)
        {
            const string lbreak = "<br />";
            StringBuilder tempInput = new StringBuilder(strInput).Replace("\r\n", lbreak).Replace("\n", lbreak).Replace("\r", lbreak);
            return tempInput.ToString();
        }

        private static string FormatRemoveSQL(string strSQL)
        {
            return BadStatementRegex.Replace(strSQL, " ").Replace("'", "''");
        }
    }
}
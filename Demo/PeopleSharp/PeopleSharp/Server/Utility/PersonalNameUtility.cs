using System;
using System.Linq;
using System.Text;

namespace PeopleSharp.Shared.Utility
{
    public static class PersonalNameUtility
    {
        static PersonalNameUtility()
        {
            WhiteSpaceChars = new char[] { ' ', 't', '\n' };
        }

        public static string FormatShortInfo(string firstName, string lastName)
        {
            return CombineLastAndFirstName(CapitalizeEachWord(firstName), CapitalizeEachWord(lastName));
        }

        public static string CapitalizeEachWord(string inputText)
        {
            Func<string, string> capitalize = (string input) =>
            {
                StringBuilder sbOutput = new();

                for (int i = 0; i < input.Length; i++)
                {
                    if (i == 0 || (i > 0 && WhiteSpaceChars.Contains(input[i - 1])))
                        sbOutput.Append(char.ToUpper(input[i]));
                    else
                        sbOutput.Append(char.ToLower(input[i]));
                }

                return sbOutput.ToString();
            };

            return capitalize(inputText);
        }

        private static char[] WhiteSpaceChars { get; set; }

        private static string CombineLastAndFirstName(string firstName, string lastName)
        {
            return $"{lastName}; {firstName}";
        }
    }
}

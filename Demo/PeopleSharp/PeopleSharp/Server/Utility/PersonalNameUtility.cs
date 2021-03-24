using System;
using System.Linq;
using System.Text;

namespace PeopleSharp.Shared.Utility
{
    public class PersonalNameUtility
    {
        public PersonalNameUtility()
        {
            WhiteSpaceChars = new char[] { ' ', '\t', '\n' };
        }

        public string FormatShortInfo(string firstName, string lastName)
        {
            return CombineLastAndFirstName(CapitalizeEachWord(firstName), CapitalizeEachWord(lastName));
        }

        public string CapitalizeEachWord(string inputText)
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

        private char[] WhiteSpaceChars { get; set; }

        private string CombineLastAndFirstName(string firstName, string lastName)
        {
            return $"{lastName}, {firstName}";
        }
    }
}

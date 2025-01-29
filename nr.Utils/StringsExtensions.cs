
using System.Text.RegularExpressions;

namespace nr.Utils
{
    public static partial class StringsExtensions
    {
        public static bool IsFiscalCode(this string code) => IsValidFiscalCode(code);
        public static bool IsVatCode(this string code) => IsValidVatCode(code);

        public static string ToCamelCase(this string input) {
            string result = SearchForWord().Replace(input, match => match.Groups[1].Value.ToUpper());
            return char.ToLower(result[0]) + result.Substring(1);
        }
        public static IEnumerable<(char, int)> EnumerateChars(this string text, int startIndex = 0) {
            for (var i = startIndex; i < text.Length; i++) {
                yield return (text[i], i);
            }
        }

        public static string Slice(this string text, int start = 0, int end = 0) {
            if (start < 0) start = text.Length + start;
            if (end <= 0) end = text.Length + end;
            return text[start..end];
        }

        public static bool IsValidVatCode(string code) {
            if (code.Length != 11) return false;
            int sum = 0;
            foreach (var (c, i) in code.Slice(end: -1).EnumerateChars()) {
                if (i % 2 == 0) {
                    var v = (c - '0') * 2;
                    sum += v % 10 + v / 10;
                }
                else
                    sum += c - '0';
            }
            var control = (10 - sum % 10) % 10;
            return (control + '0') == code.Last();
        }

        public static bool IsValidFiscalCode(string code) {
            if (code.Length != 16) return false;
            int[] odds = [1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23];
            int sum = 0;
            foreach (var (c, i) in code.Slice(end: -1).EnumerateChars()) {
                if (char.IsLetter(c) || char.IsDigit(c)) {
                    var depl = char.IsDigit(c) ? c - '0' : c - 'A';
                    sum += (i % 2 == 0) ? odds[depl] : depl;
                }
            }
            return ((char)sum % 26 + 'A') == code.Last();
        }

        [GeneratedRegex(@"(?:^|[\s-_])(\w)")]
        private static partial Regex SearchForWord();
    }
}

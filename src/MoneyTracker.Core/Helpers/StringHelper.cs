using System.Linq;

namespace MoneyTracker.Core.Helpers
{
    public static class StringHelper
    {
        public static string ReadableAsciiOnly(string input)
        {
            return new string(input.Select(c => (c >= 32 && c <= 126) ? c : ' ').ToArray());
        }
    }
}

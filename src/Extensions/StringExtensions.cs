using System.Diagnostics;

namespace CSharpisms.Extensions
{
    [DebuggerStepThrough]
    public static class StringExtensions
    {
        public static string FormatWith(this string self, params object[] args)
        {
            return string.Format(self, args);
        }
    }
}
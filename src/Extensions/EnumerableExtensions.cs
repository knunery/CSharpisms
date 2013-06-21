using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CSharpisms.Extensions
{
    [DebuggerStepThrough]
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self)
                action(item);
        }

        public static bool MoreThanOne<T>(this IEnumerable<T> self)
        {
            return self.MoreThan(1);
        }

        public static bool MoreThan<T>(this IEnumerable<T> self, int count)
        {
            return self.Skip(count).Any();
        }
    }
}
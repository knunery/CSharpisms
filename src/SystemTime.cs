using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpisms
{
    // http://ayende.com/blog/3408/dealing-with-time-in-tests
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpHelpers
{
    /// <summary>
    /// http://csharpindepth.com/Articles/General/Singleton.aspx
    /// Double checked locking only works with the volatile keyword... there is a much cleaner way to make a "Singleton".
    /// </summary>
    public class ProperSingleton
    {
        private static readonly ProperSingleton instance = new ProperSingleton();

        static ProperSingleton() { } // optional: helps CLR guarantee initialized before first use

        private ProperSingleton()
        {
        }

        public static ProperSingleton Instance
        {
            get { return instance; }
        }
    }
}

using System;

namespace CsharpHelpers
{
    /// <summary>
    /// Usable only in .NET 4!
    /// </summary>
    public class LazySingleton
    {
        private static readonly Lazy<LazySingleton> instance = new Lazy<LazySingleton>(isThreadSafe: true);

        private LazySingleton()
        {
        }

        public static LazySingleton Instance
        {
            get { return instance.Value; }
        }
    }
}
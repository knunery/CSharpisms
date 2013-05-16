namespace CsharpHelpers
{
    /// <summary>
    /// Lazy singleton.
    /// </summary>
    public class Singleton
    {
        private static class SingletonHolder
        {
            internal static readonly Singleton instance = new Singleton();
            static SingletonHolder() { }
        }

        private Singleton() { }

        public static Singleton Instance
        {
            get { return SingletonHolder.instance; }
        }
    }
}
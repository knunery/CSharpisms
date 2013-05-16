using System;

namespace CsharpHelpers.GenericException
{
    [Serializable]
    public abstract class ExceptionArgs
    {
        public virtual String Message { get { return String.Empty; } }
    }
}
using System;

namespace CsharpHelpers.GenericException
{
    [Serializable]
    public sealed class DiskFullExceptionArgs : ExceptionArgs
    {
        private readonly String _diskpath; // private field set at construction time

        public DiskFullExceptionArgs(String diskpath) { _diskpath = diskpath; }

        // Public read-only property that returns the field
        public String DiskPath { get { return _diskpath; } }

        // Override the Message property to include our field (if set)
        public override String Message
        {
            get
            {
                return (_diskpath == null) ? base.Message : "DiskPath=" + _diskpath;
            }
        }
    }
}

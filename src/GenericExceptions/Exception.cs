using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CsharpHelpers.GenericException
{
    // From CLR book
    [Serializable]
    public sealed class Exception<TExceptionArgs> : Exception, ISerializable
       where TExceptionArgs : ExceptionArgs
    {

        private const String _cargs = "Args";  // For (de)serialization
        private readonly TExceptionArgs _args;

        public TExceptionArgs Args { get { return _args; } }
        public Exception(String message = null, Exception innerException = null)
            : this(null, message, innerException) { }

        public Exception(TExceptionArgs args, String message = null,
           Exception innerException = null)
            : base(message, innerException) { _args = args; }

        // The constructor is for deserialization; since the class is sealed, the constructor is
        // private. If this class were not sealed, this constructor should be protected
        [SecurityPermission(SecurityAction.LinkDemand,
           Flags = SecurityPermissionFlag.SerializationFormatter)]
        private Exception(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _args = (TExceptionArgs)info.GetValue(_cargs, typeof(TExceptionArgs));
        }

        // The method for serialization; it's public because of the ISerializable interface
        [SecurityPermission(SecurityAction.LinkDemand,
           Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(_cargs, _args);
            base.GetObjectData(info, context);
        }

        public override String Message
        {
            get
            {
                String baseMsg = base.Message;
                return (_args == null) ? baseMsg : baseMsg + " (" + _args.Message + ")";
            }
        }

        public override Boolean Equals(Object obj)
        {
            Exception<TExceptionArgs> other = obj as Exception<TExceptionArgs>;
            if (obj == null) return false;
            return Object.Equals(_args, other._args) && base.Equals(obj);
        }
        public override int GetHashCode() { return base.GetHashCode(); }
    }
}

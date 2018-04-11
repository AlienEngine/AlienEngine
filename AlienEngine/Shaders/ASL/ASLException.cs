using System;
using System.Runtime.Serialization;

namespace AlienEngine.Shaders.ASL
{
    [Serializable]
    internal class ASLException : Exception
    {
        public ASLException()
        { }

        public ASLException(string message) : base(message)
        { }

        public ASLException(string message, Exception inner) : base(message, inner)
        { }

        protected ASLException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
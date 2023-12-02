using System.Runtime.Serialization;

namespace AdventOfCode2023.Exceptions
{
    public class InvalidCubeColorException : Exception
    {
        public InvalidCubeColorException()
        {
        }

        public InvalidCubeColorException(string? message) : base(message)
        {
        }

        public InvalidCubeColorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCubeColorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

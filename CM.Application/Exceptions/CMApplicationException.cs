using System.Runtime.Serialization;

namespace CM.Application.Exceptions
{
    public class CMApplicationException : Exception
    {
        public CMApplicationException()
        {
        }

        public CMApplicationException(string message)
            : base(message)
        {
        }

        public CMApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CMApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

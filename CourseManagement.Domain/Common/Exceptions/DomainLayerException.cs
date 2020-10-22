using System;
using System.Runtime.Serialization;

namespace CourseManagement.Domain.Common.Exceptions
{
    [Serializable]
    public class DomainLayerException : CourseManagementException
    {
        public DomainLayerException() : base()
        {
        }

        public DomainLayerException(string message) : base(message)
        {
        }

        public DomainLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
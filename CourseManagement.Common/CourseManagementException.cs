using System;
using System.Runtime.Serialization;

namespace CourseManagement
{
    [Serializable]
    public class CourseManagementException : Exception
    {
        public CourseManagementException()
        {
        }

        public CourseManagementException(string message) : base(message)
        {
        }

        public CourseManagementException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CourseManagementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
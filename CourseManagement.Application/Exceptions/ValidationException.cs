using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseManagement.Application.Exceptions
{
    [Serializable]
    public class ValidationException : ApplicationLayerException
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public ValidationException(Dictionary<string, string> errors)
            : this()
        {
            Errors = errors
                .GroupBy(e => e.Key, e => e.Value)
                .ToDictionary(pair => pair.Key, x => x.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
using System;
using System.Linq;

namespace CourseManagement.Application.Validation
{
    public static class CustomValidation
    {
        public static bool CheckWhiteSpace(string text)
        {
            return !text.Any(x => Char.IsWhiteSpace(x));
        }
    }
}

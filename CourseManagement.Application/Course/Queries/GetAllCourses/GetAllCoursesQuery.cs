using MediatR;
using System.Collections.Generic;

namespace CourseManagement.Application.Course.Queries.GetAllCourses
{
    public sealed class GetAllCoursesQuery : IRequest<IEnumerable<CourseDto>>
    {
    }
}
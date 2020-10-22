using MediatR;
using System.Collections.Generic;

namespace CourseManagement.Application.Teacher.Queries.GetAllTeachers
{
    public sealed class GetAllTeachersQuery : IRequest<IEnumerable<TeacherDto>>
    {
    }
}
using MediatR;
using System.Collections.Generic;

namespace CourseManagement.Application.Student.Queries.GetAllStudents
{
    public sealed class GetAllStudentsQuery : IRequest<IEnumerable<StudentDto>>
    {
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CapgeminiUnitOfWork.Infrastructure.Repository.DataContext.Generic;
using Indra.Infrastructure.Data.Model;
using Indra.Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace Indra.Infrastructure.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<Student> UpdateAsync(int id, Student student)
        {
            var dbStudent = await _unitOfWork.Context.Student
                .FirstOrDefaultAsync(d => d.Id == id);

            if (student.Name != null)
                dbStudent.Name = student.Name;
            if (student.Surname != null)
                dbStudent.Surname = student.Surname;
            if (student.Age != null)
                dbStudent.Age = student.Age;
            if (student.Birthday != null)
                dbStudent.Birthday = student.Birthday;

            return dbStudent;
        }
    }
}
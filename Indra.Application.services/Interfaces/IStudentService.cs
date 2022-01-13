using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indra.Domain.Entities;

namespace Indra.Application.services.Interfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentEntity>> GetAll();

        public Task<StudentEntity> Get(int id);

        public Task<StudentEntity> Insert(StudentEntity studentEntity);

        public Task<StudentEntity> Remove(int id);

        public Task<StudentEntity> Update(int id, StudentEntity student);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indra.Infrastructure.Data.Model;
using Indra.Infrastructure.Repository.Interfaces;

namespace Indra.Infrastructure.Repository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
    }
}
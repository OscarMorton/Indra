using Indra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Application.services.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserEntity>> GetAll();
    }
}
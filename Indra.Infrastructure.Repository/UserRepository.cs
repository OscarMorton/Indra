using CapgeminiUnitOfWork.Infrastructure.Repository.DataContext.Generic;
using Indra.Infrastructure.Data.Model;
using Indra.Infrastructure.Repository.Generic;
using Indra.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<User> UpdateAsync(int id, User user)
        {
            var dbUser = await _unitOfWork.Context.User
                .FirstOrDefaultAsync(d => d.Id == user.Id);

            if (user.UserName != null)
                dbUser.UserName = user.UserName;
            if (user.Guid != null)
                dbUser.Guid = user.Guid;
            if (user.EmailId != null)
                dbUser.EmailId = user.EmailId;
            if (user.Password != null)
                dbUser.Password = user.Password;
            dbUser.Password = user.Password;

            return dbUser;
        }
    }
}
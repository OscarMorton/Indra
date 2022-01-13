using CapgeminiUnitOfWork.Infrastructure.Repository.DataContext.Generic;
using Indra.Application.services.Interfaces;
using Indra.Domain.Entities;
using Indra.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Application.services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserEntity>> GetAll()
        {
            var repositoryResult = await _userRepository.GetAllAsync();
            return UserEntity.MapFromUserModelList(repositoryResult);
        }
    }
}
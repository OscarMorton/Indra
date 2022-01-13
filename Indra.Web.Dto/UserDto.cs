using Indra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Web.Dto
{
    public class UserDto
    {
        public string UserName { get; set; }
        public Guid Guid { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public static UserEntity MapToUserEntity(UserDto userDto)
        {
            return new UserEntity
            {
                Guid = userDto.Guid,
                UserName = userDto.UserName,
                EmailId = userDto.EmailId,
                Password = userDto.Password
            };
        }

        public static UserDto MapFromUserEntity(UserEntity user)
        {
            return new UserDto
            {
                Guid = user.Guid,
                UserName = user.UserName,
                EmailId = user.EmailId,
                Password = user.Password
            };
        }

        public static IEnumerable<UserDto> MapFromUserEntityList(IEnumerable<UserEntity> userEntities)
        {
            List<UserDto> userDTOs = new List<UserDto>();
            foreach (var user in userEntities)
            {
                userDTOs.Add(MapFromUserEntity(user));
            }
            return userDTOs;
        }
    }
}
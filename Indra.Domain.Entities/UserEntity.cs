using Indra.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Domain.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Guid Guid { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public static UserEntity MapFromUserModel(User user)
        {
            if (user == null) return new UserEntity();

            return new UserEntity
            {
                
                Guid = user.Guid,
                UserName = user.UserName,
                EmailId = user.EmailId,
                Password = user.Password,
            };
        }

        public static User MapToUserDataModel(UserEntity userEntity)
        {
            return new User
            {
             
                Guid = userEntity.Guid,
                UserName = userEntity.UserName,
                EmailId = userEntity.EmailId,
                Password = userEntity.Password
            };
        }

        public static List<UserEntity> MapFromUserModelList(IEnumerable<User> users)
        {
            List<UserEntity> userEntities = new List<UserEntity>();
            foreach (var user in users)
            {
                userEntities.Add(MapFromUserModel(user));
            }
            return userEntities;
        }
    }
}
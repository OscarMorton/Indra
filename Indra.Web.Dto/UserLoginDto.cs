using Indra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Web.Dto
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public UserLoginDto()
        {
        }

        public static UserLoginEntity MapToUserLoginEntity(UserLoginDto userLogin)
        {
            return new UserLoginEntity
            {
                UserName = userLogin.UserName,
                Password = userLogin.Password
            };
        }
    }
}
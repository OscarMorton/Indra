﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Domain.Entities
{
    public class UserLoginEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public UserLoginEntity()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bole_To_Security.DataAccess
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserInRoles
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }

    public class ResponseObject
    {
        public bool IsRequestSuccessful { get; set; }
        public string Message { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
    }
}
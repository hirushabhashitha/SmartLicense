using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLicenseAdmin.Enum;

namespace SmartLicenseAdmin.Enum
{
    internal class UserRoleContainer // Renamed the enclosing class to avoid conflict
    {
        public enum UserRole
        {
            Admin = 1,
            User = 2
        }
    }
}

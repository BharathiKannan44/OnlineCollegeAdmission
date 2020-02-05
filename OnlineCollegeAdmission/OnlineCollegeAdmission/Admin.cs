
using System;

namespace OnlineCollegeAdmission
{
    class Admin
    {
        internal string adminId { get; set; }
        internal string name { get; set; }
        internal string password { get; set; }

        internal Admin(string adminId, string name, string password)
        {
            this.adminId = adminId;
            this.name = name;
            this.password = password;
        }
    }
}

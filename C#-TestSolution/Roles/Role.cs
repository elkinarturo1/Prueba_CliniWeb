using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roles
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Permission> Permissions { get; set; }
        public List<Role> Roles { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManagement.Common.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string TenVaiTro { get; set; } = string.Empty;
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}

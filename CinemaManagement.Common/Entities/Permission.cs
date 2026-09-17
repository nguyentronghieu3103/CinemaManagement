using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManagement.Common.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string MaQuyen { get; set; } = string.Empty;
        public string TenQuyen { get; set; } = string.Empty;

        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}

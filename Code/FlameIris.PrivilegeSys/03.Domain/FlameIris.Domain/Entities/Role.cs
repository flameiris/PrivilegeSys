using System;
using System.Collections.Generic;

namespace FlameIris.Domain.Enities
{
    public partial class Role : Entity<Int64>
    {
        public Role()
        {
            ManagerRoles = new HashSet<ManagerRole>();
            Privileges = new HashSet<Privilege>();
        }
        public string Title { get; set; }
        public string Remark { get; set; }
        public ICollection<ManagerRole> ManagerRoles { get; set; }
        public ICollection<Privilege> Privileges { get; set; }
    }
}

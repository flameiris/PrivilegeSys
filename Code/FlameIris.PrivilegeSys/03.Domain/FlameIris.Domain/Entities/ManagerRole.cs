using System;
using System.Collections.Generic;

namespace FlameIris.Domain.Enities
{
    public partial class ManagerRole
    {
        public long Id { get; set; }
        public long ManagerId { get; set; }
        public long RoleId { get; set; }
    }
}

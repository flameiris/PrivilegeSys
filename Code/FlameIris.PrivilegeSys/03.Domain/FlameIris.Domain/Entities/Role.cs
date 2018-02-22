using System;
using System.Collections.Generic;

namespace FlameIris.Domain.Enities
{
    public partial class Role : Entity<Int64>
    {
        public string Title { get; set; }
        public string Remark { get; set; }
    }
}

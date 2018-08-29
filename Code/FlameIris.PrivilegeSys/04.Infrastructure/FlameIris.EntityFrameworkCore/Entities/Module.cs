using System;
using System.Collections.Generic;

namespace FlameIris.EntityFrameworkCore.Enities
{
    public partial class Module : Entity<Int64>
    {
        public long ParentId { get; set; }
        public string Title { get; set; }
        public int ModuleType { get; set; }
        public int Layer { get; set; }
    }
}

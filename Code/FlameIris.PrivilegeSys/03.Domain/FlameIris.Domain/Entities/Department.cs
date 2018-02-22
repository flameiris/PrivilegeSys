using System;
using System.Collections.Generic;

namespace FlameIris.Domain.Enities
{
    public partial class Department : Entity<Int64>
    {
        public long ParentId { get; set; }
        public string Title { get; set; }
        public int DeptType { get; set; }
        public int Layer { get; set; }
        public string Remark { get; set; }
    }
}

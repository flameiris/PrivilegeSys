using System;
using System.Collections.Generic;

namespace FlameIris.Domain.Enities
{
    public partial class Role
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
    }
}

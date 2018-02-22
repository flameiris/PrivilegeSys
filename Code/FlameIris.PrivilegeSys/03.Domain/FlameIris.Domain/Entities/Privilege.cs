using System;
using System.Collections.Generic;
namespace FlameIris.Domain.Enities
{
    public partial class Privilege : Entity<Int64>
    {
        public byte Master { get; set; }
        public byte MasterValue { get; set; }
        public byte Access { get; set; }
        public byte AccessValue { get; set; }
        public byte Operation { get; set; }
    }
}

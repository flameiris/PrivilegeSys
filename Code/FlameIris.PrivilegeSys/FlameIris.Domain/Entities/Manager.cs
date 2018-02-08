using System;
using System.Collections.Generic;

namespace FlameIris.Domain.Enities
{
    public partial class Manager : Entity<Int64>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public long? DeptId { get; set; }
    }
}

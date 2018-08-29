using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Application.ManagerApp.Dtos
{
    public class ManagerDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public long? DeptId { get; set; }
    }
}

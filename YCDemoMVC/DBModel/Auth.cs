using System;
using System.Collections.Generic;

namespace YCDemoMVC.DBModel
{
    public partial class Auth
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}

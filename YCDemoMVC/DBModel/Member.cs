using System;
using System.Collections.Generic;

namespace YCDemoMVC.DBModel
{
    public partial class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Sex { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string IdentityNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace YCDemoMVC.DBModel
{
    public partial class AuthDetail
    {
        public int Id { get; set; }
        public int AuthId { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public byte[]? Picture { get; set; }
        public string? EnglishName { get; set; }
        public string? Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public string? SubscriptionNews { get; set; }
    }
}

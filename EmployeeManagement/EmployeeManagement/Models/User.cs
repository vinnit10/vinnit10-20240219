﻿namespace EmployeeManagement.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
    }
}

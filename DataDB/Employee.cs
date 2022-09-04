using System;
using System.Collections.Generic;

namespace AngularWebAPIProject.DataDB
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public double? Salary { get; set; }
        public string? Userpassword { get; set; }
    }
}

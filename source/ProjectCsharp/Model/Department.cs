using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectCsharp.Model
{
    public class Department
    {
        public Department(string name)
        {
            DepartmentName = name;
        }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}

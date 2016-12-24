using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectCsharp.Model
{
    public class Student
    {
        public string StudentId{get;set;}
        public string StudentName { get; set; }
        public string Email { get; set; }
        public Student(string id, string name, string email)
        {
            StudentId = id;
            StudentName = name;
            Email = email;
        }
    }
}

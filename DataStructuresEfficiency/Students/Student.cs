using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Student
    {
        public Student(string firstName, string lastName, string course)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Course = course;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Course { get; set; }

        public override string ToString()
        {
            return string.Format($" {this.Course}\t {this.FirstName}\t {this.LastName}");
        }
    }
}

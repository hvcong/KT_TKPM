using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Student
    {

        public long id { get; set; }
        public string name { get; set; }

        public Student(long id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}

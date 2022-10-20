using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student1
{
    [Serializable]
    public class Student1
    {
        public long id { get; set; }
        public string name { get; set; }

        public Student1() { }

        public Student1(long id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return "Name: " + this.name + ", id: " + this.id;
        }
    }

    
}

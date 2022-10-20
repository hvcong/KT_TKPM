using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    [Serializable]
    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }

        public Person() { }

        public Person(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}

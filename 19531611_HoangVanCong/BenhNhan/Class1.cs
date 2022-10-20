using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhNhan
{
    [Serializable]
    public class BenhNhan
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cmnd { get; set; }

        public BenhNhan() { }

        public BenhNhan(int id, string name, string cmnd)
        {
            this.id = id;
            this.name = name;
            this.cmnd = cmnd;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhNhanSpace
{
    [Serializable]
    public class BenhNhan
    {
        public BenhNhan(string msbn, string cmnd, string hoten, string diachi)
        {
            this.msbn = msbn;
            this.cmnd = cmnd;
            this.hoten = hoten;
            this.diachi = diachi;
        }

        public BenhNhan()
        {

        }

        public string msbn { get; set; }
        public string cmnd { get; set; }
        public string hoten { get; set; }
        public string diachi { get; set; }

    }
}

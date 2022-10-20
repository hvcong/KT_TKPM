using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacSiClass
{
    [Serializable]
    public class BacSi
    {

        public BacSi(string msbs, string hoten)
        {
            this.msbs = msbs;
            this.hoten = hoten;
        }

        public BacSi()
        {

        }

        string msbs { get; set; }
        string hoten { get; set; }

    }
}

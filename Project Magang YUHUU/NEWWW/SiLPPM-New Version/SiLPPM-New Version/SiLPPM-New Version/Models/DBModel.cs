using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiLPPM_New_Version.Models
{
    public class DBModel
    {
    }
    public class DBOutput
    {
        public bool status { get; set; }
        public string pesan { get; set; }
        public dynamic data { get; set; }
    }
}
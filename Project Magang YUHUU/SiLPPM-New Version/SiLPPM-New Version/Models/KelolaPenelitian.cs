using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiLPPM_New_Version.Models
{
    public class KelolaPenelitian
    {
        public int ID_PROPOSAL
        {
            get;set;
        }
        public int NPP
        {
            get;set;
        }

    }
    public class DetailKelolaReviewer
    {

        public int id_proposal
        {
            get; set;
        }
        public string reviewer1
        {
            get; set;
        }
        public string reviewer2
        {
            get; set;
        }
        public string judulProposal
        {
            get; set;
        }
        public string namaDosen
        {
            get; set;
        }

    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace silppm_v1e2.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_FEEDBACK_PENELITIAN
    {
        public int ID_FEEDBACK { get; set; }
        public int ID_PROPOSAL { get; set; }
        public string NPP { get; set; }
        public string FEEDBACK { get; set; }
        public Nullable<System.DateTime> TANGGAL { get; set; }
        public string STATUS { get; set; }
    }
}
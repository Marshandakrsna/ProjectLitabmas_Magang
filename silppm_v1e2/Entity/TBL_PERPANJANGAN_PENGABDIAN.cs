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
    
    public partial class TBL_PERPANJANGAN_PENGABDIAN
    {
        public int ID_PERPANJANGAN { get; set; }
        public int ID_PROPOSAL { get; set; }
        public Nullable<int> KE { get; set; }
        public Nullable<System.DateTime> TGL_MULAI_PERPANJANG { get; set; }
        public Nullable<System.DateTime> TGL_SELESAI_PERPANJANG { get; set; }
        public Nullable<System.DateTime> INSERT_DATE { get; set; }
        public string IP_ADDRESS { get; set; }
        public string USER_ID { get; set; }
    }
}
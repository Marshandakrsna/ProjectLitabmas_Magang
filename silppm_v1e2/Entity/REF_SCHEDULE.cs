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
    
    public partial class REF_SCHEDULE
    {
        public int ID_SCHEDULE { get; set; }
        public Nullable<System.DateTime> AWAL { get; set; }
        public Nullable<System.DateTime> AKHIR { get; set; }
        public Nullable<int> ID_TAHUN_ANGGARAN { get; set; }
        public Nullable<bool> IS_LOCKED { get; set; }
    }
}
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
    
    public partial class TBL_LAP_MONEV_PENELITIAN
    {
        public int ID_MONEV { get; set; }
        public int ID_PROPOSAL { get; set; }
        public string NPP { get; set; }
        public Nullable<int> NO_UPDATE { get; set; }
        public Nullable<System.DateTime> TANGGAL_UPLOAD { get; set; }
        public byte[] KETERANGAN { get; set; }
    }
}

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
    
    public partial class REF_PENGELUARAN_RAB
    {
        public REF_PENGELUARAN_RAB()
        {
            this.TBL_RAB_PENELITIAN = new HashSet<TBL_RAB_PENELITIAN>();
        }
    
        public int ID_PENGELUARAN_RAB { get; set; }
        public string KATEGORI { get; set; }
        public string DESKRIPSI { get; set; }
        public Nullable<decimal> MIN_PCT { get; set; }
        public Nullable<decimal> MAX_PCT { get; set; }
    
        public virtual ICollection<TBL_RAB_PENELITIAN> TBL_RAB_PENELITIAN { get; set; }
    }
}
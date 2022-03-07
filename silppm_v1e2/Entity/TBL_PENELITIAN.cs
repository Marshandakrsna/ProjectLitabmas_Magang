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
    
    public partial class TBL_PENELITIAN
    {
        public TBL_PENELITIAN()
        {
            this.TBL_OUTCOME_PENELITIAN = new HashSet<TBL_OUTCOME_PENELITIAN>();
            this.TBL_PUBLIKASI_SEMINAR = new HashSet<TBL_PUBLIKASI_SEMINAR>();
            this.TBL_PUBLIKASI_JURNAL = new HashSet<TBL_PUBLIKASI_JURNAL>();
            this.TBL_OUTPUT_PENELITIAN = new HashSet<TBL_OUTPUT_PENELITIAN>();
        }
    
        public int ID_PROPOSAL { get; set; }
        public int ID_KATEGORI { get; set; }
        public int ID_TAHUN_ANGGARAN { get; set; }
        public Nullable<int> NO_SEMESTER { get; set; }
        public Nullable<int> ID_ROAD_MAP_PENELITIAN { get; set; }
        public Nullable<int> ID_SKIM { get; set; }
        public string JENIS { get; set; }
        public string JUDUL { get; set; }
        public string LOKASI { get; set; }
        public string NPP { get; set; }
        public string NPP1 { get; set; }
        public string NPP2 { get; set; }
        public Nullable<System.DateTime> AWAL { get; set; }
        public Nullable<System.DateTime> AKHIR { get; set; }
        public bool IS_CHECKED { get; set; }
        public string REVIEWER1 { get; set; }
        public string REVIEWER2 { get; set; }
        public Nullable<int> BEBAN_SKS { get; set; }
        public Nullable<int> ID_STATUS_PENELITIAN { get; set; }
        public Nullable<decimal> DANA_USUL { get; set; }
        public Nullable<decimal> DANA_PRIBADI { get; set; }
        public Nullable<decimal> DANA_EKSTERNAL { get; set; }
        public Nullable<decimal> DANA_KERJASAMA { get; set; }
        public Nullable<decimal> DANA_UAJY { get; set; }
        public byte[] DOKUMEN { get; set; }
        public byte[] LEMBAR_PENGESAHAN { get; set; }
        public Nullable<bool> IS_DROPPED { get; set; }
        public string KEYWORD { get; set; }
        public Nullable<double> JARAK_KAMPUS_KM { get; set; }
        public Nullable<int> JARAK_KAMPUS_JAM { get; set; }
        public string OUTCOME { get; set; }
        public string LONGITUDE { get; set; }
        public string LATITUDE { get; set; }
        public Nullable<bool> IS_SETUJU_PRODI { get; set; }
        public Nullable<bool> IS_SETUJU_DEKAN { get; set; }
        public Nullable<int> BEBAN_SKS_ANGGOTA { get; set; }
        public Nullable<bool> IS_SETUJU_LPPM { get; set; }
        public string NPP_REVIEWER { get; set; }
        public Nullable<decimal> DANA_SETUJU { get; set; }
        public Nullable<System.DateTime> INSERT_DATE { get; set; }
        public string IP_ADDRESS { get; set; }
        public string USER_ID { get; set; }
        public Nullable<int> ID_TEMA_UNIVERSITAS { get; set; }
        public Nullable<bool> IS_LOCK { get; set; }
        public string KETERANGAN_DANA_EKSTERNAL { get; set; }
        public Nullable<decimal> PAJAK { get; set; }
        public Nullable<int> ID_JENIS_PENELITIAN { get; set; }
    
        public virtual ICollection<TBL_OUTCOME_PENELITIAN> TBL_OUTCOME_PENELITIAN { get; set; }
        public virtual ICollection<TBL_PUBLIKASI_SEMINAR> TBL_PUBLIKASI_SEMINAR { get; set; }
        public virtual ICollection<TBL_PUBLIKASI_JURNAL> TBL_PUBLIKASI_JURNAL { get; set; }
        public virtual ICollection<TBL_OUTPUT_PENELITIAN> TBL_OUTPUT_PENELITIAN { get; set; }
        public virtual REF_JENIS_PENELITIAN REF_JENIS_PENELITIAN { get; set; }
    }
}

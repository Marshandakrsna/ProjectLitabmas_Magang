using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace silppm_v1e2.Entity
{
    public class PropPen
    {

        private string Npp, id_jenis, id_schedule, id_rev1, id_rev2, judul, bidang, lokasi, keyword, outcome, longitude, latitude, anggota1, anggota2, ip_address, userid;

        
        private int id_prop, dana, sks, sksAnggota, sesuaiUNIT, jarakJAM, danaPribadi, isLPPM, isPustaka, kategori, id_approval;

        
        private bool status,cek_rev;
        private object dokumen,laporan;
        private DateTime awal, akhir, insert_date;
        
        private float jarakKM;

        public PropPen(){
            id_prop=0;
            Npp = "";
            id_jenis="";
            id_schedule="";
            cek_rev = false;
            id_rev1="";
            id_rev2="";
            id_approval=0;
        judul="";
            bidang="";
            kategori=0;
            lokasi="";
            dokumen = null;
            laporan = null;
            dana=0;
            awal = DateTime.Today;
            akhir = DateTime.Today;
            sks=0;
            status=false;
            keyword = ""; sesuaiUNIT = 0; outcome = ""; longitude = ""; latitude = "";
            jarakKM = 0; jarakJAM = 0; danaPribadi = 0; isLPPM = 0; isPustaka = 0;
            anggota1 = ""; anggota2 = ""; sksAnggota = 0;

        }
        public PropPen(int _idprop,string _npp,string _idjenis, string _idsch,bool _idsum,string _idrev1,string _idrev2,
            int _idapprov, string _judul, string _bidang, int _kategori, string _lokasi, object _dok, int _dana, 
            int _sks,  bool _status,DateTime _awal, DateTime _akhir,string _keyword,int _UNIT,string _TRACK, string _AGENDA,
            string _longi, string _lati, float _jarakKM, int _jarakJam, int _danaP, string _anggota1, string _anggota2, object _lap, int _isLppm, int _isPustaka, int _sksAnggota)
        {
            id_prop = _idprop;
            Npp = _npp;
            id_jenis = _idjenis;
            id_schedule = _idsch;
            cek_rev = _idsum;
            id_rev1 = _idrev1;
            id_rev2 = _idrev2;
            id_approval = _idapprov;
            judul = _judul;
            bidang = _bidang;
            kategori = _kategori;
            lokasi = _lokasi;
            dokumen = _dok;
            awal = _awal;
            akhir = _akhir;
            dana = _dana;
            sks = _sks;
            status = _status;
            keyword = _keyword; sesuaiUNIT = _UNIT; outcome = _TRACK;  longitude = _longi; latitude = _lati;

            jarakKM = _jarakKM; jarakJAM = _jarakJam; danaPribadi = _danaP;

            anggota1 = _anggota1; anggota2 = _anggota2;
            laporan = _lap; isLPPM = _isLppm; isPustaka = _isPustaka;
            sksAnggota = _sksAnggota;
        }
        public int ID_prop {
            get { return id_prop; }
            set { id_prop = value; }
        }
        public string Anggota1
        {
            get { return anggota1; }
            set { anggota1 = value; }
        }
        public string Anggota2
        {
            get { return anggota2; }
            set { anggota2 = value; }
        }
        public string NPP
        {
            get { return Npp; }
            set { Npp = value; }
        }
        public string ID_jenis
        {
            get { return id_jenis; }
            set { id_jenis = value; }
        }
        public string ID_Schedule
        {
            get { return id_schedule; }
            set { id_schedule = value; }
        }
        public bool Cek_Rev
        {
            get { return cek_rev; }
            set { cek_rev = value; }
        }
        public string ID_Review1
        {
            get { return id_rev1; }
            set { id_rev1 = value; }
        }
        public string ID_Review2
        {
            get { return id_rev2; }
            set { id_rev2 = value; }
        }
        public int ID_Approval
        {
            get { return id_approval; }
            set { id_approval = value; }
        }
        public string Judul {
            get
            {
                return judul;
            }

            set
            {
                judul = value;
            }
        
        }
        public int SksAnggota
        {
            get { return sksAnggota; }
            set { sksAnggota = value; }
        }
        public string Bidang {
            get
            {
                return bidang;
            }

            set
            {
                bidang = value;
            }
        }
        public int Kategori {
            get
            {
                return kategori;
            }

            set
            {
                kategori = value;
            }
        }
        public string Lokasi {
            get
            {
                return lokasi;
            }

            set
            {
                lokasi = value;
            }
        }
        public DateTime Awal
        {
            get { return awal; }
            set { awal = value; }
        }
        public DateTime Akhir
        {
            get { return akhir; }
            set { akhir = value; }
        }
        public object Dokumen {
            get {
                return dokumen;
            }
            set {
                dokumen = value;
            }
        }
        public object Laporan
        {
            get
            {
                return laporan;
            }
            set
            {
                laporan = value;
            }
        }
        public int Dana {
            get
            {
                return dana;
            }

            set
            {
                dana = value;
            }
        }
        public int Sks {
            get
            {
                return sks;
            }

            set
            {
                sks = value;
            }
        }
        public bool Status {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
        
        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }
        public int SesuaiUnit
        {
            get { return sesuaiUNIT; }
            set { sesuaiUNIT = value; }
        }
        public string Outcome
        {
            get { return outcome; }
            set { outcome = value; }
        }
        
        //keyword = ""; sesuaiUNIT = ""; outcome = ""; sesuaiAGENDA = ""; longitude = ""; latitude = "";
        //jarakKM = 0; jarakJAM = 0; danaPribadi = 0;
        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        public string Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        public float JarakKM
        {
            get { return jarakKM; }
            set { jarakKM = value; }
        }
        public int JarakJAM
        {
            get { return jarakJAM; }
            set { jarakJAM = value; }
        }
        public int DanaPribadi
        {
            get { return danaPribadi; }
            set { danaPribadi = value; }
        }
        public int IsLPPM
        {
            get { return isLPPM; }
            set { isLPPM = value; }
        }
        public int IsPustakawan
        {
            get { return isPustaka; }
            set { isPustaka = value; }
        }
        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        public string Ip_address
        {
            get { return ip_address; }
            set { ip_address = value; }
        }
        public DateTime Insert_date
        {
            get { return insert_date; }
            set { insert_date = value; }
        }
    }
}
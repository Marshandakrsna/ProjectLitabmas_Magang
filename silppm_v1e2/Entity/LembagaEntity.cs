using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace silppm_v1e2.Entity
{
    

    public class LembagaEntity
    {
        private string id_lembaga;
        private string namalembaga;
        private string alamat;
        private int no_telefon,fax;
        private string email;
        public LembagaEntity()
        { 
        id_lembaga="";
        namalembaga="";
        alamat="";
        no_telefon = 0;
            fax=0;
        email="";
        }
        public LembagaEntity(string _id,string _nm, string _alm, string _em, int _no, int _fx)
        {
            id_lembaga = _id;
            namalembaga = _nm;
            alamat = _alm;
            no_telefon = _no;
            fax = _fx;
            email = _em;
        }
        public string IDlembaga {
            get
            {
                return id_lembaga;
            }

            set
            {
                id_lembaga = value;
            }
        }
        public string NamaLbg
        {
            get
            {
                return namalembaga;
            }

            set
            {
                namalembaga = value;
            }
        }
        public string Alamat
        {
            get
            {
                return alamat;
            }

            set
            {
                alamat = value;
            }
        }
        public int Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }
        }
        public int Telefon
        {
            get
            {
                return no_telefon;
            }

            set
            {
                no_telefon = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P9_714240032.model
{
    internal class M_mahasiswa
    {
        string npm, nama, angkatan, alamat, email, no_hp;

        public M_mahasiswa()
        { 
        
        }

        public M_mahasiswa(string npm, string nama, string angkatan, string alamat, string email, string no_hp)
        {
            this.Npm = npm;
            this.Nama = nama;
            this.Angkatan = angkatan;
            this.Alamat = alamat;
            this.Email = email;
            this.No_hp = no_hp;
        }

        public string Npm { get => npm; set => npm = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Angkatan { get => angkatan; set => angkatan = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Email { get => email; set => email = value; }
        public string No_hp { get => no_hp; set => no_hp = value; }
    }
}

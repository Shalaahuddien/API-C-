using System;
using System.Collections.Generic;

namespace Mendata.Net.Datas.Entities
{
    public partial class User
    {
        public User()
        {
            Pembelis = new HashSet<Pembeli>();
            Penjuals = new HashSet<Penjual>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Tipe { get; set; }

        public virtual ICollection<Pembeli> Pembelis { get; set; }
        public virtual ICollection<Penjual> Penjuals { get; set; }
    }
}
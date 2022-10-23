using System;
using System.Collections.Generic;

namespace Mendata.Net.Datas.Entities
{
    public partial class Penjual
    {
        public Penjual()
        {
            Barangs = new HashSet<Barang>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public string NamaToko { get; set; }
        public string Alamat { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Barang> Barangs { get; set; }
    }
}
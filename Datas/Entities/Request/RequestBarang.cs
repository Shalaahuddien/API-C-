using System;
using System.Collections.Generic;

namespace Mendata.Net.Datas.Entities.Request
{
    public partial class RequestBarang
    {
        public string Kode { get; set; }
        public string Nama { get; set; }
        public string Description { get; set; }
        public decimal Harga { get; set; }
        public int Stok { get; set; }
        public int IdPenjual { get; set; }

    }
}
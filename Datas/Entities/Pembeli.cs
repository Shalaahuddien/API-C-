using System;
using System.Collections.Generic;

namespace Mendata.Net.Datas.Entities
{
    public partial class Pembeli
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string NamaPembeli { get; set; }
        public string AlamatPembeli { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
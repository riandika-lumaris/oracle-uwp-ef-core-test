using System;
using System.Collections.Generic;

namespace App4CD.Core.Models
{
    public partial class Hbeli
    {
        public Hbeli()
        {
            Dbeli = new HashSet<Dbeli>();
        }

        public string Notabeli { get; set; }
        public string Kodesup { get; set; }
        public DateTime? Tanggal { get; set; }

        public virtual Supplier KodesupNavigation { get; set; }
        public virtual ICollection<Dbeli> Dbeli { get; set; }
    }
}

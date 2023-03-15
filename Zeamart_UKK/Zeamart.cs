using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeamart_UKK
{
    class Zeamart
    {
        public string nama_barang { get; set; }
        public int harga_barang { get; set; }
        public int jumlah_barang { get; set; }
        public string satuan_barang { get; set; }

        public Zeamart(string nama_barang, int harga_barang, int jumlah_barang, string satuan_barang)
        {
            this.nama_barang = nama_barang;
            this.harga_barang = harga_barang;
            this.jumlah_barang = jumlah_barang;
            this.satuan_barang = satuan_barang;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeamart_UKK
{
    public partial class FormTambah : Form
    {
        private readonly MainForm _parent;
        public string id, nama_barang, harga_barang, jumlah_barang, satuan_barang;

        public FormTambah(MainForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UbahDataInfo()
        {
            lblTxtTambah.Text = "Ubah Barang";
            btnSimpan.Text = "Ubah";
            txtNama.Text = nama_barang;
            txtHarga.Text = harga_barang;
            txtJumlah.Text = jumlah_barang;
            txtSatuan.Text = satuan_barang;
        }

        public void SimpanInfo()
        {
            lblTxtTambah.Text = "Tambah Barang";
            btnSimpan.Text = "Simpan";
        }

        public void Bersihkan()
        {
            txtNama.Text = txtHarga.Text = txtJumlah.Text = txtSatuan.Text = string.Empty;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if(txtNama.Text.Trim().Length < 1)
            {
                MessageBox.Show("Nama Barang tidak boleh kosong");
                return;
            }
            else if (txtHarga.Text.Trim().Length < 1)
            {
                MessageBox.Show("Harga Barang tidak boleh kosong");
                return;
            }
            else if (txtJumlah.Text.Trim().Length < 1)
            {
                MessageBox.Show("Jumlah Barang tidak boleh kosong");
                return;
            }
            else if (txtSatuan.Text.Trim().Length < 1)
            {
                MessageBox.Show("Gambar Barang tidak boleh kosong");
                return;
            }
            else if(btnSimpan.Text == "Simpan")
            {
                Zeamart zmrt = new Zeamart(txtNama.Text.Trim(), int.Parse(txtHarga.Text.Trim()), int.Parse(txtJumlah.Text.Trim()), txtSatuan.Text.Trim());
                DbZeamart.TambahBarang(zmrt);
                Bersihkan();
            }
            else if(btnSimpan.Text == "Ubah")
            {
                Zeamart zmrt = new Zeamart(txtNama.Text.Trim(), int.Parse(txtHarga.Text.Trim()), int.Parse(txtJumlah.Text.Trim()), txtSatuan.Text.Trim());
                DbZeamart.EditBarang(zmrt, id);
            }

            _parent.Tampilkan();
        }
    }
}

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
    public partial class MainForm : Form
    {
        FormTambah formTambah;

        public MainForm()
        {
            InitializeComponent();
            formTambah = new FormTambah(this);
        }

        public void Tampilkan()
        {
            DbZeamart.TampilkanDanCari("SELECT * FROM tbl_zeamart", dataGridView);
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            formTambah.Bersihkan();
            formTambah.SimpanInfo();
            formTambah.ShowDialog();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Tampilkan();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            DbZeamart.TampilkanDanCari("SELECT * FROM tbl_zeamart WHERE nama_barang LIKE '" + txtCari.Text + "%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                formTambah.Bersihkan();
                formTambah.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                formTambah.nama_barang = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                formTambah.harga_barang = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                formTambah.jumlah_barang = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                formTambah.satuan_barang = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                formTambah.UbahDataInfo();
                formTambah.ShowDialog();
                return;
            }
            else if(e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Apakah kamu ingin menghapus data barang?", "Informasi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbZeamart.HapusBarang(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Tampilkan();
                }

                return;
            }
        }
    }
}

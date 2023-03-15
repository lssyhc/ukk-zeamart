using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeamart_UKK
{
    class DbZeamart
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=zeamart";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return con;
        }

        public static void TambahBarang(Zeamart zmrt)
        {
            string query = "INSERT INTO tbl_zeamart VALUES(NULL, @NamaBarang, @HargaBarang, @JumlahBarang, @SatuanBarang)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@NamaBarang", MySqlDbType.VarChar).Value = zmrt.nama_barang;
            cmd.Parameters.Add("@HargaBarang", MySqlDbType.VarChar).Value = zmrt.harga_barang;
            cmd.Parameters.Add("@JumlahBarang", MySqlDbType.VarChar).Value = zmrt.jumlah_barang;
            cmd.Parameters.Add("@SatuanBarang", MySqlDbType.VarChar).Value = zmrt.satuan_barang;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sukses Menambahkan Data", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal Menambahkan Data \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }

        public static void EditBarang(Zeamart zmrt, string id)
        {
            string query = "UPDATE tbl_zeamart SET nama_barang=@NamaBarang, harga_barang=@HargaBarang, jumlah_barang=@JumlahBarang, satuan_barang=@SatuanBarang WHERE id=@IdBarang";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@IdBarang", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@NamaBarang", MySqlDbType.VarChar).Value = zmrt.nama_barang;
            cmd.Parameters.Add("@HargaBarang", MySqlDbType.VarChar).Value = zmrt.harga_barang;
            cmd.Parameters.Add("@JumlahBarang", MySqlDbType.VarChar).Value = zmrt.jumlah_barang;
            cmd.Parameters.Add("@SatuanBarang", MySqlDbType.VarChar).Value = zmrt.satuan_barang;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sukses Mengedit Data", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal Mengedit Data \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }

        public static void HapusBarang(string id)
        {
            string query = "DELETE FROM tbl_zeamart WHERE id=@IdBarang";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@IdBarang", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sukses Menghapus Data", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal Menghapus Data \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }

        public static void TampilkanDanCari(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class Pembelian : Form
    {
        private DataTable transaksi = new DataTable();

        private int id_baju = 0;

        public Pembelian()
        {
            InitializeComponent();
            addColumns();
            dataGridView2.DataSource = transaksi;
        }

        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_baju = Convert.ToInt32(row.Cells["id"].Value);
                baju.Text = row.Cells["Nama"].Value.ToString();
                jenis.Text = row.Cells["Jenis"].Value.ToString();
                harga.Text = row.Cells["Harga"].Value.ToString();
            }
        }

        private void Pembelian_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void addColumns()
        {
            transaksi.Columns.Add("Nama Baju");
            transaksi.Columns.Add("Jenis Baju");
            transaksi.Columns.Add("Harga");
            transaksi.Columns.Add("Jumlah");
            transaksi.Columns.Add("Total");
        }

        private void Display()
        {
            dataGridView1.DataSource =
                Koneksi
                    .display("SELECT id_baju as id, nama as Nama, jenis as Jenis, stock as Stok, harga as Harga FROM baju");
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cari_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
                Koneksi
                    .display("SELECT id_baju as id, nama as Nama, jenis as Jenis, stock as Stok, harga as Harga FROM baju WHERE nama = " +
                    "'" +
                    cari.Text +
                    "'");
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void clearForm()
        {
            baju.Text = "";
            jenis.Text = "";
            harga.Text = "";
            stok.Text = "";
            nama.Text = "";
            address.Text = "";
            hp.Text = "";
            bayar.Text = "";
            kembali.Text = "";
            total.Text = "";
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Display();
        }

        private int hitungTotal()
        {
            int total = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                total +=
                    Convert.ToInt32(dataGridView2.Rows[i].Cells["Total"].Value);
            }
            return total;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Keranjang masih kosong!");
            }
            else
            {
                if (
                    MessageBox
                        .Show("Apakah anda yakin ingin menghapus item ini?",
                        "Konfirmasi",
                        MessageBoxButtons.YesNo) ==
                    DialogResult.Yes
                )
                {
                    dataGridView2
                        .Rows
                        .RemoveAt(dataGridView2.SelectedRows[0].Index);
                }
            }
        }

        private void simpan_Click_1(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Keranjang masih kosong!");
            }
            else
            {
                string query = "";
                if (male.Checked)
                {
                    query =
                        "INSERT INTO supplier (nama, alamat, jenis_kelamin, nomer_hp) VALUES ('" +
                        nama.Text +
                        "', '" +
                        address.Text +
                        "', 'Laki-laki', '" +
                        hp.Text +
                        "');SELECT LAST_INSERT_ID()";
                }
                else
                {
                    query =
                        "INSERT INTO supplier (nama, alamat, jenis_kelamin, nomer_hp) VALUES ('" +
                        nama.Text +
                        "', '" +
                        address.Text +
                        "', 'Perempuan', '" +
                        hp.Text +
                        "');SELECT LAST_INSERT_ID()";
                }
                int id_supplier =
                    Convert.ToInt32(Koneksi.display(query).Rows[0][0]);

                dataGridView2.AllowUserToAddRows = false;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    string nama = row.Cells["Nama Baju"].Value.ToString();
                    string jenis = row.Cells["Jenis Baju"].Value.ToString();
                    int harga = Convert.ToInt32(row.Cells["Harga"].Value);
                    int jumlah = Convert.ToInt32(row.Cells["Jumlah"].Value);
                    int total = Convert.ToInt32(row.Cells["Total"].Value);
                    int id_karyawan = int.Parse(Authentication.Id);
                    string command =
                        "SELECT id_baju FROM baju WHERE nama = " +
                        "'" +
                        nama +
                        "'";
                    int id_baju =
                        Convert
                            .ToInt32(Koneksi
                                .display(command)
                                .Rows[0]["id_baju"]);
                    command =
                        "INSERT INTO transaksi2 (id_baju, id_karyawan, id_supplier, tanggal) VALUES (" +
                        id_baju +
                        ", " +
                        id_karyawan +
                        ", " +
                        id_supplier +
                        ", '" +
                        DateTime.Now.ToString("yyyy-MM-dd") +
                        "');SELECT LAST_INSERT_ID()";

                    int id_transaksi =
                        Convert.ToInt32(Koneksi.display(command).Rows[0][0]);
                    command =
                        "INSERT INTO pembayaran2 (id_transaksi2, tanggal, total) VALUES (" +
                        id_transaksi +
                        ", '" +
                        DateTime.Now.ToString("yyyy-MM-dd") +
                        "', " +
                        total +
                        ")";
                    Koneksi.Query (command);
                    command =
                        "UPDATE baju SET stock = stock - " +
                        jumlah +
                        " WHERE id_baju = " +
                        id_baju;
                    Koneksi.Query (command);
                    MessageBox.Show("Transaksi berhasil!");

                    transaksi.Rows.Clear();
                    dataGridView2.DataSource = transaksi;
                    dataGridView2.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                    id_baju = 0;
                    clearForm();

                }
            }
        }

        private void batal_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void tambah_Click(object sender, EventArgs e)
        {
            if (stok.Text == "" || id_baju == 0)
            {
                MessageBox.Show("Jumlah Belum diinputkan!");
            }
            else
            {
                string nama = baju.Text;
                string jenis = this.jenis.Text;
                int harga = Convert.ToInt32(this.harga.Text);
                int amount = Convert.ToInt32(stok.Text);
                int total = harga * amount;

                transaksi.Rows.Add(nama, jenis, harga, amount, total);
                dataGridView2.DataSource = transaksi;
                dataGridView2.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
                id_baju = 0;
                clearForm();
            }
            this.total.Text = "Rp. " + hitungTotal().ToString();
        }
    }
}

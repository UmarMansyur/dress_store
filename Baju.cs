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
    public partial class Baju : Form
    {
        public Baju()
        {
            InitializeComponent();
        }

        private void Baju_Load_1(object sender, EventArgs e)
        {
            Display();
            VisibleUpdateOrDelete(false);
        }

        private void Display()
        {
            dataGridView1.DataSource =
                Koneksi.display("SELECT id_baju as id, nama as Nama, jenis as Jenis, stock as Stok, harga as Harga FROM baju");
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            VisibleUpdateOrDelete(false);
        }

        private void VisibleUpdateOrDelete(bool status)
        {
            ubah.Visible = status;
            hapus.Visible = status;
        }

        private void batal_Click(object sender, EventArgs e)
        {
            tambah.Text = "Tambah";
            clearForm();
        }

        private void clearForm()
        {
            nama.Text = "";
            jenis.Text = "";
            stok.Text = "";
            harga.Text ="";
        }

        private void ubah_Click(object sender, EventArgs e)
        {
            tambah.Text = "Simpan";
            ubah.Enabled = false;
            hapus.Enabled = false;
        }

        private void hapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (
                    MessageBox
                        .Show("Apakah anda yakin ingin menghapus data ini ?",
                        "Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) ==
                    DialogResult.Yes
                )
                {
                    string query =
                        "DELETE FROM baju WHERE id_baju = '" +
                        dataGridView1.CurrentRow.Cells["id"].Value.ToString() +
                        "'";
                    Koneksi.Query (query);
                    MessageBox
                        .Show("Data berhasil dihapus",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            Display();
            clearForm();
        }

        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                nama.Text = row.Cells["Nama"].Value.ToString();
                jenis.Text = row.Cells["Jenis"].Value.ToString();
                stok.Text = row.Cells["Stok"].Value.ToString();
                harga.Text = row.Cells["Harga"].Value.ToString();
                VisibleUpdateOrDelete(true);
                ubah.Enabled = true;
                hapus.Enabled = true;
            }
        }

        private void tambah_Click(object sender, EventArgs e)
        {
            if (nama.Text == "" || jenis.Text == "" || stok.Text == "" || harga.Text == "")
            {
                MessageBox.Show("Data kosong ! Inputkan Data");
            }
            else
            {
                if (tambah.Text == "Tambah")
                    {
                        string query = "INSERT INTO baju (nama, jenis, stock, harga) VALUES ('" + nama.Text + "', '" + jenis.Text + "', '" + stok.Text + "', '" + harga.Text + "')";
                        Koneksi.Query (query);
                        MessageBox
                            .Show("Data berhasil ditambahkan",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        string query =
                            "UPDATE baju SET nama = '" + nama.Text + "', jenis = '" + jenis.Text + "', stock = '" + stok.Text + "', harga = '" + harga.Text + "' WHERE id_baju = '" +
                            dataGridView1.CurrentRow.Cells["id"].Value.ToString() +
                            "'";
                        Koneksi.Query (query);
                        MessageBox
                            .Show("Data berhasil diubah",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    Display();
                    clearForm();
            }
        }
    }
}


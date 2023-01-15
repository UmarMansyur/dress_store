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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void Display()
        {
            dataGridView1.DataSource =
                Koneksi
                    .display("SELECT id_karyawan as id, nama as Nama, jabatan as Jabatan, nomer_hp as `Nomor Hp`, alamat as Alamat, username as Username, password as Password FROM karyawan");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                nama.Text == "" ||
                jabatan.Text == "" ||
                hp.Text == "" ||
                address.Text == "" ||
                username.Text == "" ||
                password.Text == "" ||
                konfirmasi.Text == ""
            )
            {
                MessageBox.Show("Data kosong ! Inputkan Data");
            }
            else
            {
                if (password.Text == konfirmasi.Text)
                {
                    if (tambah.Text == "Tambah")
                    {
                        string query =
                            "INSERT INTO karyawan VALUES (NULL, '" +
                            username.Text +
                            "','" +
                            password.Text +
                            "','" +
                            nama.Text +
                            "','" +
                            jabatan.Text +
                            "','" +
                            hp.Text +
                            "','" +
                            address.Text +
                            "')";
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
                            "UPDATE karyawan SET nama = '" +
                            nama.Text +
                            "', jabatan = '" +
                            jabatan.Text +
                            "', nomer_hp = '" +
                            hp.Text +
                            "', alamat = '" +
                            address.Text +
                            "', username = '" +
                            username.Text +
                            "', password = '" +
                            password.Text +
                            "' WHERE id_karyawan = '" +
                            dataGridView1
                                .CurrentRow
                                .Cells["id"]
                                .Value
                                .ToString() +
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
                else
                {
                    MessageBox
                        .Show("Password tidak sama",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void batal_Click(object sender, EventArgs e)
        {
            tambah.Text = "Tambah";
            clearForm();
        }

        private void clearForm()
        {
            nama.Text = "";
            jabatan.Text = "";
            hp.Text = "";
            address.Text = "";
            username.Text = "";
            password.Text = "";
            konfirmasi.Text = "";
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
                        "DELETE FROM karyawan WHERE id_karyawan = '" +
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
                jabatan.Text = row.Cells["Jabatan"].Value.ToString();
                hp.Text = row.Cells["Nomor Hp"].Value.ToString();
                address.Text = row.Cells["Alamat"].Value.ToString();
                username.Text = row.Cells["Username"].Value.ToString();
                password.Text = row.Cells["Password"].Value.ToString();
                konfirmasi.Text = row.Cells["Password"].Value.ToString();
                VisibleUpdateOrDelete(true);
                ubah.Enabled = true;
                hapus.Enabled = true;
            }
        }
    }
}

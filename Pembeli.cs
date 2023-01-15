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
    public partial class Pembeli : Form
    {
        public Pembeli()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            male.Checked = true;
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
           
        }

        private void Pembeli_Load(object sender, EventArgs e)
        {
            display();
        }

        private void display()
        {
            // union table pelanggan dan supplier

            string query =
                "SELECT id_pelanggan, nama as Nama, alamat as Alamat, jenis_kelamin as `Jenis Kelamin`, nomer_hp as `Nomor Telepon`, 'Pembeli' as Status FROM pelanggan UNION SELECT id_supplier, nama as Nama, alamat as Alamat, jenis_kelamin as `Jenis Kelamin`, nomer_hp as `Nomor Telepon`, 'Supplier' as Status FROM supplier";
            dataGridView1.DataSource = Koneksi.display(query);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            EnabledButton(false);
        }

        private void EnabledButton(bool status)
        {
            ubah.Enabled = status;
            hapus.Enabled = status;
        }

        private void clearForm()
        {
            nama.Text = "";
            male.Checked = true;
            hp.Text = "";
            address.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nama.Text == "" || hp.Text == "" || address.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong");
                return;
            }
            else
            {
                if (tambah.Text == "Tambah")
                {
                    if (buyer.Checked)
                    {
                        if (male.Checked)
                        {
                            string query =
                                "INSERT INTO pelanggan (nama, alamat, jenis_kelamin, nomer_hp) VALUES ('" +
                                nama.Text +
                                "', '" +
                                address.Text +
                                "', 'Laki-Laki', '" +
                                hp.Text +
                                "')";
                            Koneksi.Query (query);
                        }
                        else
                        {
                            string query =
                                "INSERT INTO pelanggan (nama, alamat, jenis_kelamin, nomer_hp) VALUES ('" +
                                nama.Text +
                                "', '" +
                                address.Text +
                                "', 'Perempuan', '" +
                                hp.Text +
                                "')";
                            Koneksi.Query (query);
                        }
                    }
                    else
                    {
                        if (male.Checked)
                        {
                            string query =
                                "INSERT INTO supplier (nama, alamat, jenis_kelamin, nomer_hp) VALUES ('" +
                                nama.Text +
                                "', '" +
                                address.Text +
                                "', 'Laki-Laki', '" +
                                hp.Text +
                                "')";
                            Koneksi.Query (query);
                        }
                        else
                        {
                            string query =
                                "INSERT INTO supplier (nama, alamat, jenis_kelamin, nomer_hp) VALUES ('" +
                                nama.Text +
                                "', '" +
                                address.Text +
                                "', 'Perempuan', '" +
                                hp.Text +
                                "')";
                            Koneksi.Query(query);
                        }
                    }
                }
                else
                {
                    if (buyer.Checked)
                    {
                        if (male.Checked)
                        {
                            string query =
                                "UPDATE pelanggan SET nama = '" +
                                nama.Text +
                                "', alamat = '" +
                                address.Text +
                                "', jenis_kelamin = 'Laki-Laki', nomer_hp = '" +
                                hp.Text +
                                "' WHERE id_pelanggan = " +
                                dataGridView1
                                    .CurrentRow
                                    .Cells[0]
                                    .Value
                                    .ToString();
                            Koneksi.Query(query);
                        }
                        else
                        {
                            string query =
                                "UPDATE pelanggan SET nama = '" +
                                nama.Text +
                                "', alamat = '" +
                                address.Text +
                                "', jenis_kelamin = 'Perempuan', nomer_hp = '" +
                                hp.Text +
                                "' WHERE id_pelanggan = " +
                                dataGridView1
                                    .CurrentRow
                                    .Cells[0]
                                    .Value
                                    .ToString();
                            Koneksi.Query(query);
                        }
                    }
                    else
                    {
                        if (male.Checked)
                        {
                            string query =
                                "UPDATE supplier SET nama = '" +
                                nama.Text +
                                "', alamat = '" +
                                address.Text +
                                "', jenis_kelamin = 'Laki-Laki', nomer_hp = '" +
                                hp.Text +
                                "' WHERE id_supplier = " +
                                dataGridView1
                                    .CurrentRow
                                    .Cells[0]
                                    .Value
                                    .ToString();

                            Koneksi.Query(query);
                        }
                        else
                        {
                            string query =
                                "UPDATE supplier SET nama = '" +
                                nama.Text +
                                "', alamat = '" +
                                address.Text +
                                "', jenis_kelamin = 'Perempuan', nomer_hp = '" +
                                hp.Text +
                                "' WHERE id_supplier = " +
                                dataGridView1
                                    .CurrentRow
                                    .Cells[0]
                                    .Value
                                    .ToString();
                            Koneksi.Query(query);
                        }
                    }
                        MessageBox.Show("Data berhasil diubah");
                }
                ubah.Enabled = true;
                hapus.Enabled = true;
                clearForm();
                tambah.Text = "Tambah";
            }
            display();
        }

        private void ubah_Click(object sender, EventArgs e)
        {
            tambah.Text = "Simpan";
            EnabledButton(false);
        }

        private void hapus_Click(object sender, EventArgs e)
        {
            if (
                MessageBox
                    .Show("Apakah anda yakin ingin menghapus data ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) ==
                DialogResult.Yes
            )
            {
                if (
                    dataGridView1.CurrentRow.Cells["Status"].Value.ToString() ==
                    "Pembeli"
                )
                {
                    string query =
                        "DELETE FROM pelanggan WHERE id_pelanggan = " +
                        dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    Koneksi.Query (query);
                }
                else
                {
                    string query =
                        "DELETE FROM supplier WHERE id_supplier = " +
                        dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    Koneksi.Query (query);
                }
                display();
            }
            clearForm();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EnabledButton(true);
            nama.Text = dataGridView1.CurrentRow.Cells["Nama"].Value.ToString();
            address.Text =
                dataGridView1.CurrentRow.Cells["Alamat"].Value.ToString();
            hp.Text =
                dataGridView1
                    .CurrentRow
                    .Cells["Nomor Telepon"]
                    .Value
                    .ToString();
            if (
                dataGridView1
                    .CurrentRow
                    .Cells["Jenis Kelamin"]
                    .Value
                    .ToString() ==
                "Laki-Laki"
            )
            {
                male.Checked = true;
            }
            else
            {
                female.Checked = true;
            }
            if (
                dataGridView1.CurrentRow.Cells["Status"].Value.ToString() ==
                "Pembeli"
            )
            {
                buyer.Checked = true;
            }
            else
            {
                supplier.Checked = true;
            }
        }
    }
}

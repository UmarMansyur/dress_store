using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication9
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = "SELECT id_karyawan, username, password, jabatan FROM karyawan  WHERE username = '" + username.Text + "' AND password = '" + password.Text + "'";
            MySqlDataReader reader = Koneksi.Query(command);
            if (reader.Read())
            {
                MessageBox.Show("Login Berhasil");
                Authentication.Id = reader.GetString(0);
                Authentication.Level = reader.GetString(3);
                HomePage.menu.lockTool();
                HomePage.menu.loginToolStripMenuItem.Enabled = false;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Gagal");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

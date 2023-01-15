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
    public partial class HomePage : Form
    {
        public static HomePage menu;
        private int childFormNumber = 0;

        public HomePage()
        {
            InitializeComponent();
        }

        Baju baju;
        Login login;
        Pembeli pembeli;
        Pembelian pembelian;
        Penjualan penjualan;
        User user;

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.Text = "Window " + childFormNumber++;
            childForm.ShowDialog();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

      

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            lockTool();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (login == null)
            {
                this.login = new Login();
                this.login.FormClosed += new FormClosedEventHandler(login_FormClosed);
                this.login.ShowDialog();
            }
            else
            {
                this.login.Activate();
            }
        }

        void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.login = null;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginToolStripMenuItem.Enabled = true;
            this.login = null;  
            Authentication.Id = null;
            Authentication.Level = null;
            lockTool();
        }

        private void pembeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pembeli == null)
            {
                this.pembeli = new Pembeli();
                this.pembeli.FormClosed += new FormClosedEventHandler(pembeli_FormClosed);
                this.pembeli.ShowDialog();
            }
            else
            {
                this.pembeli.Activate();
            }
        }

        void pembeli_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.pembeli = null;
        }


        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user == null)
            {
                this.user = new User();
                this.user.FormClosed += new FormClosedEventHandler(user_FormClosed);
                this.user.ShowDialog();
            }
            else
            {
                this.user.Activate();
            }

        }

        void user_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.user = null;
        }

        private void bajuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (baju == null)
            {
                this.baju = new Baju();
                this.baju.FormClosed += new FormClosedEventHandler(baju_FormClosed);
                this.baju.ShowDialog();
            }
            else
            {
                this.baju.Activate();
            }
        }

        void baju_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.baju = null;
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pembelian == null)
            {
                this.pembelian = new Pembelian();
                this.pembelian.FormClosed += new FormClosedEventHandler(pembelian_FormClosed);
                this.pembelian.ShowDialog();
            }
            else
            {
                 this.pembelian.Activate();
            }
        }

        void pembelian_FormClosed(object sender, FormClosedEventArgs e)
        {
             this.pembelian = null;
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (penjualan == null)
            {
                this.penjualan = new Penjualan();
                this.penjualan.FormClosed += new FormClosedEventHandler(penjualan_FormClosed);
                this.penjualan.ShowDialog();
            }
            else
            {
                this.penjualan.Activate();
            }
        }

        void penjualan_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.penjualan = null;
        }

        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        public void lockTool() {
            if(Authentication.Level == "admin") {
                pembeliToolStripMenuItem.Enabled = true;
                karyawanToolStripMenuItem.Enabled = true;
                bajuToolStripMenuItem.Enabled = true;
                pembelianToolStripMenuItem.Enabled = true;
                penjualanToolStripMenuItem.Enabled = true;
            } else if(Authentication.Level == "karyawan") {
                pembeliToolStripMenuItem.Enabled = false;
                karyawanToolStripMenuItem.Enabled = false;
                bajuToolStripMenuItem.Enabled = true;
                pembelianToolStripMenuItem.Enabled = true;
                penjualanToolStripMenuItem.Enabled = true;
            } else {
                pembeliToolStripMenuItem.Enabled = false;
                karyawanToolStripMenuItem.Enabled = false;
                bajuToolStripMenuItem.Enabled = false;
                pembelianToolStripMenuItem.Enabled = false;
                penjualanToolStripMenuItem.Enabled = false;
            }
        menu = this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLMobileStore
{
    public partial class frmQLMobileStore : Form
    {
        public frmQLMobileStore()
        {
            InitializeComponent();
        }

        private void frmQLMobileStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát chương trình?", "Program Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void exitMenuStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham sp = new frmSanPham();
            sp.Show();
            sp.MdiParent = this;
        }

        private void LoaiSanPhamToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham lsp = new frmLoaiSanPham();
            lsp.Show();
            lsp.MdiParent = this;
        }

        private void NguoiQuanTriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUser us = new frmUser();
            us.Show();
            us.MdiParent = this;
        }

        private void timerChayChu_Tick(object sender, EventArgs e)
        {
            string ch = label1.Text;
            label1.Text = label1.Text.Substring(1, label1.Text.Length - 1);
            label1.Text += ch.Substring(0, 1);
        }

        private void GioithieuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CHƯƠNG TRÌNH QUẢN LÝ CƠ SỞ DỮ LIỆU MOBILE STORE"
                            + "\nNhóm sinh viên thực hiện:" + "\n1. Trần Xuân Vinh"
                            + "\nMSSV: 1354050109" + "\n2. Nguyễn Duy Hoài Nam"
                            + "\nMSSV: 1351010080" + "\n© 2016 Mobile Store Database", "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

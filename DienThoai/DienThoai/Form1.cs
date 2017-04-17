using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using BUSDienThoai;
using DTODienThoai;
using System.Data.SqlClient;

namespace DienThoai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = GetProductGUI();
           
            Binding();
        }
        private void Binding()
        {
        
            txtID.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "product_id"));
            txtTenDT.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "product_name"));
            txtMaloai.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "category_id"));
             txtMota.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "description"));
            txtGia.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "price"));
            txtUserID.DataBindings.Add("Text", dgvSanPham.DataSource, "user_id");
            //imgDT.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "product_img"));
         
        }

        private List<SanPhamDTO> GetProductGUI()
        {
            string sql = "SELECT * FROM product";
            return new SanPhamBUS().GetProductBUS(sql);
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int  categoryid, Price, userid;
            string id, name, des;
            id = txtID.Text.Trim();
            name = txtTenDT.Text.Trim();
            categoryid = int.Parse(txtMaloai.Text.Trim());
            des = txtMota.Text.Trim();
            Price = int.Parse(txtGia.Text.Trim());

            userid = int.Parse(txtUserID.Text.Trim());

            SanPhamDTO spo = new SanPhamDTO(id, name, categoryid, des,Price, userid);
            try
            {
                int i = new SanPhamBUS().Add(spo);
                dgvSanPham.DataSource = GetProductGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnThemanh_Click(object sender, EventArgs e)
        {
           
        }

    }
}

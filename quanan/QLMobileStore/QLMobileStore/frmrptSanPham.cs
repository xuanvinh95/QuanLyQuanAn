using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace QLMobileStore
{
    public partial class frmrptSanPham : Form
    {
        const string _cnstr = @"Server = QUANGTRI-LT\QTSQLSERVER; Database = MobileDb; Integrated Security = true;";
        SqlConnection _cn;
        public frmrptSanPham()
        {
            InitializeComponent();
            _cn = new SqlConnection(_cnstr);
        }

        private void frmrptSanPham_Load(object sender, EventArgs e)
        {

            this.rvSanPham.RefreshReport();
        }

        private void HienThiReportSP()
        {
            string sql = "SELECT * FROM product";
            SqlDataAdapter da = new SqlDataAdapter(sql, _cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ReportDataSource rds = new ReportDataSource("product", ds.Tables[0]);
            rvSanPham.LocalReport.DataSources.Clear();
            rvSanPham.LocalReport.DataSources.Add(rds);
            rvSanPham.LocalReport.ReportPath = @"..\..\rptSanPham.rdlc";
            this.rvSanPham.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbSearch.SelectedItem == null)
            {
                txtHienthi.Text = "Bạn chưa nhập mã loại SP";
            }
            else
            {
                string sql = "SELECT * FROM product where category_id ='" + cbSearch.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, _cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ReportDataSource rds = new ReportDataSource("product", ds.Tables[0]);
                rvSanPham.LocalReport.DataSources.Clear();
                rvSanPham.LocalReport.DataSources.Add(rds);
                rvSanPham.LocalReport.ReportPath = @"..\..\rptSanPham.rdlc";
                this.rvSanPham.RefreshReport();
                if (cbSearch.SelectedItem.ToString() == 3.ToString())
                {
                    txtHienthi.Text = "Nokia";
                }
                else if (cbSearch.SelectedItem.ToString() == 4.ToString())
                {
                    txtHienthi.Text = "Samsung";
                }
                else if (cbSearch.SelectedItem.ToString() == 5.ToString())
                {
                    txtHienthi.Text = "Apple";
                } 

                if (cbSearch.SelectedItem.ToString() == 0.ToString())
                {
                    txtHienthi.Text = "Nhập mã loại SP";
                }
            }
        }

    }
}

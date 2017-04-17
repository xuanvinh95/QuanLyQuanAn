using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLMobileStore
{
    public partial class frmLoaiSanPham : Form
    {
        const string _cnstr = @"Server = QUANGTRI-LT\QTSQLSERVER; Database = MobileDb; Integrated Security = true;";
        SqlConnection _cn;
        public frmLoaiSanPham()
        {
            InitializeComponent();
            _cn = new SqlConnection(_cnstr);
        }

        public void Connect()
        {
            try
            {
                if (_cn != null && _cn.State == ConnectionState.Closed)
                {
                    _cn.Open();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lối kết nối đến CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Disconnect()
        {
            if (_cn != null && _cn.State == ConnectionState.Open)
            {
                _cn.Close();
            }
        }

        public void ShowData()
        {
            Connect();
            string sql = @"SELECT * FROM category";
            SqlCommand cmd = new SqlCommand(sql, _cn);
            //Thực thi phương thức ExcuteReader trả về một bảng dữ liệu
            SqlDataReader dr = cmd.ExecuteReader();
            //Khai báo list chứa danh sách loại sản phẩm
            List<LoaiDienThoai> lstLoaiDienThoai = new List<LoaiDienThoai>();
            int category_id, parent_id;
            string category_name;
            while (dr.Read())
            {
                category_id = dr.GetInt32(0);
                category_name = dr.GetString(1);
                parent_id = dr.GetInt32(2);
                //Gọi phương thức khởi tạo có tham số của lớp LoaiDienThoai
                LoaiDienThoai ldt = new LoaiDienThoai(category_id, category_name, parent_id);
                lstLoaiDienThoai.Add(ldt);
            }
            dgvLoaiSanPham.DataSource = lstLoaiDienThoai;
            Disconnect();
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dgvLoaiDienThoai_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoaiSanPham.CurrentRow != null)
            {
                txtID.Text = dgvLoaiSanPham.CurrentRow.Cells["category_id"].Value.ToString();
                txtTenLoaiSP.Text = dgvLoaiSanPham.CurrentRow.Cells["category_name"].Value.ToString();
            }
        }

        private void frmLoaiSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát chương trình loại sản phẩm?", "Program Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

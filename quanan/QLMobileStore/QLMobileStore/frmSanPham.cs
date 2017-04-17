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
    public partial class frmSanPham : Form
    {
        const string _cnstr = @"Server = QUANGTRI-LT\QTSQLSERVER; Database = MobileDb; Integrated Security = true;";
        SqlConnection _cn;
        public frmSanPham()
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
            string sql = @"SELECT * FROM product";
            SqlCommand cmd = new SqlCommand(sql, _cn);
            //Thực thi phương thức ExcuteReader trả về một bảng dữ liệu
            SqlDataReader dr = cmd.ExecuteReader();
            //Khai báo list chứa danh sách sản phẩm
            List<DienThoai> lstDienThoai = new List<DienThoai>();
            int product_id, category_id, price, user_id;
            string product_name, description, product_img;
            try
            {
                while (dr.Read())
                {
                    product_id = dr.GetInt32(0);
                    product_name = dr.GetString(1);
                    category_id = dr.GetInt32(2);
                    description = dr.GetString(3);
                    price = dr.GetInt32(4);
                    product_img = dr.GetString(5);
                    user_id = dr.GetInt32(6);
                    //Gọi phương thức khởi tạo có tham số của lớp DienThoai
                    DienThoai dt = new DienThoai(product_id, product_name, category_id, description, price, product_img, user_id);
                    lstDienThoai.Add(dt);
                }
                dgvDienThoai.DataSource = lstDienThoai;
            }
            catch
            {
                
            }
            finally
            {
                 Disconnect();
            }
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            ShowData();
            //BatText(true);
            //btnThemHinh.Enabled = false;
        }

        private void dgvDienThoai_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDienThoai.CurrentRow != null)
            {
                txtID.Text = dgvDienThoai.CurrentRow.Cells["product_id"].Value.ToString();
                txtTenDT.Text = dgvDienThoai.CurrentRow.Cells["product_name"].Value.ToString();
                txtMota.Text = dgvDienThoai.CurrentRow.Cells["description"].Value.ToString();
                txtGia.Text = dgvDienThoai.CurrentRow.Cells["price"].Value.ToString();
                txtMaloai.Text = dgvDienThoai.CurrentRow.Cells["category_id"].Value.ToString();
                //txtPath.Text = dgvDienThoai.CurrentRow.Cells["product_img"].Value.ToString();
                txtUserID.Text = dgvDienThoai.CurrentRow.Cells["user_id"].Value.ToString();
                //string pathImg = Application.StartupPath + dgvDienThoai.CurrentRow.Cells["product_img"].Value.ToString().Replace('/','\');
                string pathImg = Application.StartupPath + "\\" + dgvDienThoai.CurrentRow.Cells["product_img"].Value.ToString();
                imgDT.Image = Image.FromFile(pathImg);
                //imgDT.Image = Image.FromFile(dgvDienThoai.CurrentRow.Cells["product_img"].Value.ToString());
            }
        }

        private void frmSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát chương trình sản phẩm?", "Program Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public void BatText(bool enable)
        //{
        //    txtID.Enabled = enable;
        //    txtTenDT.Enabled = enable;
        //    txtGia.Enabled = enable;
        //    txtMota.Enabled = enable;
        //}

        private void btnThem_Click(object sender, EventArgs e)
        {
            Connect();
            //DienThoai dt = new DienThoai(txtID.Text.ToString(), txtTenDT.Text, txtMaloai.Text.ToString(), txtMota.Text, txtGia.Text.ToString(), txtPath.Text, txtUserID.Text.ToString());
            //DienThoai dt = new DienThoai((string)txtID.Text, (string)txtTenDT.Text, (string)txtMaloai.Text, (string)txtMota.Text, (string)txtGia.Text, (string)txtPath.Text, (string)txtUserID.Text);
            //DienThoai dt = new DienThoai(Int32.Parse(txtID.Text), Convert.ToString(txtTenDT.Text), Int32.Parse(txtMaloai.Text), Convert.ToString(txtMota.Text), Int32.Parse(txtGia.Text), Convert.ToString(txtPath.Text), Int32.Parse(txtUserID.Text));
            DienThoai dt = new DienThoai(int.Parse(txtID.Text), txtTenDT.Text, int.Parse(txtMaloai.Text), txtMota.Text, int.Parse(txtGia.Text), txtPath.Text, int.Parse(txtUserID.Text));
            try
            {
                SqlCommand cmd = new SqlCommand("use_ThemDT", _cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("product_id", dt.product_id));
                cmd.Parameters.Add(new SqlParameter("product_name", dt.product_name));
                cmd.Parameters.Add(new SqlParameter("category_id", dt.category_id));
                cmd.Parameters.Add(new SqlParameter("description", dt.description));
                cmd.Parameters.Add(new SqlParameter("price", dt.price));
                cmd.Parameters.Add(new SqlParameter("product_img", txtImageUrl.Text));
                cmd.Parameters.Add(new SqlParameter("user_id", dt.user_id));
                SqlParameter ret = cmd.Parameters.Add("return", SqlDbType.Int);
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                int res = (int)ret.Value;
                if (res == 1)
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                    ShowData();
                }
                else if (res == 0)
                    MessageBox.Show("Đã tồn tại!", "Thông báo");
                else
                    MessageBox.Show("Thêm không thành công!", "Thông báo");

                SaveImage();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi thêm dữ liệu!\n" + ex.ToString(), "Thông báo");
            }
            finally
            {
                Disconnect();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Connect();
            //DienThoai dt = new DienThoai(txtID.Text, txtTenDT.Text, txtMaloai.Text, txtMota.Text, txtGia.Text, txtPath.Text, txtUserID.Text);
            DienThoai dt = new DienThoai(int.Parse(txtID.Text), txtTenDT.Text, int.Parse(txtMaloai.Text), txtMota.Text, int.Parse(txtGia.Text), txtPath.Text, int.Parse(txtUserID.Text));
            string sql = @"DELETE FROM product WHERE product_id ='" + dgvDienThoai.Rows[dgvDienThoai.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("use_XoaDT", _cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("product_id", dt.product_id));
                    SqlParameter ret = cmd.Parameters.Add("return", SqlDbType.Int);
                    ret.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int res = (int)ret.Value;
                    if (res == 1)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        ShowData();
                    }
                    else if (res == 0)
                        MessageBox.Show("Chưa tồn tại!", "Thông báo");
                    else
                        MessageBox.Show("Xóa không thành công!", "Thông báo");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi xóa dữ liệu!\n" + ex.ToString(), "Thông báo");
                }
                finally
                {
                    Disconnect();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Connect();
            //DienThoai dt = new DienThoai(txtID.Text, txtTenDT.Text, txtMaloai.Text, txtMota.Text, txtGia.Text, txtPath.Text, txtUserID.Text);
            //DienThoai dt = new DienThoai(Int32.Parse(txtID.Text), Convert.ToString(txtTenDT.Text), Int32.Parse(txtMaloai.Text), Convert.ToString(txtMota.Text), Int32.Parse(txtGia.Text), Convert.ToString(txtPath.Text), Int32.Parse(txtUserID.Text));
            DienThoai dt = new DienThoai(int.Parse(txtID.Text), txtTenDT.Text, int.Parse(txtMaloai.Text), txtMota.Text, int.Parse(txtGia.Text), txtPath.Text, int.Parse(txtUserID.Text));
            try
            {
                SqlCommand cmd = new SqlCommand("use_SuaTTDT", _cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("product_id", dt.product_id));
                cmd.Parameters.Add(new SqlParameter("product_name", dt.product_name));
                cmd.Parameters.Add(new SqlParameter("category_id", dt.category_id));
                cmd.Parameters.Add(new SqlParameter("description", dt.description));
                cmd.Parameters.Add(new SqlParameter("price", dt.price));
                cmd.Parameters.Add(new SqlParameter("product_img", dt.product_img));
                cmd.Parameters.Add(new SqlParameter("user_id", dt.user_id));
                SqlParameter ret = cmd.Parameters.Add("return", SqlDbType.Int);
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                int res = (int)ret.Value;
                if (res == 1)
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo");
                    ShowData();
                }
                else if (res == 0)
                    MessageBox.Show("Chưa tồn tại!", "Thông báo");
                else
                    MessageBox.Show("Sửa không thành công!", "Thông báo");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi sửa dữ liệu!\n" + ex.ToString(), "Thông báo");
            }
            finally
            {
                Disconnect();
            }
        }

        private void btnThemHinh_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.SafeFileName;
                try
                {
                    // Bước 1  : Lay duong dan luu vao csdl
                    //MessageBox.Show("upload/" + file);
                    txtPath.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);// Hiển thị tên ảnh lên Textbox
                    txtImageUrl.Text = "upload/" + file;
                    // bước 2 : hiển thị ảnh vừa chọn lên picturebox
                    imgDT.Image = Image.FromFile(openFileDialog1.FileName);//Hiện ảnh lên Picbox.
                    // Buoc 3 : Luu hinh vao thu muc upload
                    System.IO.Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath + "/upload");//Đường dẫn chứa file ảnh khi lưu.
                    //SaveImage();
                }
                catch 
                {

                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmrptSanPham rptSP = new frmrptSanPham();
            rptSP.Show();
        }

        #region Lưu hình
        private void SaveImage()
        {
            saveFileDialog1.FileName = txtPath.Text;
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.imgDT.Image.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.imgDT.Image.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        this.imgDT.Image.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
                fs.Close();
            }
        }
        #endregion

    }
}

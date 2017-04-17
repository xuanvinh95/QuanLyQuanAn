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
    public partial class frmUser : Form
    {
        const string _cnstr = @"Server = QUANGTRI-LT\QTSQLSERVER; Database = MobileDb; Integrated Security = true;";
        SqlConnection _cn;
        public frmUser()
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
            string sql = @"SELECT * FROM tbluser";
            SqlCommand cmd = new SqlCommand(sql, _cn);
            //Thực thi phương thức ExcuteReader trả về một bảng dữ liệu
            SqlDataReader dr = cmd.ExecuteReader();
            //Khai báo list chứa danh sách người quản trị
            List<User> lstUser = new List<User>();
            int user_id, phone, lv;
            string email, passwd, name, address;
            try
            {
                while (dr.Read())
                {
                    user_id = dr.GetInt32(0);
                    email = dr.GetString(1);
                    passwd = dr.GetString(2);
                    name = dr.GetString(3);
                    phone = dr.GetInt32(4);
                    address = dr.GetString(5);
                    lv = dr.GetInt32(6);
                    //Gọi phương thức khởi tạo có tham số của lớp User
                    User us = new User(user_id, email, passwd, name, phone, address, lv);
                    lstUser.Add(us);
                }
                dgvUser.DataSource = lstUser;
            }
            catch
            {

            }
            finally
            {
                Disconnect();
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void frmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát chương trình người quản trị?", "Program Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUser.CurrentRow != null)
            {
                txtID.Text = dgvUser.CurrentRow.Cells["user_id"].Value.ToString();
                txtTenNQT.Text = dgvUser.CurrentRow.Cells["name"].Value.ToString();
                txtDiaChi.Text = dgvUser.CurrentRow.Cells["address"].Value.ToString();
                txtDienThoai.Text = dgvUser.CurrentRow.Cells["phone"].Value.ToString();
                txtMatKhau.Text = dgvUser.CurrentRow.Cells["passwd"].Value.ToString();
                txtEmail.Text = dgvUser.CurrentRow.Cells["email"].Value.ToString();
                txtLvUser.Text = dgvUser.CurrentRow.Cells["lv"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Connect();
            User us = new User(int.Parse(txtID.Text), txtEmail.Text, txtMatKhau.Text, txtTenNQT.Text, int.Parse(txtDienThoai.Text), txtDiaChi.Text, int.Parse(txtLvUser.Text));
            try
            {
                SqlCommand cmd = new SqlCommand("use_ThemNQT", _cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("user_id", us.user_id));
                cmd.Parameters.Add(new SqlParameter("email", us.email));
                cmd.Parameters.Add(new SqlParameter("passwd", us.passwd));
                cmd.Parameters.Add(new SqlParameter("name", us.name));
                cmd.Parameters.Add(new SqlParameter("phone", us.phone));
                cmd.Parameters.Add(new SqlParameter("address", us.address));
                cmd.Parameters.Add(new SqlParameter("lv", us.lv));
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
            User us = new User(int.Parse(txtID.Text), txtEmail.Text, txtMatKhau.Text, txtTenNQT.Text, int.Parse(txtDienThoai.Text), txtDiaChi.Text, int.Parse(txtLvUser.Text));
            string sql = @"DELETE FROM tbluser WHERE user_id ='" + dgvUser.Rows[dgvUser.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("use_XoaNQT", _cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("user_id", us.user_id));
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
            User us = new User(int.Parse(txtID.Text), txtEmail.Text, txtMatKhau.Text, txtTenNQT.Text, int.Parse(txtDienThoai.Text), txtDiaChi.Text, int.Parse(txtLvUser.Text));
            try
            {
                SqlCommand cmd = new SqlCommand("use_SuaTTNQT", _cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("user_id", us.user_id));
                cmd.Parameters.Add(new SqlParameter("email", us.email));
                cmd.Parameters.Add(new SqlParameter("passwd", us.passwd));
                cmd.Parameters.Add(new SqlParameter("name", us.name));
                cmd.Parameters.Add(new SqlParameter("phone", us.phone));
                cmd.Parameters.Add(new SqlParameter("address", us.address));
                cmd.Parameters.Add(new SqlParameter("lv", us.lv));
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
    }
}

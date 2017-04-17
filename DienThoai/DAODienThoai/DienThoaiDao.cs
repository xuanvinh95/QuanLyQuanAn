using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using DTODienThoai;
using System.Data;
using System.Data.SqlClient;



namespace DAODienThoai
{
    public class DienThoaiDao
    {
        private clsKetNoi cls;

        public DienThoaiDao()
        {
            cls = new clsKetNoi();
        }

        public  List<SanPhamDTO> GetSanPhamDAO(string sql)
        {
            List<SanPhamDTO> list = new List<SanPhamDTO>();
            int  categoryid, Price, userid;
            string id, name, des, img; 
            try
            {
                SqlDataReader dr = cls.ExcuteReader(sql);;

                while (dr.Read())
                {
                    id = dr.GetInt32(0).ToString();
                    name = dr.GetString(1);
                   categoryid = dr.GetInt32(2);
                    des = dr.GetString(3);
                    Price = dr.GetInt32(4);
                   // img = dr.GetString(5);
                    userid = dr.GetInt32(6);

                    SanPhamDTO sp = new SanPhamDTO(id, name, categoryid, des, Price,  userid);
                    list.Add(sp);

                }
                return list;
            }

            catch (SqlException ex)
            {
                return null;
                throw ex;
            }
        }
        public int Add(SanPhamDTO sp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@product_id", sp.product_id));
            paras.Add(new SqlParameter("@product_name", sp.product_name));
            paras.Add(new SqlParameter("@category_id", sp.category_id));
            paras.Add(new SqlParameter("@description", sp.description));
            paras.Add(new SqlParameter("@price", sp.price));
           // paras.Add(new SqlParameter("@product_img", sp.product_img));
            paras.Add(new SqlParameter("@user_id", sp.user_id));
            try
            {
                return (cls.ExecuteNonQuery("use_ThemDienThoai", System.Data.CommandType.StoredProcedure, paras));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public DataTable Timkiemsanpham(string id)
        //{ 
        //    SqlConnection cn = 
        //}
    }
}

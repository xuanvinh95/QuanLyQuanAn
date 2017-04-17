using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using DTODienThoai;
using DAODienThoai;


namespace BUSDienThoai
{
    public class SanPhamBUS
    {
        public List<SanPhamDTO> GetProductBUS(string sql)
        {
            try
            {
                return new DienThoaiDao().GetSanPhamDAO(sql);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int Add(SanPhamDTO sp)
        {
            if (sp.product_name == " ")
            {
                return -2;
            }
            try
            {
                return (new DienThoaiDao().Add(sp));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

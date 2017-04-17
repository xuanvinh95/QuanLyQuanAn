using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DTODienThoai
{
    public class SanPhamDTO
    {
        public string product_id { get; set; }
        public string product_name { get; set; }
        public int category_id { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        //public string product_img { get; set; }
        public int user_id { get; set; }
        public SanPhamDTO( string id, string name, int categoryid, string des , int Price, int userid)
        {
            this.product_id = id;   
            this.product_name = name;
            this.category_id = categoryid;
            this.description = des;
            this.price = Price;
            //this.product_img = img;
            this.user_id = userid;
        }
    }
}

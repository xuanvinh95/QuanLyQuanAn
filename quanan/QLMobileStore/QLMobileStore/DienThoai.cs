using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLMobileStore
{
    class DienThoai
    {
        private int _product_id;
        public int product_id
        {
            get { return _product_id; }
            set { _product_id = value; }
        }
        private string _product_name;

        public string product_name
        {
            get { return _product_name; }
            set { _product_name = value; }
        }
        private int _category_id;

        public int category_id
        {
            get { return _category_id; }
            set { _category_id = value; }
        }
        private string _description;

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        private int _price;

        public int price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _product_img;

        public string product_img
        {
            get { return _product_img; }
            set { _product_img = value; }
        }

        private int _user_id;

        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        //Hàm khởi tạo mặc định
        public DienThoai()
        {
            _product_id = 0;
            _product_name = "";
            _category_id = 0;
            _description = "";
            _price = 0;
            _product_img = "";
            _user_id = 0;
        }
        //Hàm khởi tạo có tham số
        public DienThoai(int product_id, string product_name, int category_id, string description, int price, string product_img, int user_id)
        {
            _product_id = product_id;
            _product_name = product_name;
            _category_id = category_id;
            _description = description;
            _price = price;
            _product_img = product_img;
            _user_id = user_id;
        }
    }
}

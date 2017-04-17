using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLMobileStore
{
    class LoaiDienThoai
    {
        private int _category_id;
        public int category_id
        {
            get { return _category_id; }
            set { _category_id = value; }
        }
        private string _category_name;

        public string category_name
        {
            get { return _category_name; }
            set { _category_name = value; }
        }
        private int _parent_id;

        public int parent_id
        {
            get { return _parent_id; }
            set { _parent_id = value; }
        }

        //Hàm khởi tạo mặc định
        public LoaiDienThoai()
        {
            _category_id = 0;
            _category_name = "";
            _parent_id = 0;
        }
        //Hàm khởi tạo có tham số
        public LoaiDienThoai(int category_id, string category_name, int parent_id)
        {
            _category_id = @category_id;
            _category_name = @category_name;
            _parent_id = @parent_id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLMobileStore
{
    class User
    {
        private int _user_id;
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _passwd;

        public string passwd
        {
            get { return _passwd; }
            set { _passwd = value; }
        }
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _phone;

        public int phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _address;

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        private int _lv;

        public int lv
        {
            get { return _lv; }
            set { _lv = value; }
        }

        //Hàm khởi tạo mặc định
        public User()
        {
            _user_id = 0;
            _email = "";
            _passwd = "";
            _name = "";
            _phone = 0;
            _address = "";
            _lv = 0;
        }
        //Hàm khởi tạo có tham số
        public User(int user_id, string email, string passwd, string name, int phone, string address, int lv)
        {
            _user_id = user_id;
            _email = email;
            _passwd = passwd;
            _name = name;
            _phone = phone;
            _address = address;
            _lv = lv;
        }
    }
}

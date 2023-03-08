using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Borrower
    {
        private string boid;
        private string name;
        private string phone;

        public string Boid { get { return boid; } set { boid = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Phone { get { return phone; } set { phone = value; } }

        public Borrower() { }
        public Borrower(string boid, string name, string phone)
        {
            this.boid = boid;
            this.name = name;
            this.phone = phone;
        }

        public string Display()
        {
            string s = $"ID người mượn: {boid} | Họ tên: {name} | Điện thoại: {phone}";
            return s;
        }

        public string Format4File()
        {
            string s = $"{boid}|{name}|{phone}*";
            return s;
        }
    }
}

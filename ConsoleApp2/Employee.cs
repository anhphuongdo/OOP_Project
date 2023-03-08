using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Employee
    {
        private string emid;
        private string name;
        private string gender;
        private string shift;
        private string position;
        private string address;
        private string phone;
        private double salary;

        public string EmId { get { return emid; } set { this.emid = value; } }
        public string Name { get { return name; } set { this.name = value; } }
        public string Gender { get { return gender; } set { this.gender = value; } }
        public string Shift { get { return shift; } set { this.shift = value; } }
        public string Position { get { return position; } set { this.position = value; } }
        public string Address { get { return address; } set { this.address = value; } }
        public string Phone { get { return phone; } set { this.phone = value; } }
        public double Salary { get { return salary; } set { this.salary = value; } }

        public Employee() { }
        public Employee(string emid, string name, string gender, string shift, string position, string address, string phone, double salary)
        {
            this.emid = emid;
            this.name = name;
            this.gender = gender;
            this.shift = shift;
            this.position = position;
            this.address = address;
            this.phone = phone;
            this.salary = salary;
        }    

        public string Display()
        {
            string s = $"ID nhân viên: {emid} | Họ tên: {name} | Giới tính (M-nam | F-nữ): {gender} | Chức vụ: {position} | Ca làm: {shift} | Địa chỉ: {address} | Điện thoại: {phone} | Lương: {salary}";
            return s;
        }

        public string Format4File()
        {
            string s = $"{emid}|{name}|{gender}|{shift}|{position}|{address}|{phone}|{salary}*";
            return s;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Record
    {
        private string recid;
        private string bookid;
        private string boid;
        private string type;
        private string date;

        public string RecId { get { return recid; } set { recid = value; } }
        public string BookId { get { return bookid; } set { bookid = value;} }
        public string BoId { get { return boid; } set { boid = value; } }
        public string Type { get { return type; } set { type = value; } }
        public string Date { get { return date; } set { date = value; } }

        public Record() { }
        public Record(string recid, string bookid, string boid, string type, string date)
        {
            this.recid = recid;
            this.bookid = bookid;
            this.boid = boid;
            this.type = type;
            this.date = date;
        }

        public string Display()
        {
            string s = $"ID phiếu: {recid} | ID sách: {bookid} | ID người mượn: {boid} | Loại phiếu (L-phiếu mượn | R-phiếu trả): {type} | Ngày lập: {date}";
            return s;
        }

        public string Format4File()
        {
            string s = $"{recid}|{bookid}|{boid}|{type}|{date}*";
            return s;
        }
    }
}

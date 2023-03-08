using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public abstract class Books
    {
        protected string bookid;
        protected string classification;
        protected string title;
        protected string author;
        protected string importDate;
        protected long price;
        public bool isBorrowed;

        public string BookID { get { return bookid; } set { bookid = value; } }
        public string Classification { get { return classification; } set { classification = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }
        public string ImportDate { get { return importDate; } set { importDate = value; } }
        public long Price { get { return price; } set { price = value; } }
        public bool IsBorrowed { get { return isBorrowed; } set { isBorrowed = value; } }

        public abstract string Display();
        public abstract string Format4File();
    }

    public class Novel : Books
    {
        private string type;
        private int volume;

        public string Type { get { return type; } set { this.type = value; } }
        public int Volume { get { return volume; } set { volume = value; } }

        public Novel() { }
        public Novel(string bookid, string classification, string title, string author, string type, int volume, long price, string importDate, bool isBorrowed)
        {
            this.bookid = bookid;
            this.classification = classification;
            this.title = title;
            this.author = author;
            this.type = type;
            this.volume = volume;
            this.price = price;
            this.importDate = importDate;
            this.isBorrowed = isBorrowed;
        }

        public override string Display()
        {
            string s = $"ID tiểu thuyết: {bookid} | Thể loại: {classification} | Tựa: {title} | Loại tiểu thuyết: {type}\nSố: {volume} | Tác giả: {author} | Ngày nhập: {importDate} | Giá: {price} - Đang được mượn: {IsBorrowed}";
            return s;
        }

        public override string Format4File()
        {
            string s = $"novel|{bookid}|{classification}|{title}|{author}|{type}|{volume}|{price}|{importDate}|{isBorrowed}*";
            return s;
        }
    }

    public class Comic : Books
    {
        private int volume;

        public int Volume { get { return volume; } set { this.volume = value; } }

        public Comic() { }
        public Comic(string bookid, string classification, string title, string author, int volume, long price, string importDate, bool isBorrowed)
        {
            this.bookid = bookid;
            this.classification = classification;
            this.title = title;
            this.author = author;
            this.volume = volume;
            this.price = price;
            this.importDate = importDate;
            this.isBorrowed = isBorrowed;
        }

        public override string Display()
        {
            string s = $"ID truyện: {bookid} | Thể loại: {classification} | Tựa: {title} | Tác giả: {author} | Số: {volume} | Ngày nhập: {importDate} | Giá: {price}) - Đang được mượn: {IsBorrowed}";
            return s;
        }

        public override string Format4File()
        {
            string s = $"comic|{bookid}|{classification}|{title}|{author}|{volume}|{price}|{importDate}|{isBorrowed}*";
            return s;
        }
    }

    public class Magazine : Books
    {
        private int volume;
        private string type;

        public int Volume { get { return volume; } set { this.volume = value; } }
        public string Type { get { return type; } set { this.type = value; } }

        public Magazine() { }
        public Magazine(string bookid, string classification, string title, int volume, string type, long price, string importDate, bool isBorrowed)
        {
            this.bookid = bookid;
            this.classification = classification;
            this.title = title;
            author = "Nhiều tác giả";
            this.volume = volume;
            this.type = type;
            this.price = price;
            this.importDate = importDate;
            this.isBorrowed = isBorrowed;
        }

        public override string Display()
        {
            string s = $"ID tạp chí: {bookid} | Thể loại: {classification} | Tựa: {title} | Loại tạp chí: {type} | Số: {volume} | Ngày nhập: {importDate} | Giá: {price} - Đang được mượn: {IsBorrowed}";
            return s;
        }
        public override string Format4File()
        {
            string s = $"mag|{bookid}|{classification}|{title}|{volume}|{type}|{price}|{importDate}|{isBorrowed}*";
            return s;
        }
    }

    public class Reference : Books
    {
        private string subject;

        public string Subject { get { return subject; } set { this.subject = value; } }

        public Reference() { }
        public Reference(string bookid, string classification, string title, string subject, string author, long price, string importDate, bool isBorrowed)
        {
            this.bookid = bookid;
            this.classification = classification;
            this.title = title;
            this.subject = subject;
            this.author = author;
            this.price = price;
            this.importDate = importDate;
            this.isBorrowed = isBorrowed;
        }

        public override string Display()
        {
            string s = $"ID sách TK: {bookid} | Thể loại: {classification} | Tựa: {title} | Chủ đề: {subject} | Tác giả: {author} | Ngày nhập: {importDate} | Giá: {price} - Đang được mượn: {IsBorrowed}";
            return s;
        }
        public override string Format4File()
        {
            string s = $"refer|{bookid}|{classification}|{title}|{subject}|{author}|{price}|{importDate}|{isBorrowed}*";
            return s;
        }
    }
}

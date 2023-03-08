using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public static class Manage
    {
        private static List<Books> books = new List<Books>();
        private static List<Employee> employees = new List<Employee>();
        private static List<Shift> shifts = new List<Shift>();
        private static List<Record> records = new List<Record>();
        private static List<Borrower> borrowers = new List<Borrower>();

        // Tìm kiếm
        public static List<Books> FilterBooks(string input)
        {
            List<Books> newlist = new List<Books>();
            foreach (Books item in books)
            {
                if (item != null)
                {
                    if (item.BookID.ToLower().Contains(input.ToLower()) || item.Title.ToLower().Contains(input.ToLower())
                       || item.Classification.ToLower().Contains(input.ToLower()) || item.Author.ToLower().Contains(input.ToLower())
                       || item.ImportDate.ToLower().Contains(input.ToLower())
                       )
                    {
                        newlist.Add(item);
                    }
                }
            }
            return newlist;
        }

        public static List<Employee> FilterEmployees(string input)
        {
            List<Employee> newlist = new List<Employee>();
            foreach (Employee person in employees)
            {
                if (person != null)
                {
                    if (person.EmId.ToLower().Contains(input.ToLower()) || person.Name.ToLower().Contains(input.ToLower()) 
                        || person.Shift.ToLower().Contains(input.ToLower()) || person.Position.ToLower().Contains(input.ToLower())
                        || person.Gender.ToLower().Contains(input.ToLower()))
                    {
                        newlist.Add(person);
                    }
                }
            }
            return newlist;
        }

        public static List<Record> FilterRecords(string input)
        {
            List<Record> newlist = new List<Record>();
            foreach (Record rec in records)
            {
                if (rec != null)
                {
                    if (rec.RecId.ToLower().Contains(input.ToLower()) || rec.BoId.ToLower().Contains(input.ToLower()) 
                        || rec.Type.ToLower().Contains(input.ToLower()) || rec.Date.ToLower().Contains(input.ToLower()))
                    {
                        newlist.Add(rec);
                    }
                }
            }
            return newlist;
        }

        public static List<Borrower> FilterBorrowers(string input)
        {
            List<Borrower> newlist = new List<Borrower>();
            foreach (Borrower bor in borrowers)
            {
                if (bor != null)
                {
                    if (bor.Boid.ToLower().Contains(input.ToLower()) || bor.Name.ToLower().Contains(input.ToLower())
                        || bor.Phone.ToLower().Contains(input.ToLower()))
                    {
                        newlist.Add(bor);
                    }
                }
            }
            return newlist;
        }

        public static List<Shift> FilterShifts(string input)
        {
            List<Shift> newlist = new List<Shift>();
            foreach(Shift shift in shifts)
            {
                if (shift != null)
                {
                    if (shift.Shiftid.ToLower().Contains(input.ToLower()) || shift.StartTime.ToLower().Contains(input.ToLower()) || shift.EndTime.ToLower().Contains(input.ToLower()))
                    {
                        newlist.Add(shift);
                    }
                }
            }
            return newlist;
        }

        // Kiểm tra ID
        public static bool CheckID(string id)
        {
            foreach (Books book in books)
            {
                if (id == book.BookID) return false;
            }
            foreach (Employee emp in employees)
            {
                if (id == emp.EmId) return false;
            }
            foreach (Shift shift in shifts)
            {
                if (id == shift.Shiftid) return false;
            }
            foreach (Record rec in records)
            {
                if (id == rec.RecId) return false;
            }
            foreach (Borrower bor in borrowers)
            {
                if (id == bor.Boid) return false;
            }
            return true;
        }

        // In ra màn hình
        public static void DisplayBooks()
        {
            foreach (Books book in books)
            {
                Console.WriteLine(book.Display());
                Console.WriteLine();
            }
        }

        public static void DisplayEmployees()
        {
            foreach (Employee em in employees)
            {
                Console.WriteLine(em.Display());
                Console.WriteLine();
            }
        }

        public static void DisplayShifts()
        {
            foreach (Shift shift in shifts)
            {
                Console.WriteLine(shift.Display());
                Console.WriteLine();
            }
        }

        public static void DisplayRecord()
        {
            foreach (Record rec in records)
            {
                Console.WriteLine(rec.Display());
                Console.WriteLine();
            }
        }

        public static void DisplayBorrowers()
        {
            foreach(Borrower bor in borrowers)
            {
                Console.WriteLine(bor.Display());
                Console.WriteLine();
            }
        }

        // Thêm
        public static void Add(object obj)
        {
            if (obj.GetType() == typeof(Novel)) books.Add((Novel)obj);
            if (obj.GetType() == typeof(Comic)) books.Add((Comic)obj);
            if (obj.GetType() == typeof(Magazine)) books.Add((Magazine)obj);
            if (obj.GetType() == typeof(Reference)) books.Add((Reference)obj);

            if (obj.GetType() == typeof(Employee)) employees.Add((Employee)obj);
            if (obj.GetType() == typeof(Shift)) shifts.Add((Shift)obj);
            if (obj.GetType() == typeof(Record)) records.Add((Record)obj);
            if (obj.GetType() == typeof(Borrower)) borrowers.Add((Borrower)obj);
        }

        // Xóa 
        public static void Delete(object obj)
        {
            if (obj.GetType() == typeof(Books)) books.Remove((Books)obj);
            if (obj.GetType() == typeof(Employee)) employees.Remove((Employee)obj);
            if (obj.GetType() == typeof(Shift)) shifts.Remove((Shift)obj);
            if (obj.GetType() == typeof(Record)) records.Remove((Record)obj);
            if (obj.GetType() == typeof(Borrower)) borrowers.Remove((Borrower)obj);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Xóa thành công");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Sửa
        public static void Edit(object obj)
        {
            if (obj.GetType() == typeof(Books))
            {
                if (obj is Novel novel)
                {
                    Console.WriteLine("Nhập giá trị mới (Để trống nếu muốn giữ nguyên\n)");
                    Console.WriteLine("[{0}] | New author: ", novel.Author); string newau = Console.ReadLine();
                    if (newau != "") novel.Author = newau;
                    Console.WriteLine("[{0}] | New title: ", novel.Title); string newti = Console.ReadLine();
                    if (newti != "") novel.Title = newti;
                    Console.WriteLine("[{0}] | New type: ", novel.Type); string newty = Console.ReadLine();
                    if (newty != "") novel.Type = newty;
                    Console.WriteLine("[{0}] | New volume: ", novel.Volume); string newvol = Console.ReadLine();
                    if (newvol != "") novel.Volume = int.Parse(newvol);
                    Console.WriteLine("[{0}] | New price: ", novel.Price); string newpri = Console.ReadLine();
                    if (newpri != "") novel.Price = long.Parse(newpri);
                    Console.WriteLine("[{0}] | New import date: ", novel.ImportDate); string newimd = Console.ReadLine();
                    if (newimd != "") novel.ImportDate = newimd;
                }
                if (obj is Comic comic)
                {
                    Console.WriteLine("Nhập giá trị mới (Để trống nếu muốn giữ nguyên\n)");
                    Console.WriteLine("[{0}] | New author: ", comic.Author); string newau = Console.ReadLine();
                    if (newau != "") comic.Author = newau;
                    Console.WriteLine("[{0}] | New title: ", comic.Title); string newti = Console.ReadLine();
                    if (newti != "") comic.Title = newti;
                    Console.WriteLine("[{0}] | New volume: ", comic.Volume); string newvol = Console.ReadLine();
                    if (newvol != "") comic.Volume = int.Parse(newvol);
                    Console.WriteLine("[{0}] | New price: ", comic.Price); string newpri = Console.ReadLine();
                    if (newpri != "") comic.Price = long.Parse(newpri);
                    Console.WriteLine("[{0}] | New import date: ", comic.ImportDate); string newimd = Console.ReadLine();
                    if (newimd != "") comic.ImportDate = newimd;
                }
                if (obj is Magazine mag)
                {
                    Console.WriteLine("Nhập giá trị mới (Để trống nếu muốn giữ nguyên\n)");
                    Console.WriteLine("[{0}] | New title: ", mag.Title); string newti = Console.ReadLine();
                    if (newti != "") mag.Title = newti;
                    Console.WriteLine("[{0}] | New volume: ", mag.Volume); string newvol = Console.ReadLine();
                    if (newvol != "") mag.Volume = int.Parse(newvol);
                    Console.WriteLine("[{0}] | New type: ", mag.Type); string newty = Console.ReadLine();
                    if (newty != "") mag.Type = newty;
                    Console.WriteLine("[{0}] | New price: ", mag.Price); string newpri = Console.ReadLine();
                    if (newpri != "") mag.Price = long.Parse(newpri);
                    Console.WriteLine("[{0}] | New import date: ", mag.ImportDate); string newimd = Console.ReadLine();
                    if (newimd != "") mag.ImportDate = newimd;
                }
                if (obj is Reference refer)
                {
                    Console.WriteLine("Nhập giá trị mới (Để trống nếu muốn giữ nguyên\n)");
                    Console.Write("[{0}] | New author: ", refer.Author); string newau = Console.ReadLine();
                    if (newau != "") refer.Author = newau;
                    Console.Write("[{0}] | New title: ", refer.Title); string newti = Console.ReadLine();
                    if (newti != "") refer.Title = newti;
                    Console.Write("[{0}] | New price: ", refer.Price); string newpri = Console.ReadLine();
                    if (newpri != "") refer.Price = long.Parse(newpri);
                    Console.Write("[{0}] | New import date: ", refer.ImportDate); string newimd = Console.ReadLine();
                    if (newimd != "") refer.ImportDate = newimd;
                    Console.Write("[{0}] | New subject: ", refer.Subject); string newsub = Console.ReadLine();
                    if (newpri != "") refer.Subject = newsub;
                }
            }
            if (obj is Employee em)
            {
                Console.WriteLine("Nhập thông tin cần sửa (Để trống nếu muốn giữ nguyên)\n");
                Console.Write("[{0}] | New name: ", em.Name); string newna = Console.ReadLine();
                if (newna != "") em.Name = newna;
                Console.Write("[{0}] | New gender (M/F): ", em.Gender); string newgen = Console.ReadLine();
                if (newgen != "") em.Gender = newgen;
                Console.Write("[{0}] | New position: ", em.Position); string newpos = Console.ReadLine();
                if (newpos != "") em.Position = newpos;
                Console.Write("[{0}] | New shift: ", em.Shift); string newshi = Console.ReadLine();
                if (newshi != "") em.Shift = newshi;
                Console.Write("[{0}] | New address: ", em.Address); string newaddr = Console.ReadLine();
                if (newaddr != "") em.Address = newaddr;
                Console.Write("[{0}] | New phone: ", em.Phone); string newpho = Console.ReadLine();
                if (newpho != "") em.Phone = newpho;
            }
            if (obj is Shift shift)
            {
                Console.Write("Nhập thông tin cần sửa (Để trống nếu muốn giữ nguyên)\n");
                Console.Write("[{0}] | New starting time: ", shift.StartTime); string newsta = Console.ReadLine();
                if (newsta != "") shift.StartTime = newsta;
                Console.Write("[{0}] | New end time: ", shift.EndTime); string newend = Console.ReadLine();
                if (newend != "") shift.EndTime = newend;
            }
            if (obj is Record rec)
            {
                Console.Write("Nhập thông tin cần sửa (Để trống nếu muốn giữ nguyên)\n");
                Console.Write("[{0}] | New type (L/R): ", rec.Type); string newty = Console.ReadLine();
                if (newty != "") rec.Type = newty;
                Console.Write("[{0}] | New date: ", rec.Date); string newda = Console.ReadLine();
                if (newda != "") rec.Date = newda;
            }
            if (obj is Borrower bor)
            {
                Console.Write("Nhập thông tin cần sửa (Để trống nếu muốn giữ nguyên)\n");
                Console.Write("[{0}] | New nam: ", bor.Name); string newna = Console.ReadLine();
                if (newna != "") bor.Name = newna;
                Console.WriteLine("[{0}] | New phone: ", bor.Phone); string newpho = Console.ReadLine();
                if (newpho != "") bor.Phone = newpho;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sửa thành công");
            Console.ForegroundColor = ConsoleColor.White;
        }        

        // Cho mượn
        public static void LendBook(Books book, Borrower bor)
        {
            book.isBorrowed = true;
            string recid = "REC" + records.Count.ToString("00");
            string lenddate = DateTime.Now.ToString("dd/MM/yyyy");
            Record record = new Record(recid, book.BookID, bor.Boid, "L", lenddate);
            records.Add(record);
        }

        // Nhận lại sách
        public static void ReturnBook(Books book, Borrower bor)
        {
            book.isBorrowed = false;
            string recid = "REC" + records.Count.ToString("00");
            string returndate = DateTime.Now.ToString("dd/MM/yyyy");

            Record record = new Record(recid, book.BookID, bor.Boid, "R", returndate);
            records.Add(record);
        }

        // Ghi ra file
        public static void Write2File()
        {
            using (StreamWriter sw = File.CreateText(@"C:\Users\quang\Desktop\dataBooks.txt"))
            {
                foreach (Books book in books) sw.WriteLine(book.Format4File());
                sw.Close();
            }
            using (StreamWriter sw = File.CreateText(@"C:\Users\quang\Desktop\dataEmployees.txt"))
            {
                foreach (Employee emp in employees) sw.WriteLine(emp.Format4File());
                sw.Close();
            }
            using (StreamWriter sw = File.CreateText(@"C:\Users\quang\Desktop\dataShifts.txt"))
            {
                foreach (Shift shift in shifts) sw.WriteLine(shift.Format4File());
                sw.Close();
            }
            using (StreamWriter sw = File.CreateText(@"C:\Users\quang\Desktop\dataRecords.txt"))
            {
                foreach (Record rec in records) sw.WriteLine(rec.Format4File());
                sw.Close();
            }
            using (StreamWriter sw = File.CreateText(@"C:\Users\quang\Desktop\dataBorrowers.txt"))
            {
                foreach (Borrower bor in borrowers) sw.WriteLine(bor.Format4File());
                sw.Close();
            }
        }

        // Đọc từ file
        public static void ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\quang\Desktop\dataBooks.txt"))
            {
                string s = "";
                string r;
                do
                {
                    r = sr.ReadLine();
                    s += r;
                } while (r != null);
                sr.Close();
                string[] sub1 = s.Split('*');
                for (int i = 0; i < sub1.Length - 1; i++)
                {
                    string[] sub2 = sub1[i].Split('|');
                    if (sub2[0] == "novel") Add(new Novel(sub2[1], sub2[2], sub2[3], sub2[4], sub2[5], int.Parse(sub2[6]), long.Parse(sub2[7]), sub2[8], bool.Parse(sub2[9])));
                    else if (sub2[0] == "comic") Add(new Comic(sub2[1], sub2[2], sub2[3], sub2[4], int.Parse(sub2[5]), long.Parse(sub2[6]), sub2[7], bool.Parse(sub2[8])));
                    else if (sub2[0] == "mag") Add(new Magazine(sub2[1], sub2[2], sub2[3], int.Parse(sub2[4]), sub2[5], long.Parse(sub2[6]), sub2[7], bool.Parse(sub2[8])));
                    else if (sub2[0] == "refer") Add(new Reference(sub2[1], sub2[2], sub2[3], sub2[4], sub2[5], long.Parse(sub2[6]), sub2[7], bool.Parse(sub2[8])));
                }
            }
            using (StreamReader sr = new StreamReader(@"C:\Users\quang\Desktop\dataEmployees.txt"))
            {
                string s = "";
                string r;
                do
                {
                    r = sr.ReadLine();
                    s += r;
                } while (r != null);
                sr.Close();
                string[] sub1 = s.Split('*');
                for (int i = 0; i < sub1.Length - 1; i++)
                {   
                    string[] sub2 = sub1[i].Split('|');
                    Add(new Employee(sub2[0], sub2[1], sub2[2], sub2[3], sub2[4], sub2[5], sub2[6], double.Parse(sub2[7])));
                }
            }
            using (StreamReader sr = new StreamReader(@"C:\Users\quang\Desktop\dataShifts.txt"))
            {
                string s = "";
                string r;
                do
                {
                    r = sr.ReadLine();
                    s += r;
                } while (r != null);
                sr.Close();
                string[] sub1 = s.Split('*');
                for (int i = 0; i < sub1.Length - 1; i++)
                {
                    string[] sub2 = sub1[i].Split('|');
                    Add(new Shift(sub2[0], sub2[1], sub2[2]));
                }
            }
            using (StreamReader sr = new StreamReader(@"C:\Users\quang\Desktop\dataRecords.txt"))
            {
                string s = "";
                string r;
                do
                {
                    r = sr.ReadLine();
                    s += r;
                } while (r != null);
                sr.Close();
                string[] sub1 = s.Split('*');
                for (int i = 0; i < sub1.Length - 1; i++)
                {
                    string[] sub2 = sub1[i].Split('|');
                    Add(new Record(sub2[0], sub2[1], sub2[2], sub2[3], sub2[4]));
                }
            }
            using (StreamReader sr = new StreamReader(@"C:\Users\quang\Desktop\dataBorrowers.txt"))
            {
                string s = "";
                string r;
                do
                {
                    r = sr.ReadLine();
                    s += r;
                } while (r != null);
                sr.Close();
                string[] sub1 = s.Split('*');
                for (int i = 0; i < sub1.Length - 1; i++)
                {
                    string[] sub2 = sub1[i].Split('|');
                    Add(new Borrower(sub2[0], sub2[1], sub2[2]));
                }
            }
        }

        // Tính tiền lương
        public static void SetSalary(Employee em)
        {
            foreach (Shift shift in shifts)
            {
                if (em.Shift == shift.Shiftid)
                {
                    DateTime start = DateTime.ParseExact(shift.StartTime, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime end = DateTime.ParseExact(shift.EndTime, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    int hrs = end.Subtract(start).Hours;
                    if (em.Position == "librarian")
                    {
                        em.Salary += Math.Abs(Math.Round(hrs * 20000 * 30 * 1.2));
                    }
                    else if (em.Position == "tech")
                    {
                        em.Salary += Math.Abs(Math.Round(hrs * 20000 * 30 * 1.1));
                    }
                    else if (em.Position == "assistant")
                    {
                        em.Salary += Math.Abs(Math.Round(hrs * 20000 * 30 * 1.1));
                    }
                    else if (em.Position == "labor")
                    {
                        em.Salary += Math.Abs(Math.Round(hrs * 20000 * 30 * 1.05));
                    }
                    else if (em.Position == "pr")
                    {
                        em.Salary += Math.Abs(Math.Round(hrs * 20000 * 30 * 1.1));
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Project
{
    public class Program
    { 

        static void Main(string[] args)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

        MAINMENU:
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - "QUẢN LÝ THƯ VIỆN".Length) / 2, Console.CursorTop);
            Console.WriteLine("QUẢN LÝ THƯ VIỆN\n");
            Console.SetCursorPosition((Console.WindowWidth - "THÀNH VIÊN".Length) / 2, Console.CursorTop);
            Console.WriteLine("THÀNH VIÊN");
            Console.SetCursorPosition((Console.WindowWidth - "Nhật Quang - Thảo Hiền - Phương Anh - Quốc Trung".Length) / 2, Console.CursorTop);
            Console.WriteLine("Nhật Quang - Thảo Hiền - Phương Anh - Quốc Trung");
            Console.SetCursorPosition((Console.WindowWidth - "-------------------------------------------".Length) / 2, Console.CursorTop);
            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("Chọn hoạt động: ");
            Console.WriteLine("> [1] Đọc dữ liệu");
            Console.WriteLine("> [2] Kho sách");
            Console.WriteLine("> [3] Nhân viên");
            Console.WriteLine("> [4] Ca làm");
            Console.WriteLine("> [5] Phiếu ghi nhận");
            Console.WriteLine("> [6] Người mượn");
            Console.WriteLine("> [7] Xuất dữ liệu\n");
            Console.WriteLine("> [0] Thoát chương trình\n\n");
            Console.Write("Chọn bằng cách nhấn phím tương ứng: "); string choice = Console.ReadLine();
            if (choice != "0" && choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6" && choice != "7")
            {
                Console.WriteLine("Không có lựa chọn này");
                goto MAINMENU;
            }

            switch (choice)
            {
                case "0": goto END;
                case "1": // Đọc data
                    {
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - "ĐỌC DỮ LIỆU".Length) / 2, Console.CursorTop);
                        Console.WriteLine("ĐỌC DỮ LIỆU\n");

                        Manage.ReadFromFile();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("---Đọc dữ liệu thành công---");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ReadLine();
                        goto MAINMENU;
                    }
                case "2": // Sách
                    {                        
                    ToBooks:
                        List<Books> lnovel = Manage.FilterBooks("novel");
                        List<Books> lcomic = Manage.FilterBooks("comic");
                        List<Books> lmag = Manage.FilterBooks("magazine");
                        List<Books> lrefer = Manage.FilterBooks("reference");
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - "SÁCH".Length) / 2, Console.CursorTop);
                        Console.WriteLine("SÁCH\n");                       
                        Manage.DisplayBooks();
                        Console.SetCursorPosition((Console.WindowWidth - "-----------------------------------".Length) / 2, Console.CursorTop);
                        Console.WriteLine("-----------------------------------\n\n\n");

                        Console.WriteLine("Thống kê: Novel - {0} | Comic - {1} | Magazine - {2} | Reference - {3}\n----------------------", 
                                            lnovel.Count, lcomic.Count, lmag.Count, lrefer.Count);
                        Console.WriteLine("> [1] Thêm sách");
                        Console.WriteLine("> [2] Xóa sách");
                        Console.WriteLine("> [3] Sửa sách");
                        Console.WriteLine("> [4] Tìm kiếm\n\n");
                        Console.WriteLine("> [0] Trở về");
                        Console.Write("Nhập lựa chọn: "); string choicec2 = Console.ReadLine();
                        if (choicec2 != "0" && choicec2 != "1" && choicec2 != "2" && choicec2 != "3" && choicec2 != "4" && choicec2 != "5")
                        {
                            Console.WriteLine("Không có lựa chọn này");
                            goto ToBooks;
                        }
                        switch (choicec2)
                        {
                            case "0": goto MAINMENU;
                            case "1":
                                {
                                    Console.WriteLine("Nhập thông tin sách:\n");
                                    reinputbookid:
                                    Console.Write("ID sách:"); string id = Console.ReadLine();
                                    if (!Manage.CheckID(id))
                                    {
                                        Console.WriteLine("ID không được trùng");
                                        goto reinputbookid;
                                    }
                                    Console.Write("Loại sách: "); string classification = Console.ReadLine();
                                    Console.Write("Tựa (tên) sách: "); string title = Console.ReadLine();
                                    Console.Write("Giá bìa: "); long price = long.Parse(Console.ReadLine());

                                    if (string.Compare(classification.ToLower(), "novel") == 0)
                                    {
                                        Console.Write("Tác giả: "); string author = Console.ReadLine();
                                        Console.Write("Loại tiểu thuyết: "); string type = Console.ReadLine();
                                        Console.Write("Số (tập) tiểu thuyết: "); int volume = int.Parse(Console.ReadLine());

                                        Manage.Add(new Novel(id, classification, title, author, type, volume, price, DateTime.Now.ToString("dd/MM/yyyy"), false));
                                    }

                                    if (string.Compare(classification.ToLower(), "comic") == 0)
                                    {
                                        Console.Write("Tác giả: "); string author = Console.ReadLine();
                                        Console.Write("Số (tập) truyện tranh: "); int volume = int.Parse(Console.ReadLine());

                                        Manage.Add(new Comic(id, classification, title, author, volume, price, DateTime.Now.ToString("dd/MM/yyyy"), false));
                                    }

                                    if (string.Compare(classification.ToLower(), "magazine") == 0)
                                    {
                                        Console.Write("Số tạp chí: "); int volume = int.Parse(Console.ReadLine());
                                        Console.Write("Loại tạp chí: "); string type = Console.ReadLine();

                                        Manage.Add(new Magazine(id, classification, title, volume, type, price, DateTime.Now.ToString("dd/MM/yyyy"), false));
                                    }

                                    if (string.Compare(classification.ToLower(), "reference") == 0)
                                    {
                                        Console.Write("Tựa môn: "); string subject = Console.ReadLine();
                                        Console.Write("Tác giả: "); string author = Console.ReadLine();

                                        Manage.Add(new Reference(id, classification, title, subject, author, price, DateTime.Now.ToString("dd/MM/yyyy"), false));
                                    }

                                    goto ToBooks;
                                }
                            case "2":
                                {
                                    Console.WriteLine("Nhập ID của sách muốn xóa: "); string id = Console.ReadLine();
                                    List<Books> fordelete = Manage.FilterBooks(id);
                                    Console.WriteLine("Có chắc muốn xóa? [Y/N]"); string yorn = Console.ReadLine();
                                    if (yorn.ToLower() == "y") Manage.Delete(fordelete[0]);
                                   
                                    goto ToBooks;
                                }
                            case "3":
                                {
                                    Console.WriteLine("Nhập ID của sách muốn sửa: "); string id = Console.ReadLine();
                                    List<Books> foredit = Manage.FilterBooks(id);
                                    Manage.Edit(foredit[0]);
                                    goto ToBooks;
                                }
                            case "4":
                                {
                                    Console.WriteLine("Nhập chuỗi tìm kiếm (ID sách, tác giả, ...): "); string input = Console.ReadLine();
                                    List<Books> fordisplay = Manage.FilterBooks(input);
                                    Console.WriteLine("Tìm được {0} kết quả: \n", fordisplay.Count);
                                    foreach(Books book in fordisplay)
                                    {
                                        Console.WriteLine(book.Display());
                                        Console.WriteLine();
                                    }
                                    goto ToBooks;
                                }
                        }
                        Console.ReadLine();
                        goto MAINMENU;
                    }
                case "3": // Nhân viên
                    {                     
                    ToEmployees:
                        List<Employee> lemployee = Manage.FilterEmployees("NV");
                        List<Employee> llibrarian = Manage.FilterEmployees("librarian");
                        List<Employee> lassistant = Manage.FilterEmployees("assistant");
                        List<Employee> ltech = Manage.FilterEmployees("tech");
                        List<Employee> llabor = Manage.FilterEmployees("labor");
                        List<Employee> lpr = Manage.FilterEmployees("pr");
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - "NHÂN VIÊN".Length) / 2, Console.CursorTop);
                        Console.WriteLine("NHÂN VIÊN\n");
                        Manage.DisplayEmployees();
                        Console.SetCursorPosition((Console.WindowWidth - "-----------------------------------".Length) / 2, Console.CursorTop);
                        Console.WriteLine("-----------------------------------\n\n\n");

                        Console.WriteLine("Thống kê: Số nhân viên - {0} | Số thủ thư - {1} | Số trợ lý - {2} | Số NVKT - {3} | Số lao công - {4} | Số nhân viên PR - {5}\n----------------------",
                                            lemployee.Count, llibrarian.Count, lassistant.Count, ltech.Count, llabor.Count, lpr.Count);
                        Console.WriteLine("> [1] Thêm nhân viên");
                        Console.WriteLine("> [2] Xóa nhân viên");
                        Console.WriteLine("> [3] Sửa nhân viên");
                        Console.WriteLine("> [4] Tìm kiếm");
                        Console.WriteLine("> [5] Tính lương\n\n");
                        Console.WriteLine("> [0] Trở về");
                        Console.Write("Nhập lựa chọn: "); string choicec3 = Console.ReadLine();
                        if (choicec3 != "0" && choicec3 != "1" && choicec3 != "2" && choicec3 != "3" && choicec3 != "4" && choicec3 != "5")
                        {
                            Console.WriteLine("Không có lựa chọn này");
                            goto ToEmployees;
                        }
                        switch (choicec3)
                        {
                            case "0": goto MAINMENU;
                            case "1":
                                {
                                    Console.WriteLine("Nhập thông tin nhân viên: \n");
                                    reinputempid:
                                    Console.Write("ID nhân viên: "); string id = Console.ReadLine();
                                    if (!Manage.CheckID(id))
                                    {
                                        Console.WriteLine("ID không được trùng");
                                        goto reinputempid;
                                    }
                                    Console.Write("Tên nhân viên: "); string name = Console.ReadLine();
                                    Console.Write("Giới tính (M/F): "); string gender = Console.ReadLine();
                                    Console.Write("Ca làm: "); string shift = Console.ReadLine();
                                    Console.Write("Chức vụ (librarian/assistant/tech/labor/pr): "); string position = Console.ReadLine();
                                    Console.Write("Địa chỉ: "); string address = Console.ReadLine();
                                    Console.Write("Số điện thoại: "); string phone = Console.ReadLine();
                                   
                                    Manage.Add(new Employee(id, name, gender, shift, position, address, phone, 0.0));
                                    goto ToEmployees;
                                }
                            case "2":
                                {
                                    Console.Write("Nhập ID nhân viên muốn xóa: "); string id = Console.ReadLine();
                                    List<Employee> fordelete = Manage.FilterEmployees(id);
                                    Console.Write("Có chắc muốn xóa? [Y/N]"); string yorn = Console.ReadLine();
                                    if (yorn.ToLower() == "y") Manage.Delete(fordelete[0]);
                                    goto ToEmployees;
                                }
                            case "3":
                                {
                                    Console.Write("Nhập ID nhân viên muốn sửa: "); string id = Console.ReadLine();
                                    List<Employee> foredit = Manage.FilterEmployees(id);
                                    Manage.Edit(foredit[0]);
                                    goto ToEmployees;
                                }
                            case "4":
                                {
                                    Console.Write("Nhập chuỗi tìm kiếm (ID nhân viên, tên, ...): "); string input = Console.ReadLine();
                                    List<Employee> fordisplay = Manage.FilterEmployees(input);
                                    Console.WriteLine("Tìm được {0} kết quả: \n", fordisplay.Count);
                                    foreach (Employee employee in fordisplay)
                                    {
                                        Console.WriteLine(employee.Display());
                                        Console.WriteLine();
                                    }
                                    goto ToEmployees;
                                }
                            case "5":
                                {
                                    Console.Write("Nhập ID nhân viên cần tính lương: "); string id = Console.ReadLine();
                                    List<Employee> forsetsalary = Manage.FilterEmployees(id);
                                    Manage.SetSalary(forsetsalary[0]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Tính lương thành công.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                    goto ToEmployees;
                                }
                        }
                        goto MAINMENU;
                    }
                case "4": // Ca làm
                    {
                        ToShifts:
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - "CA LÀM".Length) / 2, Console.CursorTop);
                        Console.WriteLine("CA LÀM\n");
                        Manage.DisplayShifts();
                        Console.SetCursorPosition((Console.WindowWidth - "-----------------------------------".Length) / 2, Console.CursorTop);
                        Console.WriteLine("-----------------------------------\n\n\n");

                        Console.WriteLine("Thống kê: Số ca - {0}\n----------------------");
                        Console.WriteLine("> [1] Thêm ca làm");
                        Console.WriteLine("> [2] Xóa ca làm");
                        Console.WriteLine("> [3] Sửa ca làm");
                        Console.WriteLine("> [0] Trở về");
                        Console.WriteLine("Nhập lựa chọn: "); string choicec4 = Console.ReadLine();
                        if (choicec4 != "0" && choicec4 != "1" && choicec4 != "2" && choicec4 != "3" && choicec4 != "4" && choicec4 != "5")
                        {
                            Console.WriteLine("Không có lựa chọn này");
                            goto ToShifts;
                        }

                        switch (choicec4)
                        {
                            case "0": goto MAINMENU;
                            case "1":
                                {
                                    Console.WriteLine("Nhập thông tin ca làm: \n");
                                    reinputshiftid:
                                    Console.Write("ID: "); string shiftid = Console.ReadLine();
                                    if (!Manage.CheckID(shiftid))
                                    {
                                        Console.WriteLine("ID không được trùng");
                                        goto reinputshiftid;
                                    }
                                    Console.WriteLine("Thời điểm bắt đầu: "); string startTime = Console.ReadLine();
                                    Console.WriteLine("Thời điểm kết thúc"); string endTime = Console.ReadLine();

                                    Manage.Add(new Shift(shiftid, startTime, endTime));
                                    goto ToShifts;
                                }
                            case "2":
                                {
                                    Console.WriteLine("Nhập ID của ca muốn xóa: "); string id = Console.ReadLine();
                                    List<Shift> fordelete = Manage.FilterShifts(id);
                                    Console.WriteLine("Có chắc muốn xóa? [Y/N]"); string yorn = Console.ReadLine();
                                    if (yorn.ToLower() == "y") Manage.Delete(fordelete[0]);
                                    goto ToShifts;
                                }
                            case "3":
                                {
                                    Console.WriteLine("Nhập ID của sách muốn sửa: "); string id = Console.ReadLine();
                                    List<Shift> foredit = Manage.FilterShifts(id);
                                    Manage.Edit(foredit[0]);
                                    goto ToShifts;
                                }
                            case "4":
                                {
                                    Console.WriteLine("Nhập chuỗi tìm kiếm (ID sách, thời gian, ...): "); string input = Console.ReadLine();
                                    List<Shift> fordisplay = Manage.FilterShifts(input);
                                    Console.WriteLine("Tìm được {0} kết quả: \n", fordisplay.Count);
                                    foreach (Shift shift in fordisplay)
                                    {
                                        Console.WriteLine(shift.Display());
                                        Console.WriteLine();
                                    }
                                    goto ToShifts;
                                }
                        }


                        goto MAINMENU;
                    }
                case "5": // Phiếu ghi nhận
                    {
                    ToRecord:
                        List<Record> llendrecord = Manage.FilterRecords("L");
                        List<Record> lreturnrecord = Manage.FilterRecords("R");
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - "PHIẾU GHI NHẬN".Length) / 2, Console.CursorTop);
                        Console.WriteLine("PHIẾU GHI NHẬN\n");
                        Manage.DisplayRecord();
                        Console.SetCursorPosition((Console.WindowWidth - "-----------------------------------".Length) / 2, Console.CursorTop);
                        Console.WriteLine("-----------------------------------\n\n\n");

                        Console.WriteLine("Thống kê: Phiếu mượn - {0} | Phiếu trả - {1}", llendrecord.Count, lreturnrecord.Count);
                        Console.WriteLine("> [1] Cho mượn sách");
                        Console.WriteLine("> [2] Nhận trả sách");
                        Console.WriteLine("> [3] Sửa phiếu ghi nhận");
                        Console.WriteLine("> [4] Tìm kiếm phiếu\n\n");
                        Console.WriteLine("> [0] Trở về"); string choicec5 = Console.ReadLine();
                        if (choicec5 != "0" && choicec5 != "1" && choicec5 != "2" && choicec5 != "3" && choicec5 != "4")
                        {
                            Console.WriteLine("Không có lựa chọn này");
                            goto ToRecord;
                        }
                        switch(choicec5)
                        {
                            case "0": goto MAINMENU;
                            case "1":
                                {
                                    Console.Write("Nhập ID sách cần cho mượn: "); string id1 = Console.ReadLine();
                                    List<Books> forborrow1 = Manage.FilterBooks(id1);
                                    Console.Write("Nhập ID khách hàng: "); string id2 = Console.ReadLine();
                                    List<Borrower> forborrow2 = Manage.FilterBorrowers(id2);
                                    Manage.LendBook(forborrow1[0], forborrow2[0]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Cho mượn thành công.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                    goto ToRecord;
                                }
                            case "2":
                                {
                                    Console.Write("Nhập ID sách nhận trả: "); string id1 = Console.ReadLine();
                                    List<Books> forborrow1 = Manage.FilterBooks(id1);
                                    Console.Write("Nhập ID khách hàng: "); string id2 = Console.ReadLine();
                                    List<Borrower> forborrow2 = Manage.FilterBorrowers(id2);
                                    Manage.ReturnBook(forborrow1[0], forborrow2[0]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Nhận trả thành công.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                    goto ToRecord;
                                }
                            case "3":
                                {
                                    Console.Write("Nhập ID phiếu mượn: "); string id = Console.ReadLine();
                                    List<Record> foredit = Manage.FilterRecords(id);
                                    Manage.Edit(foredit[0]);
                                    goto ToRecord;
                                }
                            case "4":
                                {
                                    Console.Write("Nhập chuỗi tìm kiếm (ID phiếu, ID sách, ...): "); string input = Console.ReadLine();
                                    List<Record> fordisplay = Manage.FilterRecords(input);
                                    Console.WriteLine("Tìm được {0} kết quả: \n", fordisplay.Count);
                                    foreach (Record record in fordisplay)
                                    {
                                        Console.WriteLine(record.Display());
                                        Console.WriteLine();
                                    }
                                    goto ToRecord;
                                }
                        }
                        goto MAINMENU;
                    }
                case "6": // Người mượn
                    {
                    ToBorrower:
                        List<Borrower> lbor = Manage.FilterBorrowers("BO");
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - "NGƯỜI MƯỢN".Length) / 2, Console.CursorTop);
                        Console.WriteLine("NGƯỜI MƯỢN\n");
                        Manage.DisplayEmployees();
                        Console.SetCursorPosition((Console.WindowWidth - "-----------------------------------".Length) / 2, Console.CursorTop);
                        Console.WriteLine("-----------------------------------\n\n\n");

                        Console.WriteLine("Thống kê: Số người mượn - {0}", lbor.Count);
                        Console.WriteLine("> [1] Thêm người mượn");
                        Console.WriteLine("> [2] Xóa người mượn");
                        Console.WriteLine("> [3] Sửa người mượn");
                        Console.WriteLine("> [4] Tìm kiếm");
                        Console.WriteLine("> [0] Trở về");
                        Console.Write("Nhập lựa chọn: "); string choicec3 = Console.ReadLine();
                        if (choicec3 != "0" && choicec3 != "1" && choicec3 != "2" && choicec3 != "3" && choicec3 != "4")
                        {
                            Console.WriteLine("Không có lựa chọn này");
                            goto ToBorrower;
                        }
                        switch (choicec3)
                        {
                            case "0": goto MAINMENU;
                            case "1":
                                {
                                    Console.WriteLine("Nhập thông tin người mượn:\n");
                                    reinputborid:
                                    Console.Write("ID người mượn: "); string boid = Console.ReadLine();
                                    if (!Manage.CheckID(boid))
                                    {
                                        Console.WriteLine("ID không được trùng");
                                        goto reinputborid;
                                    }
                                    Console.Write("Tên người mượn: "); string name = Console.ReadLine();
                                    Console.Write("Số điện thoại: "); string phone = Console.ReadLine();
                                    Manage.Add(new Borrower(boid, name, phone));
                                    goto ToBorrower;
                                }
                            case "2":
                                {
                                    Console.Write("Nhập ID người mượn muốn xóa: "); string boid = Console.ReadLine();
                                    List<Borrower> fordelete = Manage.FilterBorrowers(boid);
                                    Console.Write("Có chắc muốn xóa? [Y/N]"); string yorn = Console.ReadLine();
                                    if (yorn.ToLower() == "y") Manage.Delete(fordelete[0]);
                                    goto ToBorrower;
                                }
                            case "3":
                                {
                                    Console.Write("Nhập ID người mượn muốn sửa: "); string boid = Console.ReadLine();
                                    List<Borrower> foredit = Manage.FilterBorrowers(boid);
                                    Manage.Edit(foredit[0]);
                                    goto ToBorrower;
                                }
                            case "4":
                                {
                                    Console.Write("Nhập chuỗi tìm kiếm (ID người mượn, tên, ...): "); string input = Console.ReadLine();
                                    List<Borrower> fordisplay = Manage.FilterBorrowers(input);
                                    Console.WriteLine("Tìm được {0} kết quả: \n", fordisplay.Count);
                                    foreach (Borrower borrowers in fordisplay)
                                    {
                                        Console.WriteLine(borrowers.Display());
                                        Console.WriteLine();
                                    }
                                    goto ToBorrower;
                                }
                        }
                        goto MAINMENU;
                    }
                case "7": // Xuất dữ liệu
                    {
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - "XUẤT DỮ LIỆU".Length) / 2, Console.CursorTop);
                        Console.WriteLine("XUẤT DỮ LIỆU\n");

                        Manage.Write2File();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Xuất dữ liệu thành công");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ReadLine();
                        break;
                    }
            }

        END:
            Console.SetCursorPosition((Console.WindowWidth - "CẢM ƠN ĐÃ SỬ DỤNG CHƯƠNG TRÌNH".Length) / 2, Console.CursorTop);
            Console.WriteLine("CẢM ƠN ĐÃ SỬ DỤNG CHƯƠNG TRÌNH");

            Console.ReadLine();
        }
    }
}
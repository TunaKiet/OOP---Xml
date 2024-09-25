using Lab_10___JSon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Lab_10___XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            string filePath = "data.xml";

            StudentList studentList = new StudentList();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Hiển thị danh sách sinh viên");
                Console.WriteLine("2. Thêm sinh viên mới");
                Console.WriteLine("3. Ghi dữ liệu sinh viên ra file");
                Console.WriteLine("4. Đọc dữ liệu sinh viên từ file");
                Console.WriteLine("5. Thoát");
                Console.Write("Lựa chọn của bạn: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayStudents(studentList);
                            break;
                        case 2:
                            AddNewStudent(studentList);
                            break;
                        case 3:
                            SaveToFile(filePath, studentList);
                            break;
                        case 4:
                            studentList = ReadFromFile(filePath);
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Vui lòng nhập số.");
                }
            }
        }

        // Phương thức hiển thị danh sách sinh viên
        static void DisplayStudents(StudentList studentList)
        {
            if (studentList.Students.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên rỗng.");
            }
            else
            {
                Console.WriteLine("\nDanh sách sinh viên:");
                foreach (Student student in studentList.Students)
                {
                    Console.WriteLine(student);
                }
            }
        }

        // Phương thức thêm sinh viên mới vào danh sách
        static void AddNewStudent(StudentList studentList)
        {
            Console.Write("Nhập ID sinh viên: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nhập tên sinh viên: ");
            string name = Console.ReadLine();
            Console.Write("Nhập tuổi sinh viên: ");
            int age = int.Parse(Console.ReadLine());

            studentList.Add(new Student() { Id = id, Name = name, Age = age });
            Console.WriteLine("Đã thêm sinh viên vào danh sách.");
        }

        // Phương thức ghi danh sách sinh viên ra file
        static void SaveToFile(string filePath, StudentList studentList)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(StudentList));
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    xmlSerializer.Serialize(writer, studentList);
                }
                Console.WriteLine("Dữ liệu đã được ghi vào file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi ghi dữ liệu vào file: {ex.Message}");
            }
        }

        // Phương thức đọc danh sách sinh viên từ file
        static StudentList ReadFromFile(string filePath)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(StudentList));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var studentList = (StudentList)xmlSerializer.Deserialize(reader);
                    Console.WriteLine("Dữ liệu đã được nạp từ file.");
                    return studentList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc dữ liệu từ file: {ex.Message}");
                return new StudentList();
            }
        }
    }
}

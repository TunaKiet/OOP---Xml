using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lab_10___JSon
{
    public class StudentList
    {
        private List<Student> students = new List<Student>();
        public List<Student> Students { get => students; set => students = value; }

        /* public StudentList() { }
         public void GetObjectDate(SerializationInfo info, StreamingContext context)
         {
             info.AddValue("Students", Students);
         }
         public StudentList(SerializationInfo info, StreamingContext context)
         {
             Students = (List<Student>)info.GetValue("Students", typeof(List<Student>));
         }
        */
        public void Add(Student item)
        {
            Students.Add(item);
        }
    }
}

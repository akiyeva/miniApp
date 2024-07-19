using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using miniApp.Enums;

namespace miniApp.Models
{
    internal class Classroom
    {
        private static int _id = 1;
        private int _limit;
        public int Id { get; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public ClassroomType Type { get; set; }
        public int StudentLimit { get; set; }

        public Classroom(string name, ClassroomType type)
        {
            Name = name;
            Type = type;
            Id = _id++;
            StudentLimit = (int)type;
        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
            student.ClassroomId = Id;
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }
        public Student FindStudentById(int id)
        {
            return Students.FirstOrDefault(x => x.Id == id);
        }
    }
}

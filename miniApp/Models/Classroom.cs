using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using miniApp.Enums;
using miniApp.Exceptions;

namespace miniApp.Models
{
    internal class Classroom
    {
        private static int _id = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public ClassroomType Type { get; set; }
        public int StudentLimit { get; set; }

        public Classroom(string name, ClassroomType type)
        {
            Id = _id++;
            Name = name;
            Type = type;
            Students = new List<Student>();

            switch (type)
            {
                case ClassroomType.Backend:
                    StudentLimit = 20;
                    break;
                case ClassroomType.Frontend:
                    StudentLimit = 15; 
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        public void AddStudent(Student student)
        {
            if (Students.Count >= StudentLimit)
            {
                throw new InvalidOperationException("Classroom limit reached.");
            }
            Students.Add(student);
            student.ClassroomId = Id;
        }

        public void RemoveStudent(int id)
        {
            var student = FindStudentById(id);
            Students.Remove(student);
        }
        public Student FindStudentById(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                throw new StudentNotFoundException("Student not found");
            }
            return student;
        }
    }
}

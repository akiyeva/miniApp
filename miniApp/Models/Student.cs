using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniApp.Models
{
    internal class Student
    {
        private static int _id = 1;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public Student(string name, string surname, int classroomId)
        {
            Name = name;
            Surname = surname;
            Id = _id++;
            ClassroomId = classroomId;
        }
     
    }
}

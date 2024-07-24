using miniApp.Enums;
using miniApp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniApp.Models
{
    public class Student
    {
        private static int _id = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ClassroomId { get; set; }
        public ClassroomType ClassroomType { get; set; }
        public Student(string name, string surname, int classroomId, ClassroomType classroomType)
        {
            if (!name.CheckName() || !surname.CheckName())
            {
                throw new ArgumentException("Invalid name or surname.");
            }

            Name = name;
            Surname = surname;
            Id = _id++;
            ClassroomId = classroomId;
            ClassroomType = classroomType;
        }
     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniApp
{
    internal class Student
    {
        private static int _id = 1;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}

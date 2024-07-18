using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace miniApp
{
    internal class Classroom
    {
        private static int _id = 1;
        private int _limit;
        public int Id { get; }
        public string Name { get; set; }
        public Student[] Students { get; set; }
        public ClassroomType Type { get; set; }
        public int StudentLimit
        {
            get => _limit; set
            {
                if (Type == ClassroomType.backend)
                    value = 20;
                else if (Type == ClassroomType.frontend)
                    value = 15;
            }
        }
    }
}

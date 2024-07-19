using miniApp.Helpers;
using miniApp.Models;
using System.Security.Cryptography.X509Certificates;

namespace miniApp
{
    internal class Program
    {
       
    
        static void Main(string[] args)
        { 
                 List<Student> studentsList = new List<Student>();

            List<Classroom> classroomsList = new List<Classroom>();
            Console.WriteLine("[1] Create classroom");
            Console.WriteLine("[2] Create student");
            Console.WriteLine("[3] Show all students");
            Console.WriteLine("[4] Show students by classroom(Id)");
            Console.WriteLine("[5] Remove student");

            int command = int.Parse(Console.ReadLine());

            switch (command)
            {
                case 1:
                    CreateClassroom();
                    break;
                case 2:
                    CreateStudent();
                    break;
                case 3:
                    GetAllStudents();
                    break;
                default:
                    Console.WriteLine();
                    break;
            }

        }

        public static List<Student> GetStudentsByClassroom(int id)
        {
            foreach(var classroom in classroomList)
            {

            }
        }

        public static IEnumerable<Student> GetAllStudents()
        {
            foreach (var student in studentsList)
            {
                yield return student;
            }

        }

        public static Classroom CreateClassroom()
        {
            string name = null;
            string type = null;
            while (true)
            {
                Console.WriteLine("Write name of a new classroom: ");
                name = Console.ReadLine();

                if (!name.CheckClassroomName())
                {
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.WriteLine("Write type of a new classroom (Backend or Frontend): ");
                type = Console.ReadLine().ToLower();
                // !
                break;
            }

        }


        public static Student CreateStudent(List<Classroom> classroomsList)
        {
            string name = null;
            string surname = null;
            int classroomId = 0;

            try
            {
                while (true)
                {
                    Console.WriteLine("Write name of a new student: ");
                    name = Console.ReadLine();

                    if (!name.CheckName())
                    {
                        Console.WriteLine("");
                        continue;
                    }
                    else
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Write surname of a new student: ");
                    surname = Console.ReadLine();

                    if (!surname.CheckName())
                    {
                        Console.WriteLine("");
                        continue;
                    }
                    else
                        break;
                }

                Console.WriteLine("Please choose classroom for student (enter Id):");
                for (int i = 0; i < classroomsList.Count; i++)
                {
                    Classroom classroom = classroomsList[i];
                    Console.WriteLine($"{classroom.Id}. {classroom}");
                }
                while (true)
                {
                    classroomId = int.Parse(Console.ReadLine());

                    for (int i = 0; i < classroomsList.Count; i++)
                    {
                        classroomsList.Find(x => x.Id == classroomId);
                        break;
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new Student(name, surname, classroomId);
            
        }
    }
}
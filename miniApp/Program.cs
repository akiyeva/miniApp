using miniApp.Enums;
using miniApp.Exceptions;
using miniApp.Helpers;
using miniApp.Models;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace miniApp
{
    internal class Program
    {
        private static List<Classroom> classrooms = new List<Classroom>();

        static void Main(string[] args)
        {

            try
            {
                while (true)
                {
                    Console.WriteLine("[1] Create classroom");
                    Console.WriteLine("[2] Create student");
                    Console.WriteLine("[3] Show all students");
                    Console.WriteLine("[4] Show students by classroom(Id)");
                    Console.WriteLine("[5] Remove student");
                    Console.WriteLine("[0] Exit");
                    if (!int.TryParse(Console.ReadLine(), out int command))
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                        continue;
                    }

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
                        case 4:
                            GetStudentsByClassroom();
                            break;
                        case 5:
                            RemoveStudent();
                            break;
                        case 0:
                            Json();
                            Environment.Exit(0);
                            break;
                        default:
                            Color.WriteLine("Not valid command. Please enter a number between 1 and 5.", ConsoleColor.Red);
                            break;
                    }

                }

            }
            catch (Exception ex)
            {
                Color.WriteLine($"Error: {ex}", ConsoleColor.Red);
            }
        }

        public static void Json()
        {
            try
            {
                var students = classrooms.SelectMany(c => c.Students).ToList();
                
                DataHandler.SaveStudents(students);
                DataHandler.SaveClassrooms(classrooms);

                //var loadedStudents = DataHandler.LoadStudents();
                //var loadedClassrooms = DataHandler.LoadClassrooms();

            }
            catch (Exception ex)
            {
                Color.WriteLine(ex.Message, ConsoleColor.Red);
            }
        }
        public static Classroom CreateClassroom()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter classroom name (2 uppercase letters and 3 digits):");
                    var name = Console.ReadLine();
                    if (!Extensions.CheckClassroomName(name))
                    {
                        Console.WriteLine("Invalid classroom name. Please try again.");
                        continue;
                    }

                    Console.WriteLine("Enter classroom type (0 - Backend, 1 - Frontend):");
                    var input = Console.ReadLine();
                    if (!int.TryParse(input, out int typeValue) || !Enum.IsDefined(typeof(ClassroomType), typeValue))
                    {
                        Console.WriteLine("Invalid classroom type. Please enter 0 for Backend or 1 for Frontend.");
                        continue;
                    }

                    var type = (ClassroomType)typeValue;
                    var classroom = new Classroom(name, type);
                    classrooms.Add(classroom);
                    Console.WriteLine($"Created {type} classroom named '{name}' with ID {classroom.Id}.");

                    return classroom;
                }
                catch (Exception ex)
                {
                    Color.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                }
            }
        }



        static void GetAllStudents()
        {
            try
            {
                foreach (var classroom in classrooms)
                {
                    Console.WriteLine($"Classroom: {classroom.Name}");
                    foreach (var student in classroom.Students)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name.Trim()}, Surname: {student.Surname.Trim()}, Classroom type: {student.ClassroomType}");
                    }
                }
            }
            catch (Exception ex)
            {
                Color.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
            }
        }
        public static Student CreateStudent()
        {
            while (true)
            {
                try
                {
                    if (classrooms.Count == 0)
                    {
                        throw new ClassroomNotFoundException("No classrooms available.");
                    }

                    Console.WriteLine("Enter student name:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Enter student surname:");
                    var surname = Console.ReadLine();

                    if (!name.CheckName() || !surname.CheckName())
                    {
                        Console.WriteLine("Invalid name or surname. Please try again.");
                        continue;
                    }

                    Console.WriteLine("Enter classroom ID:");
                    if (!int.TryParse(Console.ReadLine(), out int classId))
                    {
                        Console.WriteLine("Invalid classroom ID. Please try again.");
                        continue;
                    }

                    var classroom = classrooms.FirstOrDefault(c => c.Id == classId);
                    if (classroom == null)
                    {
                        throw new ClassroomNotFoundException("Classroom not found.");
                    }

                    var student = new Student(name, surname, classId, classroom.Type);
                    classroom.AddStudent(student);
                    Console.WriteLine("Student created.");
                    return student;
                }
                catch (ClassroomNotFoundException ex)
                {
                    Color.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                    return null;
                }
                catch (Exception ex)
                {
                    Color.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                }
            }
        }


        static void GetStudentsByClassroom()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter classroom ID:");
                    if (!int.TryParse(Console.ReadLine(), out int classId))
                    {
                        Console.WriteLine("Invalid classroom ID. Please try again.");
                        continue;
                    }

                    var classroom = classrooms.FirstOrDefault(c => c.Id == classId);
                    if (classroom == null)
                    {
                        throw new ClassroomNotFoundException("Classroom not found.");
                    }

                    Console.WriteLine($"Classroom: {classroom.Name}");
                    foreach (var student in classroom.Students)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname}");
                    }
                    break;
                }
                catch (ClassroomNotFoundException ex)
                {
                    Color.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                    break;
                }
                catch (Exception ex)
                {
                    Color.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                }
            }
        }
        static void RemoveStudent()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter classroom ID:");
                    if (!int.TryParse(Console.ReadLine(), out int classId))
                    {
                        Console.WriteLine("Invalid classroom ID. Please try again.");
                        continue;
                    }

                    var classroom = classrooms.FirstOrDefault(c => c.Id == classId);
                    if (classroom == null)
                    {
                        throw new ClassroomNotFoundException("Classroom not found.");
                    }

                    Console.WriteLine("Enter student ID:");
                    if (!int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        Console.WriteLine("Invalid student ID. Please try again.");
                        continue;
                    }

                    classroom.RemoveStudent(studentId);
                    Console.WriteLine($"Student with Id {studentId} removed.");
                    break;
                }
                catch (ClassroomNotFoundException ex)
                {
                    Color.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                    break;
                }
                catch (StudentNotFoundException ex)
                {
                    Color.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    Color.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                }
            }
        }
    }
}
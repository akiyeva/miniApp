//using System;
//using System.Collections.Generic;
//using System.IO;
//using miniApp.Models;
//using Newtonsoft.Json;

//public static class DataHandler
//{
//    private static string studentsFilePath = "students.json";
//    private static string classroomsFilePath = "classrooms.json";

   
//    public static void SaveStudents(List<Student> students)
//    {
//        try
//        {
//            using (StreamWriter sw = new StreamWriter(studentsFilePath))
//            {
//                string json = JsonConvert.SerializeObject(students, Formatting.Indented);
//                sw.WriteLine(json);
//            }
//            Console.WriteLine("Students data saved successfully.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error saving students data: {ex.Message}");
//        }
//    }

//    public static void SaveClassrooms(List<Classroom> classrooms)
//    {
//        try
//        {
//            using (StreamWriter sw = new StreamWriter(classroomsFilePath))
//            {
//                string json = JsonConvert.SerializeObject(classrooms, Formatting.Indented);
//                sw.WriteLine(json);
//            }
//            Console.WriteLine("Classrooms data saved successfully.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error saving classrooms data: {ex.Message}");
//        }
//    }
  
//    public static List<Student> LoadStudents()
//    {
//        try
//        {
//            if (!File.Exists(studentsFilePath))
//            {
//                return new List<Student>(); 
//            }

//            using (StreamReader sr = new StreamReader(studentsFilePath))
//            {
//                string json = sr.ReadToEnd();
//                return JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error loading students data: {ex.Message}");
//            return new List<Student>();
//        }
//    }

//    // Load classrooms data from JSON file
//    public static List<Classroom> LoadClassrooms()
//    {
//        try
//        {
//            if (!File.Exists(classroomsFilePath))
//            {
//                return new List<Classroom>(); 
//            }

//            using (StreamReader sr = new StreamReader(classroomsFilePath))
//            {
//                string json = sr.ReadToEnd();
//                return JsonConvert.DeserializeObject<List<Classroom>>(json) ?? new List<Classroom>();
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error loading classrooms data: {ex.Message}");
//            return new List<Classroom>();
//        }
//    }
//}

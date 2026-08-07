using System;
using System.Collections.Generic;
using System.Linq;
class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public int Marks { get; set; }
}
public class studentGradeManager
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Ravi", Department = "CSE", Marks = 85 },
            new Student { Id = 2, Name = "Sita", Department = "ECE", Marks = 72 },
            new Student { Id = 3, Name = "Arun", Department = "CSE", Marks = 91 },
            new Student { Id = 4, Name = "Priya", Department = "EEE", Marks = 65 },
            new Student { Id = 5, Name = "Kiran", Department = "CSE", Marks = 78 },
            new Student { Id = 6, Name = "Anu", Department = "ECE", Marks = 88 }
        };
        var res=students.Where(s=>s.Marks>80);
        Console.WriteLine("Students who scored above 80:");
        foreach (var student in res)
        {
            Console.WriteLine($"{student.Name} - {student.Marks}");
        }
        var sortedStudents = students.OrderBy(s=>s.Marks);
        Console.WriteLine("\nStudents sorted by marks:");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.Name} - {student.Marks}");
        }

        var descendingStudnets = students.OrderByDescending(s=>s.Marks);
        Console.WriteLine("\nStudents sorted by marks in descending order:");
        foreach (var student in descendingStudnets)
        {
            Console.WriteLine($"{student.Name} - {student.Marks}");
        }
        var CSEstudnets= students.Where(s=>s.Department=="CSE");
        Console.WriteLine("\nStudents from CSE department:");
        foreach (var student in CSEstudnets)
        {
            Console.WriteLine($"{student.Name} - {student.Marks}");
        }
        var HighestScorestudent=students.OrderByDescending(s=>s.Marks).First();
        Console.WriteLine($"\nStudent with the highest score: {HighestScorestudent.Name} - {HighestScorestudent.Marks}");
        var AverageMarks=students.Average(s=>s.Marks);
        Console.WriteLine($"\nAverage marks of all students: {AverageMarks}");
        var csestudentscount=students.Count(s=>s.Department=="CSE");
        Console.WriteLine($"\nNumber of students in CSE department: {csestudentscount}");
        var groupedByDepartment=students.GroupBy(s=>s.Department);
        Console.WriteLine("\nStudents grouped by department:");
        foreach (var group in groupedByDepartment)
        {
            Console.WriteLine($"\nDepartment: {group.Key}");
            foreach (var student in group)
            {
                Console.WriteLine($"{student.Name} - {student.Marks}");
            }
        }
        var passedStudents=students.Where(s=>s.Marks>=40);
        Console.WriteLine("\nStudents who passed (marks >= 40):");
        foreach (var student in passedStudents)
        {
            Console.WriteLine($"{student.Name} - {student.Marks}");
        }
        Dictionary<string, string> studentGrades= new Dictionary<string, string>();
        var grades = students.Select(s =>
        {
            string grade;
            if(s.Marks >= 90)
            {
                grade ="A";
            }
            else if(s.Marks >= 80)
            {
                grade="B";
            }
            else if(s.Marks >= 70)
            {
                grade="C";
            }
            else if(s.Marks >= 60)
            {
                grade="D";
            }
            else
            {
                grade="F";
            }
            studentGrades[s.Name] = grade;
            return grade;
        });
        foreach (var grade in grades)
        {
             // This loop is just to trigger the Select and populate the dictionary
        }

        Console.WriteLine("\nStudent Grades:");
        foreach (var kvp in studentGrades)
        {
            Console.WriteLine($"Student Name: {kvp.Key}, Grade: {kvp.Value}");
        }
        HashSet<string> departments = new HashSet<string>(
            students.Select(s => s.Department)
        );
        Console.WriteLine("\nUnique departments:");
        foreach (var department in departments)
        {
            Console.WriteLine(department);
        }
        var name=students.Select(s=>s.Name);
        Console.WriteLine("\nStudent Names:");
        foreach(var n in name)
        {
            Console.WriteLine(n);
        }
    }
}
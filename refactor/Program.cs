public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public int Marks { get; set; }
}

public interface IStudentService
{
    IEnumerable<Student> GetStudentsAbove80();
    IEnumerable<Student> GetStudentsSortedByMarks();
    IEnumerable<Student> GetStudentsSortedByMarksDescending();
    IEnumerable<Student> GetCSEStudents();
    Student GetHighestScoreStudent();
    double GetAverageMarks();
    int GetCSEStudentCount();
    IEnumerable<IGrouping<string, Student>> GetStudentsGroupedByDepartment();
    IEnumerable<Student> GetPassedStudents();
    Dictionary<string, string> GetStudentGrades();
    IEnumerable<string> GetUniqueDepartments();
    IEnumerable<string> GetStudentNames();
}




public class StudentService : IStudentService
{
    private readonly List<Student> students;

    public StudentService(List<Student> students)
    {
        this.students = students;
    }

    public IEnumerable<Student> GetStudentsAbove80()
    {
        return students.Where(s => s.Marks > 80);
    }

    public IEnumerable<Student> GetStudentsSortedByMarks()
    {
        return students.OrderBy(s => s.Marks);
    }

    public IEnumerable<Student> GetStudentsSortedByMarksDescending()
    {
        return students.OrderByDescending(s => s.Marks);
    }

    public IEnumerable<Student> GetCSEStudents()
    {
        return students.Where(s => s.Department == "CSE");
    }

    public Student GetHighestScoreStudent()
    {
        return students.OrderByDescending(s => s.Marks).First();
    }

    public double GetAverageMarks()
    {
        return students.Average(s => s.Marks);
    }

    public int GetCSEStudentCount()
    {
        return students.Count(s => s.Department == "CSE");
    }

    public IEnumerable<IGrouping<string, Student>> GetStudentsGroupedByDepartment()
    {
        return students.GroupBy(s => s.Department);
    }

    public IEnumerable<Student> GetPassedStudents()
    {
        return students.Where(s => s.Marks >= 40);
    }

    public Dictionary<string, string> GetStudentGrades()
    {
        Dictionary<string, string> studentGrades = new();

        foreach (var student in students)
        {
            string grade;

            if (student.Marks >= 90)
                grade = "A";
            else if (student.Marks >= 80)
                grade = "B";
            else if (student.Marks >= 70)
                grade = "C";
            else if (student.Marks >= 60)
                grade = "D";
            else
                grade = "F";

            studentGrades[student.Name] = grade;
        }

        return studentGrades;
    }

    public IEnumerable<string> GetUniqueDepartments()
    {
        return students
            .Select(s => s.Department)
            .Distinct();
    }

    public IEnumerable<string> GetStudentNames()
    {
        return students.Select(s => s.Name);
    }
}


public class StudentDisplay
{
    public void DisplayStudents(string title, IEnumerable<Student> students)
    {
        Console.WriteLine($"\n{title}");

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name} - {student.Marks}");
        }
    }

    public void DisplayStudent(string title, Student student)
    {
        Console.WriteLine(
            $"\n{title}: {student.Name} - {student.Marks}"
        );
    }

    public void DisplayValue(string title, object value)
    {
        Console.WriteLine($"\n{title}: {value}");
    }
}


class Program
{
    static void Main()
    {
        List<Student> students = new()
        {
            new Student { Id = 1, Name = "Ravi", Department = "CSE", Marks = 85 },
            new Student { Id = 2, Name = "Sita", Department = "ECE", Marks = 72 },
            new Student { Id = 3, Name = "Arun", Department = "CSE", Marks = 91 },
            new Student { Id = 4, Name = "Priya", Department = "EEE", Marks = 65 },
            new Student { Id = 5, Name = "Kiran", Department = "CSE", Marks = 78 },
            new Student { Id = 6, Name = "Anu", Department = "ECE", Marks = 88 }
        };

        IStudentService service = new StudentService(students);
        StudentDisplay display = new StudentDisplay();

        display.DisplayStudents(
            "Students who scored above 80:",
            service.GetStudentsAbove80()
        );

        display.DisplayStudents(
            "Students sorted by marks:",
            service.GetStudentsSortedByMarks()
        );

        display.DisplayStudents(
            "Students sorted by marks in descending order:",
            service.GetStudentsSortedByMarksDescending()
        );

        display.DisplayStudents(
            "Students from CSE department:",
            service.GetCSEStudents()
        );

        display.DisplayStudent(
            "Student with the highest score",
            service.GetHighestScoreStudent()
        );

        display.DisplayValue(
            "Average marks of all students",
            service.GetAverageMarks()
        );

        display.DisplayValue(
            "Number of students in CSE department",
            service.GetCSEStudentCount()
        );

        display.DisplayStudents(
            "Students who passed:",
            service.GetPassedStudents()
        );

        Console.WriteLine("\nStudent Grades:");

        foreach (var grade in service.GetStudentGrades())
        {
            Console.WriteLine(
                $"Student Name: {grade.Key}, Grade: {grade.Value}"
            );
        }

        Console.WriteLine("\nUnique departments:");

        foreach (var department in service.GetUniqueDepartments())
        {
            Console.WriteLine(department);
        }

        Console.WriteLine("\nStudent Names:");

        foreach (var name in service.GetStudentNames())
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nStudents grouped by department:");

        foreach (var group in service.GetStudentsGroupedByDepartment())
        {
            Console.WriteLine($"\nDepartment: {group.Key}");

            foreach (var student in group)
            {
                Console.WriteLine($"{student.Name} - {student.Marks}");
            }
        }
    }
}
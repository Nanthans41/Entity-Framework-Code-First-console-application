using System;
using System.Data.Entity;

namespace CodeFirstConsoleApplication
{
    internal static class Program
    {
        private static void Main()
        {
            using (var context = new SchoolContext())
            {
                var student = new Student { StudentName = "Bill" };
                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine($"Created the database (if needed) and saved student {student.StudentName} with ID {student.StudentID}.");
            }
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public byte[]? Photo { get; set; }       // made nullable to satisfy CS8618
        public decimal Height { get; set; }
        public float Weight { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=SchoolContext")
        {
        }

        // Satisfy the nullable reference analyzer: DbContext will initialize this at runtime.
        public DbSet<Student> Students { get; set; } = null!;
    }
}

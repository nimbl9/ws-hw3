using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> students = new()
        {
            new Student { Id = 1, Name = "Аян", Group = "CS-23-1" },
            new Student { Id = 2, Name = "Данияр", Group = "CS-23-2" },
            new Student { Id = 3, Name = "Аружан", Group = "CS-23-1" }
        };

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public Student? GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
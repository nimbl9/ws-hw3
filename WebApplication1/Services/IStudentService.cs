using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student? GetById(int id);
    }
}
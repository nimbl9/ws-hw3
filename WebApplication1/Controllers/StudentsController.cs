using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly ILogger<StudentsController> logger;

        public StudentsController(
            IStudentService studentService,
            ILogger<StudentsController> logger)
        {
            this.studentService = studentService;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            logger.LogInformation("Получен запрос на получение списка студентов");

            try
            {
                return Ok(studentService.GetAll());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Произошла ошибка при получении списка студентов");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            logger.LogInformation("Получен запрос на поиск студента с ID {StudentId}", id);

            try
            {
                var student = studentService.GetById(id);

                if (student == null)
                {
                    logger.LogWarning("Студент с ID {StudentId} не найден", id);
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "Произошла ошибка при получении студента с ID {StudentId}",
                    id);

                return StatusCode(500);
            }
        }
    }
}
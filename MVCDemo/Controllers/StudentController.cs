using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using Newtonsoft.Json;

namespace MVCDemo.Controllers
{
    public class StudentController : Controller
    {
       
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        List<Student> Students = new List<Student>()
        {
            new Student(1,"Shehan", "Male", 38),
            new Student(2,"Marika", "Female", 20),
            new Student(3,"Nadeeka", "Female", 28),
            new Student(4,"Kadri", "Male", 34),
            new Student(5,"Igor", "Male", 18),
            new Student(6,"Asa", "Female", 22),
            new Student(7,"Shrddha", "Female", 20),
            new Student(8,"Mehreen", "Female", 20),
            new Student(9,"Haitham", "Male", 20)

        };
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("sList") != null)
            {
                List<Student> StudentList = JsonConvert.DeserializeObject<List<Student>>(HttpContext.Session.GetString("sList"));
                return View(StudentList);
            }
            else
            {
                return View(Students);
            }
        }

        public IActionResult StudentList()
        { 
            var studentList = Students.OrderBy(s => s.Name).ToList();
            return View(studentList);
        }

        public IActionResult Greet()
        {
            return View();
        }

        public IActionResult DisplayStudent()
        {
            return View(Students);
        }

        public IActionResult Details(int id)
        {
            var student = Students.FirstOrDefault(s=>s.SId == id);
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (HttpContext.Session.GetString("sList") != null)
            {
                List<Student> StudentList = JsonConvert.DeserializeObject<List<Student>>(HttpContext.Session.GetString("sList"));

                var s = StudentList.LastOrDefault();
                student.SId = s.SId + 1;
                StudentList.Add(student);
                HttpContext.Session.SetString("sList", JsonConvert.SerializeObject(StudentList));
            }
            else
            {
                var s = Students.LastOrDefault();
                student.SId = s.SId + 1;
                Students.Add(student);
                HttpContext.Session.SetString("sList", JsonConvert.SerializeObject(Students));
            }
           
            

           
            return RedirectToAction("Index");
        }

    }
}

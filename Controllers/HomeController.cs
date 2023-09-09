using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebApplication1.models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private IEmployeerepository _employeerepository;

        
        public HomeController(IEmployeerepository employeerepository)
        {
            _employeerepository = employeerepository;
        }
        [Route("Index/{id?}")]
        public ViewResult Index(int id=1)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.employee=_employeerepository.GetEmployee(id);
            model.title = "Index page";


            return View(model);
        }
        [Route("")]
        [Route("Details")]
        public ViewResult GetEmployeeData()
        {
            var model = _employeerepository.GetAll();
            return View(model);
        }
        [HttpGet]
        [Route("Create")]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid) {
                Employee newemp = _employeerepository.add(emp);
                return RedirectToAction("Details");
            }
            return View();
            
        }
    }
}

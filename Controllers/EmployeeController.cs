using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
        
        [HttpPost]
        public JsonResult Create(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return Json(new { success = true, message = "Employee created successfully!" });
            }

            
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage);
            return Json(new { success = false, message = "Validation Failed", errors });    
        }

        
        [HttpGet]
        [Route("Employee/EmployeeById/{id}")]
        public JsonResult EmployeeById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(c => c.Id == id);
            if (employee == null)
            {
                return Json(new { success = false, message = "Employee not found" });
            }
            return Json(employee);
        }

        [HttpPut]
        public JsonResult Edit(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true, message = "Employee updated successfully!" });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, message = "Validation Failed", errors });
        }


        [HttpDelete]
        [Route("Employee/Delete/{id}")]
        public JsonResult Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault( e => e.Id == id);
            if (employee == null)
            {
                return Json(new { success = false, message = "Employee not found." });
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Json(new { success = true, message = "Employee deleted successfully!" });
        }
    }
}

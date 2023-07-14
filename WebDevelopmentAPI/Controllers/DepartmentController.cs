using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDevelopmentAPI.Model;
using WebDevelopmentAPI.Repository;

namespace WebDevelopmentAPI.Controllers
{
    [Route("api/v1/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IDepartmentRepository departmentRepository, ILogger<DepartmentController> logger)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult AllDepartment()
        {
            return Ok(_departmentRepository.GetAllDepartments());
        }
        [HttpGet("{id}")]
        public IActionResult GetDepartmentbyId(int? id)
        {
            var emp = _departmentRepository.GetSingleDepartment(id);
            if (emp == null)
            {
                return StatusCode(404, "Sorry,record not found!!");
            }
            return Ok(emp);
        }
        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {   
                return Ok(_departmentRepository.AddDepartment(department));
            }
            return BadRequest("Model State is not valid");
        }
        [HttpPut]
        public IActionResult UpdateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                return Ok(_departmentRepository.UpdateDepartment(department));
            }
            return BadRequest("sorry!record not found.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            return Ok(_departmentRepository.DeleteDepartment(id));
        }
    }
}

using DemoPractical.Validation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDevelopmentAPI.Model;
using WebDevelopmentAPI.Repository;

namespace WebDevelopmentAPI.Controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            this._employeeRepository = employeeRepository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult AllEmployee()
        {
            _logger.LogInformation("AllEmployee action method called");
            return Ok(_employeeRepository.GetAllEmployees());
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeesbyId(int? id) 
        {
            _logger.LogInformation("GetEmployeesbyId action method called");
            var emp = _employeeRepository.GetSingleEmployee(id);
            if (emp == null)
            {
                _logger.LogError("404,Sorry,record not found!!");
                return StatusCode(404, "Sorry,record not found!!");
            }
            return Ok(emp);
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewModel employee) 
        {
            EmployeeValidator validation = new EmployeeValidator();
            ValidationResult result = validation.Validate(employee);
            _logger.LogInformation("AddEmployee action method called");
            if (result.IsValid) 
            {
                return Ok(_employeeRepository.AddEmployee(employee));
            }
            _logger.LogError("Model State is not valid from AddEmployee action method ");
            return BadRequest("Model State is not valid");
        }
        [HttpPut]
        public  IActionResult UpdateEmployee(EmployeeViewModel employee) 
        {
            EmployeeValidator validation = new EmployeeValidator();
            ValidationResult result = validation.Validate(employee);
            _logger.LogInformation("UpdateEmployee action method called");
            if (result.IsValid)
            {
                return Ok(_employeeRepository.UpdateEmployee(employee));
            }
            _logger.LogError("sorry!record not found from UpdateEmployee action method ");
            return BadRequest("sorry!record not found.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id) 
        {
            _logger.LogInformation("DeleteEmployee action method called");
            return Ok(_employeeRepository.DeleteEmployee(id));      
        }
    }
}

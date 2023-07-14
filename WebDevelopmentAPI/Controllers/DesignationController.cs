using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDevelopmentAPI.Model;
using WebDevelopmentAPI.Repository;

namespace WebDevelopmentAPI.Controllers
{
    [Route("api/v1/designation")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationRepository _designationRepository;
        private readonly ILogger<DesignationController> _logger;
        public DesignationController(IDesignationRepository designationRepository, ILogger<DesignationController> logger)
        {
            _designationRepository = designationRepository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult AllDesignation()
        {
            return Ok(_designationRepository.GetAllDesignations());
        }
        [HttpGet("{id}")]
        public IActionResult GetDesignationbyId(int? id)
        {
            var emp = _designationRepository.GetSingleDesignation(id);
            if (emp == null)
            {
                return StatusCode(404, "Sorry,record not found!!");
            }
            return Ok(emp);
        }
        [HttpPost]
        public IActionResult AddDesignation(EmployeeDesignation designation)
        {
            if (ModelState.IsValid)
            {
                return Ok(_designationRepository.AddDesignation(designation));
            }
            return BadRequest("Model State is not valid");
        }
        [HttpPut]
        public IActionResult UpdateDesignation(EmployeeDesignation designation)
        {
            if (ModelState.IsValid)
            {
                return Ok(_designationRepository.UpdateDesignation(designation));
            }
            return BadRequest("sorry!record not found.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDesignation(int id)
        {
            return Ok(_designationRepository.DeleteDesignation(id));
        }
    }
}

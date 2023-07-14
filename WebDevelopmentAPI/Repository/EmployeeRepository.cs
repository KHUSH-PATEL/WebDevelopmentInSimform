using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebDevelopmentAPI.Data;
using WebDevelopmentAPI.Model;

namespace WebDevelopmentAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(ApplicationContext context,IMapper mapper, ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public IEnumerable<EmployeeViewModel> AddEmployee(EmployeeViewModel emp)
        {
            Employee employee = _mapper.Map<EmployeeViewModel,Employee>(emp);

            if (employee != null)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                _logger.LogInformation("Employee added in database");
            }

            return GetAllEmployees();
        }
        public EmployeeViewModel DeleteEmployee(int? id)
        {
            var emp = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
                _logger.LogInformation("Employee deleted in database");
            }
            return _mapper.Map<Employee, EmployeeViewModel>(emp);
        }
        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            var employees = _context.Employees.Include(x => x.Department).Include(x => x.EmployeeDesignation).ToList();
            var employeeViewModels = _mapper.Map<List<Employee>, List<EmployeeViewModel>>(employees);
            return employeeViewModels;
        }
        public EmployeeViewModel GetSingleEmployee(int? id)
        {
            var emp = _context.Employees.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<Employee, EmployeeViewModel>(emp);
        }
        public EmployeeViewModel UpdateEmployee(EmployeeViewModel employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);

            if (existingEmployee != null)
            {
                _mapper.Map(employee, existingEmployee);
                _context.SaveChanges();
                _logger.LogInformation("Employee updated in database");
            }
            return _mapper.Map<Employee, EmployeeViewModel>(existingEmployee); 
        }

    }
}

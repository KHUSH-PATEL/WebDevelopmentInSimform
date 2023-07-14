using WebDevelopmentAPI.Model;

namespace WebDevelopmentAPI.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeViewModel> GetAllEmployees();
        EmployeeViewModel GetSingleEmployee(int? id);
        IEnumerable<EmployeeViewModel> AddEmployee(EmployeeViewModel request);
        EmployeeViewModel UpdateEmployee(EmployeeViewModel employee);
        EmployeeViewModel DeleteEmployee(int? id);
    }
}

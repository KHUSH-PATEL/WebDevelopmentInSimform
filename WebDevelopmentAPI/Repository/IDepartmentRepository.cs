using WebDevelopmentAPI.Model;

namespace WebDevelopmentAPI.Repository
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetSingleDepartment(int? id);
        IEnumerable<Department> AddDepartment(Department department);
        Department UpdateDepartment(Department department);
        Department DeleteDepartment(int? id);
    }
}

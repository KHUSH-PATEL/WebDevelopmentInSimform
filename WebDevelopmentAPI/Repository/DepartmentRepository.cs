using WebDevelopmentAPI.Data;
using WebDevelopmentAPI.Model;

namespace WebDevelopmentAPI.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationContext _context;
        public DepartmentRepository(ApplicationContext context) 
        { 
            _context = context;
        }
        public IEnumerable<Department> AddDepartment(Department department)
        {
            if(department!=null) 
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            } 
            return GetAllDepartments();
        }

        public Department DeleteDepartment(int? id)
        {
           var dept= _context.Departments.FirstOrDefault(x => x.Id==id);
            if(dept!=null)
            {
                _context.Departments.Remove(dept);
                _context.SaveChanges();
            }
            return dept;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments;
        }

        public Department GetSingleDepartment(int? id)
        {
            var dept =_context.Departments.FirstOrDefault(x=>x.Id==id);
            return dept;
        }

        public Department UpdateDepartment(Department department)
        {
           var dept= _context.Departments.FirstOrDefault(x=>x.Id== department.Id);
            if(dept!=null)
            {
                dept.DepartmentName = department.DepartmentName;
                _context.Departments.Update(dept);
                _context.SaveChanges();
            }
            return dept;
        }
    }
}

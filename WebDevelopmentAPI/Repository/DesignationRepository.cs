using WebDevelopmentAPI.Data;
using WebDevelopmentAPI.Model;

namespace WebDevelopmentAPI.Repository
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly ApplicationContext _context;
        public DesignationRepository(ApplicationContext context) 
        {   
              _context = context;
        }
        public IEnumerable<EmployeeDesignation> AddDesignation(EmployeeDesignation designation)
        {
            if(designation != null) 
            {
                _context.EmployeesDesignations.Add(designation);
                _context.SaveChanges();
            }
            return GetAllDesignations();
        }

        public EmployeeDesignation DeleteDesignation(int? id)
        {
            var desgn= _context.EmployeesDesignations.FirstOrDefault(x => x.Id == id);
            if(desgn != null) 
            {
                _context.EmployeesDesignations.Remove(desgn);
                _context.SaveChanges();
            }
            return desgn;
        }

        public IEnumerable<EmployeeDesignation> GetAllDesignations()
        {
            return _context.EmployeesDesignations;
        }

        public EmployeeDesignation GetSingleDesignation(int? id)
        {
            var desgn = _context.EmployeesDesignations.FirstOrDefault(x => x.Id == id);
            return desgn;
        }

        public EmployeeDesignation UpdateDesignation(EmployeeDesignation designation)
        {
            var desgn = _context.EmployeesDesignations.FirstOrDefault(x => x.Id == designation.Id);
            if(desgn != null) 
            {
                desgn.Designation = designation.Designation;
                _context.EmployeesDesignations.Update(desgn);
                _context.SaveChanges();
            }
            return desgn;
        }
    }
}

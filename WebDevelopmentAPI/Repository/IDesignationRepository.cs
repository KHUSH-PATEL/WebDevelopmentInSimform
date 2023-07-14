using WebDevelopmentAPI.Model;

namespace WebDevelopmentAPI.Repository
{
    public interface IDesignationRepository
    {
        IEnumerable<EmployeeDesignation> GetAllDesignations();
        EmployeeDesignation GetSingleDesignation(int? id);
        IEnumerable<EmployeeDesignation> AddDesignation(EmployeeDesignation designation);
        EmployeeDesignation UpdateDesignation(EmployeeDesignation designation);
        EmployeeDesignation DeleteDesignation(int? id);
    }
}

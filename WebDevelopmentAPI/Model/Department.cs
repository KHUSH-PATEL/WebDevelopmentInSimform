using System.ComponentModel.DataAnnotations;

namespace WebDevelopmentAPI.Model
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}

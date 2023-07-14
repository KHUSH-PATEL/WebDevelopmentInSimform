using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebDevelopmentAPI.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Required]
        [MaxLength(10)]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        public Decimal Salary { get; set; }
        
        [Required,Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required,Display(Name = "Designation")]
        public int EmployeeDesignationId { get; set; }
        [ForeignKey("EmployeeDesignationId")]
        public EmployeeDesignation EmployeeDesignation { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}

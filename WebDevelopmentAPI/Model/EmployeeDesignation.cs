using System.ComponentModel.DataAnnotations;

namespace WebDevelopmentAPI.Model
{
    public class EmployeeDesignation
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Designation { get; set; }
    }
} 

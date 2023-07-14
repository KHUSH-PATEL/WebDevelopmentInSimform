using FluentValidation;
using WebDevelopmentAPI.Model;

namespace DemoPractical.Validation
{
    public class EmployeeValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("First Name is required.").MaximumLength(50).WithMessage("First Name should be 50 character only");
            RuleFor(c => c.MiddleName).MaximumLength(50).WithMessage("Middle name must not exceed 50 characters.");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Last Name is required.").MaximumLength(50).WithMessage("Last Name should be 50 character only");
            RuleFor(c => c.DOB).NotEmpty().WithMessage("Date of birth is required.");
            RuleFor(c => c.Mobile).NotEmpty().WithMessage("Mobile number is required.").MaximumLength(10).WithMessage("Mobile Number should be 10 character only");
            RuleFor(c => c.Address).MaximumLength(100).WithMessage("Address must not exceed 100 characters.");
            RuleFor(c => c.Salary).NotEmpty().WithMessage("Salary is required.");
            RuleFor(c => c.DepartmentId).NotEmpty().WithMessage("Department is required.");
            RuleFor(c => c.EmployeeDesignationId).NotEmpty().WithMessage("Employee designation is required.");
        }
    }

}

using FluentValidation;
using Labs.Domain.Comand;

namespace Labs.Domain.Validations
{
    public class AddNewMarkComandValidation : AbstractValidator<AddNewMarkComand>
    {
        public AddNewMarkComandValidation()
        {
            Validation();
        }

        protected void Validation()
        {
            RuleFor(x=>x.EmployeId).NotEmpty();
            RuleFor(x=>x.EmployerId).NotEmpty();
            RuleFor(x=>x.IncludedAt).LessThan(DateTime.Now);
        }
    }
}

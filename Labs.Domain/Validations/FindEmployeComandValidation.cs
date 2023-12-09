using FluentValidation;
using Labs.Domain.Comand;

namespace Labs.Domain.Validations
{
    public class FindEmployeComandValidation : AbstractValidator<FindAllMarkEmployeComand>
    {
        public FindEmployeComandValidation()
        {
            Validate();
        }

        protected void Validate()
        {
            RuleFor(x=>x.EmployeId).NotEmpty();
        }
    }
}

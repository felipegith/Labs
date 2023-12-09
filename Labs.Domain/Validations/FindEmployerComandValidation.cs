using FluentValidation;
using Labs.Domain.Comand;

namespace Labs.Domain.Validations
{
    public class FindEmployerComandValidation : AbstractValidator<FindAllMarkEmployerComand>
    {
        public FindEmployerComandValidation()
        {
            Validate();
        }
        protected void Validate()
        {
            RuleFor(x => x.EmployerId).NotEmpty();
        }
    }
}

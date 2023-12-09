using FluentValidation.Results;
using Labs.Domain.Comand.Utils;
using Labs.Domain.Validations;
using MediatR;

namespace Labs.Domain.Comand
{
    public class FindAllMarkEmployerComand : ModelComand, IRequest<ComandResponse>
    {
        public ValidationResult Validate()
        {
            var validationComand = new FindEmployerComandValidation().Validate(this);

            return validationComand;
        }

        public FindAllMarkEmployerComand Maping(string employerId)
        {
            EmployerId = employerId;

            return this;
        }
    }
}

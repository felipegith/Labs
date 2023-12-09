using FluentValidation.Results;
using Labs.Domain.Comand.Utils;
using Labs.Domain.Validations;
using MediatR;

namespace Labs.Domain.Comand
{
    public class FindAllMarkEmployeComand : ModelComand, IRequest<ComandResponse>
    {
        public ValidationResult Validate()
        {
            var validationComand = new FindEmployeComandValidation().Validate(this);

            return validationComand;
        }

        public FindAllMarkEmployeComand Maping(string employeId)
        {
            EmployeId = employeId;

            return this;
        }
    }
}

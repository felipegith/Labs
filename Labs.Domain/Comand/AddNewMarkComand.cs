using FluentValidation.Results;
using Labs.Domain.Comand.Utils;
using Labs.Domain.Validations;
using MediatR;

namespace Labs.Domain.Comand
{
    public class AddNewMarkComand : ModelComand, IRequest<ComandResponse>

    {
        public ValidationResult Validate()
        {
            var validationComand = new AddNewMarkComandValidation().Validate(this);

            return validationComand;
        }

        public AddNewMarkComand Maping(string employeId, string employerId, DateTime includedAt)
        {
            EmployeId = employeId;
            EmployerId = employerId;
            IncludedAt = includedAt;

            return this;
        }
    }
}

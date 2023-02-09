namespace Services.Validators.CommandValidators
{
    using System;
    using Domain.Dtos;
    using Domain.Entities;
    using FluentValidation;
    using Services.Validators.Shared;

    public class RegisterInsuranceCommandValidator : AbstractValidator<RegisterInsuranceCommand>
    {
        public RegisterInsuranceCommandValidator(ICommonValidators commonValidators)
        {
            RuleFor(Insurance => Insurance.InsuranceNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(insuranceId => !commonValidators.IsExistingEntityRowAsync<Insurance>(u => u.InsuranceNumber == insuranceId))
                .WithMessage("You cannot add 2 people with the same insurance id");

            RuleFor(Insurance => Insurance.PlanName).NotEmpty();
            RuleFor(Insurance => Insurance.Name).NotEmpty();
            RuleFor(Insurance => Insurance.IsInspected).NotEmpty();
            RuleFor(Insurance => Insurance.Address).NotEmpty();
            RuleFor(Insurance => Insurance.BirthDay).NotEmpty().GreaterThanOrEqualTo(x => DateTime.Now);
            RuleFor(Insurance => Insurance.City).NotEmpty();
            RuleFor(Insurance => Insurance.ClientId).NotEmpty();
            RuleFor(Insurance => Insurance.Coverage).NotEmpty();
            RuleFor(Insurance => Insurance.MaxValueCovered).NotEmpty();
            RuleFor(Insurance => Insurance.PlateId).NotEmpty();
            RuleFor(Insurance => Insurance.Model).NotEmpty();

            RuleFor(Insurance => Insurance.EndDate).NotEmpty().GreaterThanOrEqualTo(x => x.StartDate).GreaterThanOrEqualTo(x => DateTime.Now);
            RuleFor(Insurance => Insurance.StartDate).NotEmpty().LessThanOrEqualTo(x => x.EndDate).LessThanOrEqualTo(x => DateTime.Now);
        }
    }
}

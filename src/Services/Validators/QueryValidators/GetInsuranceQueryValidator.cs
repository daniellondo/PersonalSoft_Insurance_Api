namespace Services.Validators.QueryValidators
{
    using Domain.Dtos;
    using FluentValidation;

    public class GetInsuranceQueryValidator : AbstractValidator<GetInsuranceQuery>
    {
        public GetInsuranceQueryValidator()
        {
            RuleFor(payload => payload.InsuranceNumber)
                .NotEmpty()
                .When(payload => payload.PlateId == null);

            RuleFor(payload => payload.PlateId)
                .NotEmpty()
                .When(payload => payload.InsuranceNumber == null);
        }
    }
}

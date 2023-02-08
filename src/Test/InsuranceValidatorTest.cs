namespace Tests
{
    using AutoFixture;
    using Domain.Dtos;
    using Domain.Entities;
    using FluentValidation.TestHelper;
    using NSubstitute;
    using Services.Validators.CommandValidators;
    using Services.Validators.QueryValidators;
    using Services.Validators.Shared;
    using Test;
    using Xunit;

    public class InsuranceValidatorTest
    {
        public static readonly Fixture _fixture = new();
        private readonly RegisterInsuranceCommandValidator _registerInsuranceCommandValidator;
        private readonly GetInsuranceQueryValidator _getInsuranceQueryValidator;
        private readonly ICommonValidators _commonValidator;
        private RegisterInsuranceCommand _request;
        public InsuranceValidatorTest()
        {
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _commonValidator = Substitute.For<ICommonValidators>();
            _registerInsuranceCommandValidator = new RegisterInsuranceCommandValidator(_commonValidator);
            _getInsuranceQueryValidator = new GetInsuranceQueryValidator();
            createRequest();
        }

        [Fact]
        public async Task RegisterInsuranceCommandValidator_When_request_is_correct()
        {
            // Arrange

            // Act
            var result = await _registerInsuranceCommandValidator.TestValidateAsync(_request);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task RegisterInsuranceCommandValidator_When_request_dates_incorrect()
        {
            // Arrange
            _request.StartDate = DateTime.Now;
            _request.EndDate = DateTime.Now.AddDays(-10);

            // Act
            var result = await _registerInsuranceCommandValidator.TestValidateAsync(_request);

            // Assert
            result.ShouldHaveValidationErrorFor(r => r.EndDate);
        }

        [Fact]
        public async Task GetInsuranceQueryValidator_When_request_is_empty()
        {
            // Arrange

            // Act
            var result = await _getInsuranceQueryValidator.TestValidateAsync(new GetInsuranceQuery());

            // Assert
            result.ShouldHaveValidationErrorFor(r => r.InsuranceNumber);
            result.ShouldHaveValidationErrorFor(r => r.PlateId);
        }

        private void createRequest()
        {
            var fixture = _fixture.Build<Insurance>().Create();

            _request = new RegisterInsuranceCommand
            {
                InsuranceNumber = fixture.InsuranceNumber,
                Address = fixture.Vehicle.Client.Address,
                BirthDay = DateTime.Now.AddYears(20),
                City = fixture.Vehicle.Client.City,
                ClientId = fixture.Vehicle.Client.ClientId,
                Name = fixture.Vehicle.Client.Name,
                Model = fixture.Vehicle.Model,
                PlateId = fixture.Vehicle.PlateId,
                Coverage = fixture.Coverage,
                IsInspected = true,
                MaxValueCovered = fixture.MaxValueCovered,
                PlanName = fixture.PlanName,
                EndDate = DateTime.Now.AddDays(10),
                StartDate = DateTime.Now
            };
        }
    }
}

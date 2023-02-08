namespace Services.MapperConfiguration
{
    using AutoMapper;
    using Domain.Dtos;
    using Domain.Entities;

    public class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            CreateMap<RegisterInsuranceCommand, Client>(MemberList.Source)
                    .ForSourceMember(x => x.MaxValueCovered, s => s.DoNotValidate())
                    .ForSourceMember(x => x.InsuranceNumber, s => s.DoNotValidate())
                    .ForSourceMember(x => x.EndDate, s => s.DoNotValidate())
                    .ForSourceMember(x => x.StartDate, s => s.DoNotValidate())
                    .ForSourceMember(x => x.Coverage, s => s.DoNotValidate())
                    .ForSourceMember(x => x.InsuranceNumber, s => s.DoNotValidate())
                    .ForSourceMember(x => x.Model, s => s.DoNotValidate())
                    .ForSourceMember(x => x.PlateId, s => s.DoNotValidate())
                    .ForSourceMember(x => x.PlanName, s => s.DoNotValidate())
                    .ForSourceMember(x => x.IsInspected, s => s.DoNotValidate());

            CreateMap<RegisterInsuranceCommand, Vehicle>(MemberList.Source)
                    .ForSourceMember(x => x.Address, s => s.DoNotValidate())
                    .ForSourceMember(x => x.BirthDay, s => s.DoNotValidate())
                    .ForSourceMember(x => x.City, s => s.DoNotValidate())
                    .ForSourceMember(x => x.ClientId, s => s.DoNotValidate())
                    .ForSourceMember(x => x.Name, s => s.DoNotValidate())
                    .ForSourceMember(x => x.MaxValueCovered, s => s.DoNotValidate())
                    .ForSourceMember(x => x.InsuranceNumber, s => s.DoNotValidate())
                    .ForSourceMember(x => x.EndDate, s => s.DoNotValidate())
                    .ForSourceMember(x => x.StartDate, s => s.DoNotValidate())
                    .ForSourceMember(x => x.Coverage, s => s.DoNotValidate())
                    .ForSourceMember(x => x.InsuranceNumber, s => s.DoNotValidate())
                    .ForSourceMember(x => x.PlanName, s => s.DoNotValidate());

            CreateMap<RegisterInsuranceCommand, Insurance>(MemberList.Source)
                .ForSourceMember(x => x.IsInspected, s => s.DoNotValidate())
                .ForSourceMember(x => x.Address, s => s.DoNotValidate())
                .ForSourceMember(x => x.BirthDay, s => s.DoNotValidate())
                .ForSourceMember(x => x.City, s => s.DoNotValidate())
                .ForSourceMember(x => x.ClientId, s => s.DoNotValidate())
                .ForSourceMember(x => x.Model, s => s.DoNotValidate())
                .ForSourceMember(x => x.PlateId, s => s.DoNotValidate())
                .ForSourceMember(x => x.Name, s => s.DoNotValidate());

            CreateMap<Insurance, InsuranceResponseDto>(MemberList.Source)
                .ForMember(x => x.Address, opt => opt.MapFrom(s => s.Vehicle.Client.Address))
                .ForMember(x => x.IsInspected, opt => opt.MapFrom(s => s.Vehicle.IsInspected))
                .ForMember(x => x.BirthDay, opt => opt.MapFrom(s => s.Vehicle.Client.BirthDay))
                .ForMember(x => x.ClientId, opt => opt.MapFrom(s => s.Vehicle.Client.ClientId))
                .ForMember(x => x.Name, opt => opt.MapFrom(s => s.Vehicle.Client.Name))
                .ForMember(x => x.City, opt => opt.MapFrom(s => s.Vehicle.Client.City))
                .ForMember(x => x.Model, opt => opt.MapFrom(s => s.Vehicle.Model))
                .ForMember(x => x.PlateId, opt => opt.MapFrom(s => s.Vehicle.PlateId))
                .ForSourceMember(x => x.ModifiedOn, s => s.DoNotValidate())
                .ForSourceMember(x => x.Id, s => s.DoNotValidate())
                .ForSourceMember(x => x.VehicleId, s => s.DoNotValidate())
                .ForSourceMember(x => x.Vehicle, s => s.DoNotValidate());

        }
    }
}

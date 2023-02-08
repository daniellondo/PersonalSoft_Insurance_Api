namespace Services.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Domain.Dtos;
    using Domain.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class RegisterInsuranceCommandHandlers
    {
        public class RegisterInsuranceCommandHandler : IRequestHandler<RegisterInsuranceCommand, BaseResponse<bool>>
        {
            private readonly IInsuranceContext _context;
            private readonly IMapper _mapper;
            public RegisterInsuranceCommandHandler(IInsuranceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BaseResponse<bool>> Handle(RegisterInsuranceCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var insurance = _mapper.Map<Insurance>(request);
                    insurance.Vehicle = _mapper.Map<Vehicle>(request);
                    insurance.Vehicle.Client = _mapper.Map<Client>(request);

                    _context.Insurances.Add(insurance);
                    await _context.SaveChangesAsync(cancellationToken);
                    return new BaseResponse<bool>("Added successfully!", true);
                }
                catch (Exception ex)
                {
                    return new BaseResponse<bool>(ex.Message + " " + ex.StackTrace, false, StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}

namespace Services.QueryHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Domain.Dtos;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetInsuranceQueryHandlers
    {
        public class GetInsuranceQueryHandler : IRequestHandler<GetInsuranceQuery, BaseResponse<InsuranceResponseDto>>
        {
            private readonly IInsuranceContext _context;
            private readonly IMapper _mapper;

            public GetInsuranceQueryHandler(IInsuranceContext databaseContext, IMapper mapper)
            {
                _context = databaseContext;
                _mapper = mapper;
            }

            public async Task<BaseResponse<InsuranceResponseDto>> Handle(GetInsuranceQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var insurance = await _context.Insurances
                                    .Include(x => x.Vehicle)
                                    .ThenInclude(x => x.Client)
                                    .ProjectTo<InsuranceResponseDto>(_mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync();

                    return new BaseResponse<InsuranceResponseDto>("", insurance);
                }
                catch (Exception ex)
                {
                    return new BaseResponse<InsuranceResponseDto>("Error getting data", null, ex);
                }

            }
        }
    }
}

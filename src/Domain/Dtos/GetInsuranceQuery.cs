namespace Domain.Dtos
{
    public class GetInsuranceQuery : QueryBase<BaseResponse<InsuranceResponseDto>>
    {
        public string? InsuranceNumber { get; set; }
        public string? PlateId { get; set; }
    }
}

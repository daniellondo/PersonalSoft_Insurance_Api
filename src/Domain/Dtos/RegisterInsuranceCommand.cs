namespace Domain.Dtos
{

    public class RegisterInsuranceCommand : CommandBase<BaseResponse<bool>>
    {
        public string InsuranceNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Coverage { get; set; }
        public decimal MaxValueCovered { get; set; }
        public string PlanName { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
        public DateTime BirthDay { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PlateId { get; set; }
        public string Model { get; set; }
        public bool IsInspected { get; set; }
    }
}

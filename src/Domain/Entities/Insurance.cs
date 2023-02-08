namespace Domain.Entities
{
    public class Insurance
    {
        public Insurance() => ModifiedOn = DateTime.Now;
        public DateTime ModifiedOn { get; set; }
        public int Id { get; set; }
        public string InsuranceNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Coverage { get; set; }
        public decimal MaxValueCovered { get; set; }
        public string PlanName { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}

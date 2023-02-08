namespace Domain.Entities
{
    using System;
    public class Vehicle
    {
        public Vehicle() => ModifiedOn = DateTime.Now;
        public DateTime ModifiedOn { get; set; }
        public int Id { get; set; }
        public string PlateId { get; set; }
        public string Model { get; set; }
        public bool IsInspected { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int InsuranceId { get; set; }
        public Insurance Insurance { get; set; }

    }
}

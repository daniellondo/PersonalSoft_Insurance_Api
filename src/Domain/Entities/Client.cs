namespace Domain.Entities
{
    public class Client
    {
        public Client() => ModifiedOn = DateTime.Now;
        public DateTime ModifiedOn { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime BirthDay { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<Vehicle> Vehicles { get; set; }

    }
}

namespace Data.EntityConfigurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClientConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(client => new { client.Id });
            builder.Property(client => client.Id).ValueGeneratedOnAdd();
            builder.HasMany(client => client.Vehicles);
        }
    }
}

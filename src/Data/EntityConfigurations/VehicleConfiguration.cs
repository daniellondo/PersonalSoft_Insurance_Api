namespace Data.EntityConfigurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(vehicle => new { vehicle.Id });
            builder.Property(vehicle => vehicle.Id).ValueGeneratedOnAdd();
            builder.HasOne(vehicle => vehicle.Client);
            builder.HasOne(vehicle => vehicle.Insurance)
                .WithOne(vehicle => vehicle.Vehicle)
                .HasForeignKey<Insurance>(b => b.VehicleId);
        }
    }
}

namespace Data.EntityConfigurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class InsuranceConfigurations : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            builder.HasKey(insurance => new { insurance.Id });
            builder.Property(insurance => insurance.Id).ValueGeneratedOnAdd();
            builder.HasOne(insurance => insurance.Vehicle)
                    .WithOne(vehicle => vehicle.Insurance)
                    .HasForeignKey<Vehicle>(b => b.InsuranceId);
        }
    }
}

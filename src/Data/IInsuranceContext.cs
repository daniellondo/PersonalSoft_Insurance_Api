namespace Data
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    public interface IInsuranceContext : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Insurance> Insurances { get; set; }

    }
}

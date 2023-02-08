
namespace Services.Validators.Shared
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class CommonValidators : ICommonValidators
    {
        private readonly IInsuranceContext _context;

        public CommonValidators(IInsuranceContext context)
        {
            _context = context;
        }

        public bool IsExistingEntityRowAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            var query = _context.Set<TEntity>();
            return query.Any(filter);
        }

        public async Task<TEntity> GetFirstOrDefaultEntityRowAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            var query = _context.Set<TEntity>();
            return await query.FirstOrDefaultAsync(filter);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}

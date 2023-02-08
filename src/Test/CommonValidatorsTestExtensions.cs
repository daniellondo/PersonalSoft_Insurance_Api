namespace Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using NSubstitute;
    using Services.Validators.Shared;

    public static class CommonValidatorsTestExtensions
    {
        public static void ConfigureTestData<TEntity>(this ICommonValidators commonValidator, List<TEntity> list) where TEntity : class
        {
            commonValidator.IsExistingEntityRowAsync(Arg.Any<Expression<Func<TEntity, bool>>>())
                .Returns(arg =>
                {
                    var predicate = arg.ArgAt<Expression<Func<TEntity, bool>>>(0).Compile();
                    return list.Any(predicate);
                });

            commonValidator.GetFirstOrDefaultEntityRowAsync(Arg.Any<Expression<Func<TEntity, bool>>>())
                .Returns(arg =>
                {
                    var predicate = arg.ArgAt<Expression<Func<TEntity, bool>>>(0).Compile();
                    return list.FirstOrDefault(predicate);
                });
        }
    }
}

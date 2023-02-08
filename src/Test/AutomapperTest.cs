namespace Test
{
    using AutoMapper;
    using Xunit;
    using Xunit.Categories;
    public class AutomapperTest
    {
        [Fact]
        [UnitTest("Automapper")]
        public void Autommaper_Assert_Configuration()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddMaps("Services");
            });

            config.AssertConfigurationIsValid();
        }
    }
}

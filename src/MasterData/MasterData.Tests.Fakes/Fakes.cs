namespace DigitalLibrary.MasterData.Tests.Fakes
{
    using Bogus;

    using DigitalLibrary.MasterData.DomainModel;

    public class Fakes
    {
        protected Faker<DomainModel.DimensionStructure> _dimensionStructureFaker;

        protected Faker<DomainModel.SourceFormat> _sourceFormatFaker;

        protected Faker<DimensionStructureNode> _dimensionStructureNodeFaker;

        public Fakes()
        {
            _dimensionStructureFaker = new Faker<DomainModel.DimensionStructure>()
               .RuleFor(prop => prop.Name, faker => faker.Company.CompanyName(1))
               .RuleFor(prop => prop.Desc, prop => $"{prop.Name} description.")
               .RuleFor(prop => prop.IsActive, faker => faker.Random.Number(1, 0));

            _sourceFormatFaker = new Faker<DomainModel.SourceFormat>()
               .RuleFor(prop => prop.Name, faker => faker.Company.CompanyName())
               .RuleFor(prop => prop.Desc, prop => $"{prop.Name} description.")
               .RuleFor(prop => prop.IsActive, faker => faker.Random.Number(1, 0));

            _dimensionStructureNodeFaker = new Faker<DimensionStructureNode>();
        }
    }
}

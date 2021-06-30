namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Bogus;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Dimension;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructureNode;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionValue;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;

    using Microsoft.EntityFrameworkCore;

    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class TestBase : IDisposable
    {
        private readonly string sqlLiteFileNameWithPath;

        protected readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        protected readonly ITestOutputHelper _testOutputHelper;

        protected Faker<DomainModel.DimensionStructure> _dimensionStructureFaker;

        protected Faker<DomainModel.SourceFormat> _sourceFormatFaker;

        protected Faker<DimensionStructureNode> _dimensionStructureNodeFaker;

        public TestBase(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            Random rnd = new Random();
            string path = Directory.GetCurrentDirectory();
            string fileName = $"sqlite_{rnd.Next(1, 10000000)}.sqlite";
            sqlLiteFileNameWithPath = $"{path}/{fileName}";
            _testOutputHelper.WriteLine($"SQLite file name: {sqlLiteFileNameWithPath}");

            DbContextOptions<MasterDataContext> _dbContextOptions = new DbContextOptionsBuilder<MasterDataContext>()
               .UseSqlite($"Data Source = {sqlLiteFileNameWithPath}")
               .LogTo(msg => Debug.WriteLine(msg))
               .EnableDetailedErrors()
               .EnableSensitiveDataLogging()
               .Options;

            DimensionValidator dimensionValidator = new ();
            MasterDataDimensionValueValidator masterDataDimensionValueValidator = new ();
            SourceFormatValidator sourceFormatValidator = new ();
            DimensionStructureValidator dimensionStructureValidator = new ();
            DimensionStructureDimensionStructureValidator dimensionStructureDimensionStructureValidator = new ();
            DimensionStructureQueryObjectValidator dimensionStructureQueryObjectValidator = new ();
            DimensionStructureNodeValidator dimensionStructureNodeValidator = new ();
            SourceFormatDimensionStructureNodeValidator sourceFormatDimensionStructureNodeValidator = new ();

            MasterDataValidators masterDataValidators = new (
                dimensionValidator,
                masterDataDimensionValueValidator,
                sourceFormatValidator,
                dimensionStructureValidator,
                dimensionStructureDimensionStructureValidator,
                dimensionStructureQueryObjectValidator,
                dimensionStructureNodeValidator,
                sourceFormatDimensionStructureNodeValidator);

            IMasterDataDimensionBusinessLogic masterDataDimensionBusinessLogic = new MasterDataDimensionBusinessLogic(
                _dbContextOptions, masterDataValidators);
            IMasterDataDimensionStructureBusinessLogic masterDataDimensionStructureBusinessLogic =
                new MasterDataDimensionStructureBusinessLogic(_dbContextOptions, masterDataValidators);
            IMasterDataDimensionValueBusinessLogic masterDataDimensionValueBusinessLogic =
                new MasterDataDimensionValueBusinessLogic(_dbContextOptions, masterDataValidators);
            IMasterDataSourceFormatBusinessLogic masterDataSourceFormatBusinessLogic =
                new MasterDataSourceFormatBusinessLogic(_dbContextOptions, masterDataValidators);
            IMasterDataDimensionStructureNodeBusinessLogic masterDataDimensionStructureNodeBusinessLogic =
                new MasterDataDimensionStructureNodeBusinessLogic(_dbContextOptions, masterDataValidators);

            _masterDataBusinessLogic = new MasterDataBusinessLogic(
                masterDataDimensionBusinessLogic,
                masterDataDimensionStructureBusinessLogic,
                masterDataDimensionValueBusinessLogic,
                masterDataSourceFormatBusinessLogic,
                masterDataDimensionStructureNodeBusinessLogic);


            using (MasterDataContext ctx = new (_dbContextOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                // MasterDataDataSample.Populate(ctx);
            }

            InitializeFakers();
        }

        private void InitializeFakers()
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

        protected async Task<List<DomainModel.DimensionStructure>> CreateInactiveDimensionStructureEntities(int amount)
        {
            List<DomainModel.DimensionStructure> result = new ();
            IEnumerable<DomainModel.DimensionStructure> dimensionStructureInfinite =
                _dimensionStructureFaker.GenerateForever();

            for (int i = 0; i < amount; i++)
            {
                DomainModel.DimensionStructure dimensionStructure = dimensionStructureInfinite.ElementAt(i);
                dimensionStructure.IsActive = 0;
                DomainModel.DimensionStructure saved = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .AddAsync(dimensionStructure)
                   .ConfigureAwait(false);
                result.Add(saved);
            }

            return result;
        }

        protected async Task<List<DomainModel.DimensionStructure>> CreateActiveDimensionStructureEntities(int amount)
        {
            List<DomainModel.DimensionStructure> result = new ();
            IEnumerable<DomainModel.DimensionStructure> dimensionStructureInfinite =
                _dimensionStructureFaker.GenerateForever();

            for (int i = 0; i < amount; i++)
            {
                DomainModel.DimensionStructure dimensionStructure = dimensionStructureInfinite.ElementAt(i);
                dimensionStructure.IsActive = 1;
                DomainModel.DimensionStructure saved = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .AddAsync(dimensionStructure)
                   .ConfigureAwait(false);
                result.Add(saved);
            }

            return result;
        }

        protected async Task<DomainModel.SourceFormat> CreateSavedSourceFormatEntity()
        {
            DomainModel.SourceFormat sourceFormat = _sourceFormatFaker.Generate();
            DomainModel.SourceFormat result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddAsync(sourceFormat)
               .ConfigureAwait(false);
            return result;
        }

        protected async Task<DomainModel.DimensionStructure> CreateSavedDimensionStructureEntity()
        {
            DomainModel.DimensionStructure dimensionStructure = _dimensionStructureFaker.Generate();
            DomainModel.DimensionStructure result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddAsync(dimensionStructure)
               .ConfigureAwait(false);
            return result;
        }

        protected async Task<DimensionStructureNode> CreateSavedDimensionStructureNodeEntity()
        {
            DimensionStructureNode node = _dimensionStructureNodeFaker.Generate();
            DimensionStructureNode result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureNodeBusinessLogic
               .AddAsync(node)
               .ConfigureAwait(false);
            return result;
        }

        protected async Task<List<DomainModel.SourceFormat>> CreateActiveAndSavedSourceFormatEntitiesAsync(int amount)
        {
            List<DomainModel.SourceFormat> result = new List<DomainModel.SourceFormat>();
            for (int i = 0; i < amount; i++)
            {
                DomainModel.SourceFormat sf = _sourceFormatFaker.Generate();
                sf.IsActive = 1;
                DomainModel.SourceFormat saved = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
                   .AddAsync(sf)
                   .ConfigureAwait(false);
                result.Add(saved);
            }

            return result;
        }

        protected async Task<List<DomainModel.SourceFormat>> CreateInactiveAndSavedSourceFormatEntitiesAsync(int amount)
        {
            List<DomainModel.SourceFormat> result = new List<DomainModel.SourceFormat>();
            for (int i = 0; i < amount; i++)
            {
                DomainModel.SourceFormat sf = _sourceFormatFaker.Generate();
                sf.IsActive = 0;
                DomainModel.SourceFormat saved = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
                   .AddAsync(sf)
                   .ConfigureAwait(false);
                result.Add(sf);
            }

            return result;
        }

        protected async Task<Dictionary<string, long>> CreateThreeLevelDeepAndWideDsnTreeAsync()
        {
            // DSN - 1
            //     DSN - 1-1
            //         DSN - 1-1-1
            //         DSN - 1-1-2
            //         DSN - 1-1-3
            //     DSN - 1-2
            //         DSN - 1-2-1
            //         DSN - 1-2-2
            //         DSN - 1-2-3
            //     DSN - 1-3
            //         DSN - 1-3-1
            //         DSN - 1-3-2
            //         DSN - 1-3-3
            // DSN - 2
            //     DSN - 2-1
            //         DSN - 2-1-1
            //         DSN - 2-1-2
            //         DSN - 2-1-3
            //     DSN - 2-2
            //         DSN - 2-2-1
            //         DSN - 2-2-2
            //         DSN - 2-2-3
            //     DSN - 2-3
            //         DSN - 2-3-1
            //         DSN - 2-3-2
            //         DSN - 2-3-3
            // DSN - 3
            //     DSN - 3-1
            //         DSN - 3-1-1
            //         DSN - 3-1-2
            //         DSN - 3-1-3
            //     DSN - 3-2
            //         DSN - 3-2-1
            //         DSN - 3-2-2
            //         DSN - 3-2-3
            //     DSN - 3-3
            //         DSN - 3-3-1
            //         DSN - 3-3-2
            //         DSN - 3-3-3

            Dictionary<string, long> result = new Dictionary<string, long>();

            DomainModel.SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            result.Add("sf", sf.Id);

            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            result.Add("rootDsn", rootDsn.Id);

            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1, rootDsn, sf).ConfigureAwait(false);
            result.Add("dsn-1", dsn_1.Id);

            DimensionStructureNode dsn_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_1, dsn_1, sf).ConfigureAwait(false);
            result.Add("dsn-1-1", dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_1_1, dsn_1_1, sf).ConfigureAwait(false);
            result.Add("dsn-1-1-1", dsn_1_1_1.Id);

            DimensionStructureNode dsn_1_1_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_1_2, dsn_1_1, sf).ConfigureAwait(false);
            result.Add("dsn-1-1-2", dsn_1_1_2.Id);

            DimensionStructureNode dsn_1_1_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_1_3, dsn_1_1, sf).ConfigureAwait(false);
            result.Add("dsn-1-1-3", dsn_1_1_3.Id);

            DimensionStructureNode dsn_1_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_2, dsn_1, sf).ConfigureAwait(false);
            result.Add("dsn-1-2", dsn_1_2.Id);

            DimensionStructureNode dsn_1_2_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_2_1, dsn_1_2, sf).ConfigureAwait(false);
            result.Add("dsn-1-2-1", dsn_1_2_1.Id);

            DimensionStructureNode dsn_1_2_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_2_2, dsn_1_2, sf).ConfigureAwait(false);
            result.Add("dsn-1-2-2", dsn_1_2_2.Id);

            DimensionStructureNode dsn_1_2_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_2_3, dsn_1_2, sf).ConfigureAwait(false);
            result.Add("dsn-1-2-3", dsn_1_2_3.Id);

            DimensionStructureNode dsn_1_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_3, dsn_1, sf).ConfigureAwait(false);
            result.Add("dsn-1-3", dsn_1_3.Id);

            DimensionStructureNode dsn_1_3_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_3_1, dsn_1_3, sf).ConfigureAwait(false);
            result.Add("dsn-1-3-1", dsn_1_3_1.Id);

            DimensionStructureNode dsn_1_3_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_3_2, dsn_1_3, sf).ConfigureAwait(false);
            result.Add("dsn-1-3-2", dsn_1_3_2.Id);

            DimensionStructureNode dsn_1_3_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_1_3_3, dsn_1_3, sf).ConfigureAwait(false);
            result.Add("dsn-1-3-3", dsn_1_3_3.Id);

            DimensionStructureNode dsn_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2, rootDsn, sf).ConfigureAwait(false);
            result.Add("dsn-2", dsn_2.Id);

            DimensionStructureNode dsn_2_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_1, dsn_2, sf).ConfigureAwait(false);
            result.Add("dsn-2-1", dsn_2_1.Id);

            DimensionStructureNode dsn_2_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_1_1, dsn_2_1, sf).ConfigureAwait(false);
            result.Add("dsn-2-1-1", dsn_2_1_1.Id);

            DimensionStructureNode dsn_2_1_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_1_2, dsn_2_1, sf).ConfigureAwait(false);
            result.Add("dsn-2-1-2", dsn_2_1_2.Id);

            DimensionStructureNode dsn_2_1_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_1_3, dsn_2_1, sf).ConfigureAwait(false);
            result.Add("dsn-2-1-3", dsn_2_1_3.Id);

            DimensionStructureNode dsn_2_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_2, dsn_2, sf).ConfigureAwait(false);
            result.Add("dsn-2-2", dsn_2_2.Id);

            DimensionStructureNode dsn_2_2_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_2_1, dsn_2_2, sf).ConfigureAwait(false);
            result.Add("dsn-2-2-1", dsn_2_2_1.Id);

            DimensionStructureNode dsn_2_2_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_2_2, dsn_2_2, sf).ConfigureAwait(false);
            result.Add("dsn-2-2-2", dsn_2_2_2.Id);

            DimensionStructureNode dsn_2_2_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_2_3, dsn_2_2, sf).ConfigureAwait(false);
            result.Add("dsn-2-2-3", dsn_2_2_3.Id);

            DimensionStructureNode dsn_2_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_3, dsn_2, sf).ConfigureAwait(false);
            result.Add("dsn-2-3", dsn_2_3.Id);

            DimensionStructureNode dsn_2_3_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_3_1, dsn_2_3, sf).ConfigureAwait(false);
            result.Add("dsn-2-3-1", dsn_2_3_1.Id);

            DimensionStructureNode dsn_2_3_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_3_2, dsn_2_3, sf).ConfigureAwait(false);
            result.Add("dsn-2-3-2", dsn_2_3_2.Id);

            DimensionStructureNode dsn_2_3_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_2_3_3, dsn_2_3, sf).ConfigureAwait(false);
            result.Add("dsn-2-3-3", dsn_2_3_3.Id);

            DimensionStructureNode dsn_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3, rootDsn, sf).ConfigureAwait(false);
            result.Add("dsn-3", dsn_3.Id);

            DimensionStructureNode dsn_3_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_1, dsn_3, sf).ConfigureAwait(false);
            result.Add("dsn-3-1", dsn_3_1.Id);

            DimensionStructureNode dsn_3_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_1_1, dsn_3_1, sf).ConfigureAwait(false);
            result.Add("dsn-3-1-1", dsn_3_1_1.Id);

            DimensionStructureNode dsn_3_1_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_1_2, dsn_3_1, sf).ConfigureAwait(false);
            result.Add("dsn-3-1-2", dsn_3_1_2.Id);

            DimensionStructureNode dsn_3_1_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_1_3, dsn_3_1, sf).ConfigureAwait(false);
            result.Add("dsn-3-1-3", dsn_3_1_3.Id);

            DimensionStructureNode dsn_3_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_2, dsn_3, sf).ConfigureAwait(false);
            result.Add("dsn-3-2", dsn_3_2.Id);

            DimensionStructureNode dsn_3_2_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_2_1, dsn_3_2, sf).ConfigureAwait(false);
            result.Add("dsn-3-2-1", dsn_3_2_1.Id);

            DimensionStructureNode dsn_3_2_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_2_2, dsn_3_2, sf).ConfigureAwait(false);
            result.Add("dsn-3-2-2", dsn_3_2_2.Id);

            DimensionStructureNode dsn_3_2_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_2_3, dsn_3_2, sf).ConfigureAwait(false);
            result.Add("dsn-3-2-3", dsn_3_2_3.Id);

            DimensionStructureNode dsn_3_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_3, dsn_3, sf).ConfigureAwait(false);
            result.Add("dsn-3-3", dsn_3_3.Id);

            DimensionStructureNode dsn_3_3_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_3_1, dsn_3_3, sf).ConfigureAwait(false);
            result.Add("dsn-3-3-1", dsn_3_3_1.Id);

            DimensionStructureNode dsn_3_3_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_3_2, dsn_3_3, sf).ConfigureAwait(false);
            result.Add("dsn-3-3-2", dsn_3_3_2.Id);

            DimensionStructureNode dsn_3_3_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await AddChildToDsnAsync(dsn_3_3_3, dsn_3_3, sf).ConfigureAwait(false);
            result.Add("dsn-3-3-3", dsn_3_3_3.Id);

            return result;
        }

        protected async Task AddChildToDsnAsync(
            DimensionStructureNode child,
            DimensionStructureNode parent,
            DomainModel.SourceFormat sf)
        {
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(child.Id, parent.Id, sf.Id)
               .ConfigureAwait(false);
        }

        public void Dispose()
        {
            try
            {
                File.Delete(sqlLiteFileNameWithPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

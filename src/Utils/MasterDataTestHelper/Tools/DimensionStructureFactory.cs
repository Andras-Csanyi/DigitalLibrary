namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    public interface IDimensionStructureFactory
    {
        Task<DimensionStructure> Create(string name);

        Task<DimensionStructure> Create(ThereIsADomainObjectEntity instance);
    }

    public class DimensionStructureFactory : IDimensionStructureFactory
    {
        private readonly IStringHelper _stringHelper;

        public DimensionStructureFactory(IStringHelper stringHelper)
        {
            _stringHelper = stringHelper ?? throw new ArgumentNullException($"{nameof(stringHelper)}");
        }

        public async Task<DimensionStructure> Create(string name)
        {
            DimensionStructure result = new DimensionStructure
            {
                Name = name,
                Desc = _stringHelper.GetRandomString(4),
            };

            return result;
        }

        public async Task<DimensionStructure> Create(ThereIsADomainObjectEntity instance)
        {
            Check.IsNotNull(instance);

            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = instance.NameProperty ?? _stringHelper.GetRandomString(4),
                Desc = instance.DescProperty ?? _stringHelper.GetRandomString(4),
                IsActive = Convert.ToInt32(instance.IsActiveProperty),
            };

            return dimensionStructure;
        }
    }
}
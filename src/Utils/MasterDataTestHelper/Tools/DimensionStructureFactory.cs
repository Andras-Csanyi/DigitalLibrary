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

        Task<DimensionStructure> Create(ThereIsADimensionStructureDomainobjectEntity instance);
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

        public async Task<DimensionStructure> Create(ThereIsADimensionStructureDomainobjectEntity instance)
        {
            Check.IsNotNull(instance);


            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = GetTestString(instance.Name),
                Desc = GetTestString(instance.Desc),
                IsActive = Convert.ToInt32(instance.IsActive),
            };

            return dimensionStructure;
        }

        private string GetTestString(string instanceProperty)
        {
            string result = null;

            switch (instanceProperty)
            {
                case "null":
                    result = null;
                    break;

                case "empty":
                    result = string.Empty;
                    break;

                case "3spaces":
                    result = $"{string.Empty}{string.Empty}{string.Empty}";
                    break;

                case null:
                    result = _stringHelper.GetRandomString(4);
                    break;

                default:
                    result = instanceProperty;
                    break;
            }

            return result;
        }
    }
}
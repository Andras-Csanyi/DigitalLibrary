namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System;

    using DigitalLibrary.MasterData.DomainModel;

    public interface IDimensionStructureFactory
    {
        DimensionStructure Create(string name);
    }

    public class DimensionStructureFactory : IDimensionStructureFactory
    {
        private readonly IStringHelper _stringHelper;

        public DimensionStructureFactory(IStringHelper stringHelper)
        {
            _stringHelper = stringHelper ?? throw new ArgumentNullException($"{nameof(stringHelper)}");
        }

        public DimensionStructure Create(string name)
        {
            DimensionStructure result = new DimensionStructure
            {
                Name = name,
                Desc = _stringHelper.GetRandomString(4),
            };

            return result;
        }
    }
}
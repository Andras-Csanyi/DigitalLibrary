namespace DigitalLibrary.Utils.MasterDataTestHelper.Entities
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    [ExcludeFromCodeCoverage]
    public class ThereIsADimensionStructureDomainObjectEntity : IDimensionStructureDomainObject
    {
        public string Desc { get; set; }

        public int IsActive { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }
    }
}
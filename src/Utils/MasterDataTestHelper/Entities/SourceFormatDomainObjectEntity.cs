namespace DigitalLibrary.Utils.MasterDataTestHelper.Entities
{
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    public class SourceFormatDomainObjectEntity : ISourceFormatDomainObject
    {
        public string Desc { get; set; }

        public int IsActive { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }
    }
}
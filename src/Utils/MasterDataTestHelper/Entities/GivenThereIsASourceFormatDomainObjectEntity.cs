namespace DigitalLibrary.Utils.MasterDataTestHelper.Entities
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class GivenThereIsASourceFormatDomainObjectEntity : ISourceFormatDomainObject
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public int IsActive { get; set; }

        public string Key { get; set; }
    }
}
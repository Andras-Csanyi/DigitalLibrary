namespace MasterData.Bdd.Utils.Entities
{
    using System.Diagnostics.CodeAnalysis;

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
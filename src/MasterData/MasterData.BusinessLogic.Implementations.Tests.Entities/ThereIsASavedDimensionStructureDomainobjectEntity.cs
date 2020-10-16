namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities
{
    public class ThereIsASavedDimensionStructureDomainobjectEntity : IDimensionStructureDomainObject
    {
        public string Desc { get; set; }

        public int IsActive { get; set; }

        public string Key { get; set; }

        public string ResultKey { get; set; }

        public string Name { get; set; }
    }
}
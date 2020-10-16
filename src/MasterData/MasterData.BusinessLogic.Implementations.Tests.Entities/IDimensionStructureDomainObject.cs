namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities
{
    public interface IDimensionStructureDomainObject
    {
        string Desc { get; set; }

        int IsActive { get; set; }

        string Key { get; set; }

        string Name { get; set; }
    }
}
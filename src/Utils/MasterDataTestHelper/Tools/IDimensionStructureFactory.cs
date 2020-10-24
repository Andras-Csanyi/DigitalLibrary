namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    /// IDimensionStructureFactory interface.
    ///
    /// It provides method for creating DimensionStructure objects.
    /// It is used in testing.
    /// </summary>
    public interface IDimensionStructureFactory
    {
        /// <summary>
        /// Creates string based on the input parameters.
        /// </summary>
        /// <param name="instance">Instance.</param>
        /// <returns>Result string.</returns>
        DimensionStructure Create<T>(T instance)
            where T : IDimensionStructureDomainObject;
    }

    public interface IDimensionStructureDomainObject
    {
        string Desc { get; set; }

        int IsActive { get; set; }

        string Key { get; set; }

        string Name { get; set; }
    }
}
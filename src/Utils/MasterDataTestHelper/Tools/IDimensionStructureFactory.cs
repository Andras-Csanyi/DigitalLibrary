namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    ///     IDimensionStructureFactory interface.
    ///     It provides method for creating DimensionStructure objects.
    ///     It is used in testing.
    /// </summary>
    public interface IDimensionStructureFactory
    {
        /// <summary>
        ///     Creates a <see cref="DimensionStructure"/> object and populates its field.
        ///     <para>
        ///         The field population happens either based on the provided instance.
        ///     </para>
        ///     <para>
        ///         Or if no instance properties setup then generated.
        ///     </para>
        /// </summary>
        /// <param name="instance"> The instance containing the parameters. </param>
        /// <typeparam name="T">
        ///     It is type of <see cref="IDimensionStructureDomainObject"/>.
        /// </typeparam>
        /// <returns>
        ///     Returns a <see cref="DimensionStructure"/> object.
        /// </returns>
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

namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    ///     SourceFormat Factory interface.
    ///     It is used for creating <see cref="SourceFormat"/> instances based on
    ///     different information sets. It is used in testing.
    /// </summary>
    public interface ISourceFormatFactory
    {
        /// <summary>
        ///     Creates <see cref="SourceFormat"/> instance based on the information BDD
        ///     instance provides.
        /// </summary>
        /// <param name="instance"> BDD test instance. </param>
        /// <returns> Result string. </returns>
        SourceFormat Create<T>(T instance)
            where T : ISourceFormatDomainObject;
    }

    public interface ISourceFormatDomainObject
    {
        string Desc { get; set; }

        int IsActive { get; set; }

        string Key { get; set; }

        string Name { get; set; }
    }
}
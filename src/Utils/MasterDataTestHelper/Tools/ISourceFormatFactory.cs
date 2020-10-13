namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    /// SourceFormat Factory interface.
    /// It is used for creating <see cref="SourceFormat"/> instances based on
    /// different information sets. It is used in testing.
    /// </summary>
    public interface ISourceFormatFactory
    {
        /// <summary>
        /// Creates <see cref="SourceFormat"/> instance based on the information BDD
        /// instance provides.
        /// </summary>
        /// <param name="instance">BDD test instance.</param>
        /// <returns>Result string.</returns>
        SourceFormat Create(ThereIsADomainObjectEntity instance);
    }
}
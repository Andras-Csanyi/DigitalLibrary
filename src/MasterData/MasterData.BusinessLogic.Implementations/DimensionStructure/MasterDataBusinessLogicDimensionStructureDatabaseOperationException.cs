namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicDimensionStructureDatabaseOperationException : Exception
    {
        public MasterDataBusinessLogicDimensionStructureDatabaseOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}

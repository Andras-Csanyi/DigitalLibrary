namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructureNode
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataDimensionStructureNodeBusinessLogicException : Exception
    {
        public MasterDataDimensionStructureNodeBusinessLogicException()
        {
        }

        protected MasterDataDimensionStructureNodeBusinessLogicException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataDimensionStructureNodeBusinessLogicException(string? message) : base(message)
        {
        }

        public MasterDataDimensionStructureNodeBusinessLogicException(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}

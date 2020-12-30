namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructureNode
{
    using System;
    using System.Runtime.Serialization;

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
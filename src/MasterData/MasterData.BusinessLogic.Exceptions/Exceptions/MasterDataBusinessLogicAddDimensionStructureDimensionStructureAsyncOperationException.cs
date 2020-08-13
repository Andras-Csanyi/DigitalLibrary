// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicAddDimensionStructureDimensionStructureAsyncOperationException :
        Exception
    {
        public MasterDataBusinessLogicAddDimensionStructureDimensionStructureAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicAddDimensionStructureDimensionStructureAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicAddDimensionStructureDimensionStructureAsyncOperationException(string? message) :
            base(message)
        {
        }

        public MasterDataBusinessLogicAddDimensionStructureDimensionStructureAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}
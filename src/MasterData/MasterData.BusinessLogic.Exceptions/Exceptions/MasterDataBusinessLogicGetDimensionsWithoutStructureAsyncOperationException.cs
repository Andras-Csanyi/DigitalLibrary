// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicGetDimensionsWithoutStructureAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetDimensionsWithoutStructureAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetDimensionsWithoutStructureAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicGetDimensionsWithoutStructureAsyncOperationException(string? message) :
            base(message)
        {
        }

        public MasterDataBusinessLogicGetDimensionsWithoutStructureAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}
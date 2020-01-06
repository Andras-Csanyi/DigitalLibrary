namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Exceptions.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicGetDimensionValuesAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetDimensionValuesAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetDimensionValuesAsyncOperationException(SerializationInfo? info,
                                                                                   StreamingContext context) : base(
            info, context)
        {
        }

        public MasterDataBusinessLogicGetDimensionValuesAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicGetDimensionValuesAsyncOperationException(string? message,
                                                                                Exception? innerException) : base(
            message, innerException)
        {
        }
    }
}
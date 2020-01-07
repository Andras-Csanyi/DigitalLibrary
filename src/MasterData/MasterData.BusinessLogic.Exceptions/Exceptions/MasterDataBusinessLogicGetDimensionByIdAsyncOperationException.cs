namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Exceptions.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicGetDimensionByIdAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetDimensionByIdAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetDimensionByIdAsyncOperationException(SerializationInfo? info,
                                                                                 StreamingContext context) : base(info,
            context)
        {
        }

        public MasterDataBusinessLogicGetDimensionByIdAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicGetDimensionByIdAsyncOperationException(string? message,
                                                                              Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}
namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicModifyDimensionAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicModifyDimensionAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicModifyDimensionAsyncOperationException(SerializationInfo? info,
                                                                                StreamingContext context) : base(info,
            context)
        {
        }

        public MasterDataBusinessLogicModifyDimensionAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicModifyDimensionAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
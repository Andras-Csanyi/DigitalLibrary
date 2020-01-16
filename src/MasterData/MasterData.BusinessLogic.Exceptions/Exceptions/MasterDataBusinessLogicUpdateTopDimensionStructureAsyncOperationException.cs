using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions
{
    public class MasterDataBusinessLogicUpdateTopDimensionStructureAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicUpdateTopDimensionStructureAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicUpdateTopDimensionStructureAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicUpdateTopDimensionStructureAsyncOperationException(string? message) :
            base(message)
        {
        }

        public MasterDataBusinessLogicUpdateTopDimensionStructureAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}
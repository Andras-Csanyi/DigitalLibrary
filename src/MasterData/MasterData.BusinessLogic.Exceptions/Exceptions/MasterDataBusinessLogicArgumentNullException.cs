using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicArgumentNullException : Exception
    {
        public MasterDataBusinessLogicArgumentNullException()
        {
        }

        protected MasterDataBusinessLogicArgumentNullException(SerializationInfo? info, StreamingContext context) :
            base(info, context)
        {
        }

        public MasterDataBusinessLogicArgumentNullException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicArgumentNullException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}
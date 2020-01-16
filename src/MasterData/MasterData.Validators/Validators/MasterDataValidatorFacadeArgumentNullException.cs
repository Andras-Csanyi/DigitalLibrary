using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.Validators.Validators
{
    [ExcludeFromCodeCoverage]
    public class MasterDataValidatorFacadeArgumentNullException : Exception
    {
        public MasterDataValidatorFacadeArgumentNullException()
        {
        }

        protected MasterDataValidatorFacadeArgumentNullException(SerializationInfo? info, StreamingContext context) :
            base(info, context)
        {
        }

        public MasterDataValidatorFacadeArgumentNullException(string? message) : base(message)
        {
        }

        public MasterDataValidatorFacadeArgumentNullException(string? message, Exception? innerException) : base(
            message, innerException)
        {
        }
    }
}
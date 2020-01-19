namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicNoSuchSourceFormatEntity : Exception
    {
        public MasterDataBusinessLogicNoSuchSourceFormatEntity()
        {
        }

        protected MasterDataBusinessLogicNoSuchSourceFormatEntity(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicNoSuchSourceFormatEntity(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicNoSuchSourceFormatEntity(string? message, Exception? innerException) :
            base(
                message, innerException)
        {
        }
    }
}
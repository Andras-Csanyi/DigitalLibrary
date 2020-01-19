namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicCountSourceFormatsAsync : Exception
    {
        public MasterDataBusinessLogicCountSourceFormatsAsync()
        {
        }

        protected MasterDataBusinessLogicCountSourceFormatsAsync(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicCountSourceFormatsAsync(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicCountSourceFormatsAsync(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}
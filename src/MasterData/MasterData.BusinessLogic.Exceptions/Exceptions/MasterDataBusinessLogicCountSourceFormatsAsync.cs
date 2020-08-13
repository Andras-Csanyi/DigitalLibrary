// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
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
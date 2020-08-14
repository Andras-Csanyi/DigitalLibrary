// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicNoSuchDimensionDimensionValueEntity : Exception
    {
        public MasterDataBusinessLogicNoSuchDimensionDimensionValueEntity()
        {
        }

        protected MasterDataBusinessLogicNoSuchDimensionDimensionValueEntity(SerializationInfo? info,
                                                                             StreamingContext context) : base(info,
            context)
        {
        }

        public MasterDataBusinessLogicNoSuchDimensionDimensionValueEntity(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicNoSuchDimensionDimensionValueEntity(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}
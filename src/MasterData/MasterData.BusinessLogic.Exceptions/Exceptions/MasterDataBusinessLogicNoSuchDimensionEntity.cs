namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicNoSuchDimensionEntity : Exception
    {
        public MasterDataBusinessLogicNoSuchDimensionEntity()
        {
        }

        protected MasterDataBusinessLogicNoSuchDimensionEntity(SerializationInfo? info, StreamingContext context) :
            base(info, context)
        {
        }

        public MasterDataBusinessLogicNoSuchDimensionEntity(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicNoSuchDimensionEntity(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}
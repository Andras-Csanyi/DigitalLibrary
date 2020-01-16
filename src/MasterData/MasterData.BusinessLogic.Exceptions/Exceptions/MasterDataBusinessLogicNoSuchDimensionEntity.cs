using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions
{
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
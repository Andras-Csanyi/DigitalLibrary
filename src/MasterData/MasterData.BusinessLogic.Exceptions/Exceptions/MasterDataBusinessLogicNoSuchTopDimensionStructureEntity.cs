using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicNoSuchTopDimensionStructureEntity : Exception
    {
        public MasterDataBusinessLogicNoSuchTopDimensionStructureEntity()
        {
        }

        protected MasterDataBusinessLogicNoSuchTopDimensionStructureEntity(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicNoSuchTopDimensionStructureEntity(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicNoSuchTopDimensionStructureEntity(string? message, Exception? innerException) :
            base(
                message, innerException)
        {
        }
    }
}
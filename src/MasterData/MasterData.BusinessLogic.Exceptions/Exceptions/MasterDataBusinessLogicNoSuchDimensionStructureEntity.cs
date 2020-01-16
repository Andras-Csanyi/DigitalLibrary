using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions
{
    public class MasterDataBusinessLogicNoSuchDimensionStructureEntity : Exception
    {
        public MasterDataBusinessLogicNoSuchDimensionStructureEntity()
        {
        }

        protected MasterDataBusinessLogicNoSuchDimensionStructureEntity(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicNoSuchDimensionStructureEntity(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicNoSuchDimensionStructureEntity(string? message, Exception? innerException) : base(
            message, innerException)
        {
        }
    }
}
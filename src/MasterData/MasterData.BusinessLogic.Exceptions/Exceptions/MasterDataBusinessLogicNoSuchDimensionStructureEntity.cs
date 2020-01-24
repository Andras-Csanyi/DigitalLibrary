namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;


    [ExcludeFromCodeCoverage]
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
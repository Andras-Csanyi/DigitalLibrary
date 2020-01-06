namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Exceptions.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicCountTopDimensionStructureAsync : Exception
    {
        public MasterDataBusinessLogicCountTopDimensionStructureAsync()
        {
        }

        protected MasterDataBusinessLogicCountTopDimensionStructureAsync(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicCountTopDimensionStructureAsync(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicCountTopDimensionStructureAsync(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions
{
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
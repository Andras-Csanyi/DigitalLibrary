namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataStepDefinitionException : Exception
    {
        public MasterDataStepDefinitionException()
        {
        }

        protected MasterDataStepDefinitionException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public MasterDataStepDefinitionException(string? message) : base(message)
        {
        }

        public MasterDataStepDefinitionException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}
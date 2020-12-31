namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormatDimensionStructureNode
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MasterDataSourceFormatDimensionStructureNodeBusinessLogicException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MasterDataSourceFormatDimensionStructureNodeBusinessLogicException"/> class.
        /// </summary>
        public MasterDataSourceFormatDimensionStructureNodeBusinessLogicException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MasterDataSourceFormatDimensionStructureNodeBusinessLogicException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MasterDataSourceFormatDimensionStructureNodeBusinessLogicException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MasterDataSourceFormatDimensionStructureNodeBusinessLogicException"/> class.
        /// </summary>
        /// <param name="info">Information.</param>
        /// <param name="context">Context.</param>
        protected MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
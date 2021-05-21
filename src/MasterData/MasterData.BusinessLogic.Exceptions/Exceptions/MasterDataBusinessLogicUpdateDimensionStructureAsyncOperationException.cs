// <copyright file="MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    public class MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException()
        {
        }

        public MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException(
            string? message,
            Exception? innerException)
            : base(message, innerException)
        {
        }

        protected MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}

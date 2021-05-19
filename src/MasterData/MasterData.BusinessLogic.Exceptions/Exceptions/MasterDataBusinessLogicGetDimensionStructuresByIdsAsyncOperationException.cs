// <copyright file="MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException.cs" company="Andras Csanyi">
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
    public class MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException()
        {
        }

        public MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException(
            string? message,
            Exception? innerException)
            : base(message, innerException)
        {
        }

        protected MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}

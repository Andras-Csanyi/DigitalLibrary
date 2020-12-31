// <copyright file="MasterDataBusinessLogicGetDimensionByIdAsyncOperationException.cs" company="Andras Csanyi">
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
    public class MasterDataBusinessLogicGetDimensionByIdAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetDimensionByIdAsyncOperationException()
        {
        }

        public MasterDataBusinessLogicGetDimensionByIdAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicGetDimensionByIdAsyncOperationException(
            string? message,
            Exception? innerException)
            : base(
                message,
                innerException)
        {
        }

        protected MasterDataBusinessLogicGetDimensionByIdAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }
}
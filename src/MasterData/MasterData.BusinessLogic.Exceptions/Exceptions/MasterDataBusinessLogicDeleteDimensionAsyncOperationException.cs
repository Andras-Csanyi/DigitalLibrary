// <copyright file="MasterDataBusinessLogicDeleteDimensionAsyncOperationException.cs" company="Andras Csanyi">
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
    public class MasterDataBusinessLogicDeleteDimensionAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicDeleteDimensionAsyncOperationException()
        {
        }

        public MasterDataBusinessLogicDeleteDimensionAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicDeleteDimensionAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected MasterDataBusinessLogicDeleteDimensionAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
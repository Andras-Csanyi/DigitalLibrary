// <copyright file="MasterDataBusinessLogicUpdateDimensionAsyncOperationException.cs" company="Andras Csanyi">
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
    public class MasterDataBusinessLogicUpdateDimensionAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicUpdateDimensionAsyncOperationException()
        {
        }

        public MasterDataBusinessLogicUpdateDimensionAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicUpdateDimensionAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected MasterDataBusinessLogicUpdateDimensionAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}

// <copyright file="MasterDataBusinessLogicAddDimensionAsyncOperationException.cs" company="Andras Csanyi">
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
    public class MasterDataBusinessLogicAddDimensionAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicAddDimensionAsyncOperationException()
        {
        }

        public MasterDataBusinessLogicAddDimensionAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicAddDimensionAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected MasterDataBusinessLogicAddDimensionAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}

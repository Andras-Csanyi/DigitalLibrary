// <copyright file="MasterDataBusinessLogicAddDimensionValueAsyncOperationException.cs" company="Andras Csanyi">
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
    public class MasterDataBusinessLogicAddDimensionValueAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicAddDimensionValueAsyncOperationException()
        {
        }

        public MasterDataBusinessLogicAddDimensionValueAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicAddDimensionValueAsyncOperationException(
            string? message,
            Exception? innerException)
            : base(
                message, innerException)
        {
        }

        protected MasterDataBusinessLogicAddDimensionValueAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }
}
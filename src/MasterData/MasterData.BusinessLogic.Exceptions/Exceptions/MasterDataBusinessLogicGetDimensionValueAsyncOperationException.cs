// <copyright file="MasterDataBusinessLogicGetDimensionValueAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicGetDimensionValueAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetDimensionValueAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetDimensionValueAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }

        public MasterDataBusinessLogicGetDimensionValueAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicGetDimensionValueAsyncOperationException(
            string? message,
            Exception? innerException)
            : base(
            message, innerException)
        {
        }
    }
}
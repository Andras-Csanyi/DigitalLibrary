// <copyright file="MasterDataBusinessLogicModifyDimensionValueAsyncOperationException.cs" company="Andras Csanyi">
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
    public class MasterDataBusinessLogicModifyDimensionValueAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicModifyDimensionValueAsyncOperationException()
        {
        }

        public MasterDataBusinessLogicModifyDimensionValueAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicModifyDimensionValueAsyncOperationException(
            string? message,
            Exception? innerException)
            : base(
                message, innerException)
        {
        }

        protected MasterDataBusinessLogicModifyDimensionValueAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(
                info, context)
        {
        }
    }
}
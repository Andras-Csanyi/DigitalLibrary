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
    public class MasterDataBusinessLogicDeleteDimensionAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicDeleteDimensionAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicDeleteDimensionAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicDeleteDimensionAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicDeleteDimensionAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
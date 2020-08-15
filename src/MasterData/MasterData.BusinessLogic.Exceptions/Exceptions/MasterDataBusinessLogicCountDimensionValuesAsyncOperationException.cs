// <copyright file="MasterDataBusinessLogicCountDimensionValuesAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicCountDimensionValuesAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicCountDimensionValuesAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicCountDimensionValuesAsyncOperationException(SerializationInfo? info,
                                                                                     StreamingContext context)
            : base(
            info, context)
        {
        }

        public MasterDataBusinessLogicCountDimensionValuesAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicCountDimensionValuesAsyncOperationException(string? message,
                                                                                  Exception? innerException)
            : base(
            message, innerException)
        {
        }
    }
}
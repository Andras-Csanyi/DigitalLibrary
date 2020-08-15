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
    public class MasterDataBusinessLogicAddDimensionValueAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicAddDimensionValueAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicAddDimensionValueAsyncOperationException(SerializationInfo? info,
                                                                                  StreamingContext context) : base(info,
            context)
        {
        }

        public MasterDataBusinessLogicAddDimensionValueAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicAddDimensionValueAsyncOperationException(string? message,
                                                                               Exception? innerException) : base(
            message, innerException)
        {
        }
    }
}
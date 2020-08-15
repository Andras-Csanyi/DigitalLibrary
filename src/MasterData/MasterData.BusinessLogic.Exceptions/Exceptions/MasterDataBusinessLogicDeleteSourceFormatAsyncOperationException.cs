// <copyright file="MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException(
            string? message,
            Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
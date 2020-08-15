// <copyright file="MasterDataBusinessLogicGetSourceFormatsAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicGetSourceFormatsAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetSourceFormatsAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetSourceFormatsAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public MasterDataBusinessLogicGetSourceFormatsAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicGetSourceFormatsAsyncOperationException(
            string? message,
            Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
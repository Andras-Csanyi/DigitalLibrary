// <copyright file="MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}
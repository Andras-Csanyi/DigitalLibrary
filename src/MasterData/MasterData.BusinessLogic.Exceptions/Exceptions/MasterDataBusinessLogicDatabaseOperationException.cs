// <copyright file="MasterDataBusinessLogicDatabaseOperationException.cs" company="Andras Csanyi">
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
    public class MasterDataBusinessLogicDatabaseOperationException : Exception
    {
        public MasterDataBusinessLogicDatabaseOperationException()
        {
        }

        public MasterDataBusinessLogicDatabaseOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicDatabaseOperationException(string? message, Exception? innerException)
            : base(
                message, innerException)
        {
        }

        protected MasterDataBusinessLogicDatabaseOperationException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
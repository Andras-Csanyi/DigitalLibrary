// <copyright file="MasterDataBusinessLogicDatabaseOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicDatabaseOperationException : Exception
    {
        public MasterDataBusinessLogicDatabaseOperationException()
        {
        }

        protected MasterDataBusinessLogicDatabaseOperationException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
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
    }
}
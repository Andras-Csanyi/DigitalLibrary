// <copyright file="MasterDataBusinessLogicException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicException : Exception
    {
        public MasterDataBusinessLogicException()
        {
        }

        protected MasterDataBusinessLogicException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public MasterDataBusinessLogicException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}
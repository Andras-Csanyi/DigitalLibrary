// <copyright file="MasterDataBusinessLogicArgumentNullException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicArgumentNullException : Exception
    {
        public MasterDataBusinessLogicArgumentNullException()
        {
        }

        protected MasterDataBusinessLogicArgumentNullException(SerializationInfo? info, StreamingContext context) :
            base(info, context)
        {
        }

        public MasterDataBusinessLogicArgumentNullException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicArgumentNullException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}
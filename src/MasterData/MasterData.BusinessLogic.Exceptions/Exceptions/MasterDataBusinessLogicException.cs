// <copyright file="MasterDataBusinessLogicException.cs" company="Andras Csanyi">
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
    public class MasterDataBusinessLogicException : Exception
    {
        public MasterDataBusinessLogicException()
        {
        }

        public MasterDataBusinessLogicException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicException(string? message, Exception? innerException)
            : base(message,
                innerException)
        {
        }

        protected MasterDataBusinessLogicException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }
    }
}
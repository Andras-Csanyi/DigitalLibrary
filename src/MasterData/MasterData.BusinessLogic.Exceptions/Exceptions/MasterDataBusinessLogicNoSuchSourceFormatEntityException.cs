// <copyright file="MasterDataBusinessLogicNoSuchSourceFormatEntityException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicNoSuchSourceFormatEntityException : Exception
    {
        public MasterDataBusinessLogicNoSuchSourceFormatEntityException()
        {
        }

        protected MasterDataBusinessLogicNoSuchSourceFormatEntityException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public MasterDataBusinessLogicNoSuchSourceFormatEntityException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicNoSuchSourceFormatEntityException(string? message, Exception? innerException)
            : base(
                message, innerException)
        {
        }
    }
}
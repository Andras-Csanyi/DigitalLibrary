// <copyright file="MasterDataBusinessLogicCountSourceFormatsAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicCountSourceFormatsAsync : Exception
    {
        public MasterDataBusinessLogicCountSourceFormatsAsync()
        {
        }

        protected MasterDataBusinessLogicCountSourceFormatsAsync(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public MasterDataBusinessLogicCountSourceFormatsAsync(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicCountSourceFormatsAsync(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
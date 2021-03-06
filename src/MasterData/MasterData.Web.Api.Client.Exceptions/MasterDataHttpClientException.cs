// <copyright file="MasterDataHttpClientException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Web.Api.Client.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class MasterDataHttpClientException : Exception
    {
        public MasterDataHttpClientException()
        {
        }

        protected MasterDataHttpClientException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }

        public MasterDataHttpClientException(string? message)
            : base(message)
        {
        }

        public MasterDataHttpClientException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}

// <copyright file="DiLibHttpClientErrorDetailsException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.DiLibHttpClient.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class DiLibHttpClientErrorDetailsException : Exception
    {
        public DiLibHttpClientErrorDetailsException()
        {
        }

        protected DiLibHttpClientErrorDetailsException(SerializationInfo? info, StreamingContext context)
            : base(
                info,
                context)
        {
        }

        public DiLibHttpClientErrorDetailsException(string? message)
            : base(message)
        {
        }

        public DiLibHttpClientErrorDetailsException(string? message, Exception? innerException)
            : base(
                message,
                innerException)
        {
        }
    }
}

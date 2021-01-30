// <copyright file="DiLibHttpClientDeleteException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.DiLibHttpClient.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class DiLibHttpClientException : Exception
    {
        public DiLibHttpClientException()
        {
        }

        protected DiLibHttpClientException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }

        public DiLibHttpClientException(string? message)
            : base(message)
        {
        }

        public DiLibHttpClientException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
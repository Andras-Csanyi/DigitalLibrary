// <copyright file="DiLibHttpClientDeleteException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.DiLibHttpClient.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <inheritdoc />
    public class DiLibHttpClientException : Exception
    {
        /// <inheritdoc />
        public DiLibHttpClientException()
        {
        }

        /// <inheritdoc />
        protected DiLibHttpClientException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <inheritdoc />
        public DiLibHttpClientException(string? message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public DiLibHttpClientException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
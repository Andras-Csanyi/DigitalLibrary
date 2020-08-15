// <copyright file="DiLibHttpClientDeleteException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.DiLibHttpClient.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DiLibHttpClientDeleteException : Exception
    {
        public DiLibHttpClientDeleteException()
        {
        }

        protected DiLibHttpClientDeleteException(SerializationInfo? info, StreamingContext context)
            : base(
                info,
                context)
        {
        }

        public DiLibHttpClientDeleteException(string? message)
            : base(message)
        {
        }

        public DiLibHttpClientDeleteException(string? message, Exception? innerException)
            : base(
                message,
                innerException)
        {
        }
    }
}
// <copyright file="DiLibGridHttpClientNotInstantiatedException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DiLibGridHttpClientNotInstantiatedException : Exception
    {
        public DiLibGridHttpClientNotInstantiatedException()
        {
        }

        protected DiLibGridHttpClientNotInstantiatedException(SerializationInfo? info, StreamingContext context) : base(
            info, context)
        {
        }

        public DiLibGridHttpClientNotInstantiatedException(string? message) : base(message)
        {
        }

        public DiLibGridHttpClientNotInstantiatedException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}
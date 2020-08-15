// <copyright file="DiLibGridHttpClientNotInstantiatedException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
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

        protected DiLibGridHttpClientNotInstantiatedException(SerializationInfo? info, StreamingContext context)
            : base(
            info, context)
        {
        }

        public DiLibGridHttpClientNotInstantiatedException(string? message)
            : base(message)
        {
        }

        public DiLibGridHttpClientNotInstantiatedException(string? message, Exception? innerException)
            : base(
                message,
                innerException)
        {
        }
    }
}
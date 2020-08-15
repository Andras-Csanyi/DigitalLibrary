// <copyright file="DiLibGridTTypeDoesntHavePropertiesException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DiLibGridTTypeDoesntHavePropertiesException : Exception
    {
        public DiLibGridTTypeDoesntHavePropertiesException()
        {
        }

        protected DiLibGridTTypeDoesntHavePropertiesException(SerializationInfo? info, StreamingContext context) : base(
            info, context)
        {
        }

        public DiLibGridTTypeDoesntHavePropertiesException(string? message) : base(message)
        {
        }

        public DiLibGridTTypeDoesntHavePropertiesException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}
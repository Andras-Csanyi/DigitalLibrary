// <copyright file="DiLibGridTTypeDoesntHavePropertiesException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
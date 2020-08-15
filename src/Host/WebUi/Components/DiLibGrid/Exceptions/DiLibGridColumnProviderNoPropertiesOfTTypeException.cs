// <copyright file="DiLibGridColumnProviderNoPropertiesOfTTypeException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DiLibGridColumnProviderNoPropertiesOfTTypeException : Exception
    {
        public DiLibGridColumnProviderNoPropertiesOfTTypeException()
        {
        }

        protected DiLibGridColumnProviderNoPropertiesOfTTypeException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }

        public DiLibGridColumnProviderNoPropertiesOfTTypeException(string? message) : base(message)
        {
        }

        public DiLibGridColumnProviderNoPropertiesOfTTypeException(string? message, Exception? innerException) : base(
            message, innerException)
        {
        }
    }
}
// <copyright file="DiLibGridColumnProviderNoEntityPropertiesAreProvidedException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DiLibGridColumnProviderNoEntityPropertiesAreProvidedException : Exception
    {
        public DiLibGridColumnProviderNoEntityPropertiesAreProvidedException()
        {
        }

        protected DiLibGridColumnProviderNoEntityPropertiesAreProvidedException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public DiLibGridColumnProviderNoEntityPropertiesAreProvidedException(string? message) : base(message)
        {
        }

        public DiLibGridColumnProviderNoEntityPropertiesAreProvidedException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
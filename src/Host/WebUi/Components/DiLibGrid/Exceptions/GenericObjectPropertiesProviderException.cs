// <copyright file="GenericObjectPropertiesProviderException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class GenericObjectPropertiesProviderException : Exception
    {
        public GenericObjectPropertiesProviderException()
        {
        }

        protected GenericObjectPropertiesProviderException(SerializationInfo? info, StreamingContext context)
            : base(
                info, context)
        {
        }

        public GenericObjectPropertiesProviderException(string? message)
            : base(message)
        {
        }

        public GenericObjectPropertiesProviderException(string? message, Exception? innerException)
            : base(
                message,
                innerException)
        {
        }
    }
}
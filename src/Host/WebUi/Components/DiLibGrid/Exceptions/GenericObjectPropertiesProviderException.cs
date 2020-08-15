// <copyright file="GenericObjectPropertiesProviderException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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

        protected GenericObjectPropertiesProviderException(SerializationInfo? info, StreamingContext context) : base(
            info, context)
        {
        }

        public GenericObjectPropertiesProviderException(string? message) : base(message)
        {
        }

        public GenericObjectPropertiesProviderException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}
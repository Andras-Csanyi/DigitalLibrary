// <copyright file="SourceFormatBuilderServiceException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class SourceFormatBuilderServiceException : Exception
    {
        public SourceFormatBuilderServiceException()
        {
        }

        protected SourceFormatBuilderServiceException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }

        public SourceFormatBuilderServiceException(string? message)
            : base(message)
        {
        }

        public SourceFormatBuilderServiceException(string? message, Exception? innerException)
            : base(
                message,
                innerException)
        {
        }
    }
}
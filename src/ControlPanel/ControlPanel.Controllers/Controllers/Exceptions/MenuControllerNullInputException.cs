// <copyright file="MenuControllerNullInputException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.Controllers.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    public class MenuControllerNullInputException : Exception
    {
        public MenuControllerNullInputException()
        {
        }

        public MenuControllerNullInputException(string? message)
            : base(message)
        {
        }

        public MenuControllerNullInputException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected MenuControllerNullInputException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

// <copyright file="MenuNullInputException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    public class MenuNullInputException : Exception
    {
        public MenuNullInputException()
        {
        }

        public MenuNullInputException(string message)
            : base(message)
        {
        }

        public MenuNullInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected MenuNullInputException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

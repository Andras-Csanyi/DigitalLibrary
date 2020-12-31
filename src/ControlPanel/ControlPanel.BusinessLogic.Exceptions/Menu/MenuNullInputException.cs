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
    public class MenuNullInputException : Exception
    {
        public MenuNullInputException()
        {
        }

        protected MenuNullInputException(SerializationInfo info, StreamingContext context)
            : base(info, context)
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
    }
}
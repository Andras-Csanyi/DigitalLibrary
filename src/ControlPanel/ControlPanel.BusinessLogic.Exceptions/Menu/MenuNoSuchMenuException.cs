// <copyright file="MenuNoSuchMenuException.cs" company="Andras Csanyi">
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
    public class MenuNoSuchMenuException : Exception
    {
        public MenuNoSuchMenuException()
        {
        }

        public MenuNoSuchMenuException(string message)
            : base(message)
        {
        }

        public MenuNoSuchMenuException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected MenuNoSuchMenuException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

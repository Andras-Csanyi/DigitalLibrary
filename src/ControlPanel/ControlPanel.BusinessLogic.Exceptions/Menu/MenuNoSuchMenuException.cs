// <copyright file="MenuNoSuchMenuException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
    using System;
    using System.Runtime.Serialization;

    public class MenuNoSuchMenuException : Exception
    {
        public MenuNoSuchMenuException()
        {
        }

        protected MenuNoSuchMenuException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public MenuNoSuchMenuException(string message) : base(message)
        {
        }

        public MenuNoSuchMenuException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
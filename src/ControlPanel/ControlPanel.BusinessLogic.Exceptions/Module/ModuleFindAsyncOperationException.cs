// <copyright file="ModuleFindAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    public class ModuleFindAsyncOperationException : Exception
    {
        public ModuleFindAsyncOperationException()
        {
        }

        public ModuleFindAsyncOperationException(string message)
            : base(message)
        {
        }

        public ModuleFindAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ModuleFindAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

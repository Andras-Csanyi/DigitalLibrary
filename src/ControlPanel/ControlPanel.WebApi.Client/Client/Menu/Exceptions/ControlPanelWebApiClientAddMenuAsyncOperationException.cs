// <copyright file="ControlPanelWebApiClientAddMenuAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientAddMenuAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientAddMenuAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientAddMenuAsyncOperationException(SerializationInfo info,
                                                                         StreamingContext context)
            : base(info, context)
        {
        }

        public ControlPanelWebApiClientAddMenuAsyncOperationException(string message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientAddMenuAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
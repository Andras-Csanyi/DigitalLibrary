// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientAddModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientAddModuleAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientAddModuleAsyncOperationException(SerializationInfo? info,
                                                                           StreamingContext context)
            : base(info, context)
        {
        }

        public ControlPanelWebApiClientAddModuleAsyncOperationException(string? message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientAddModuleAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
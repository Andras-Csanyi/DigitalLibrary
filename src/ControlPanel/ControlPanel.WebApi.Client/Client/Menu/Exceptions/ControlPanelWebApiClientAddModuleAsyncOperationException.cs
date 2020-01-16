using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientAddModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientAddModuleAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientAddModuleAsyncOperationException(SerializationInfo? info,
                                                                           StreamingContext context) : base(info,
            context)
        {
        }

        public ControlPanelWebApiClientAddModuleAsyncOperationException(string? message) : base(message)
        {
        }

        public ControlPanelWebApiClientAddModuleAsyncOperationException(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}
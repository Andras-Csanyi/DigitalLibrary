using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientDeleteModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientDeleteModuleAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientDeleteModuleAsyncOperationException(SerializationInfo? info,
                                                                              StreamingContext context) : base(info,
            context)
        {
        }

        public ControlPanelWebApiClientDeleteModuleAsyncOperationException(string? message) : base(message)
        {
        }

        public ControlPanelWebApiClientDeleteModuleAsyncOperationException(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}
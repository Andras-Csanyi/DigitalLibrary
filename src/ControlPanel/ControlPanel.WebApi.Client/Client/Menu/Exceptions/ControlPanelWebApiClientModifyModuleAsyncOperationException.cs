using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientModifyModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientModifyModuleAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientModifyModuleAsyncOperationException(SerializationInfo? info,
                                                                              StreamingContext context) : base(info,
            context)
        {
        }

        public ControlPanelWebApiClientModifyModuleAsyncOperationException(string? message) : base(message)
        {
        }

        public ControlPanelWebApiClientModifyModuleAsyncOperationException(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}
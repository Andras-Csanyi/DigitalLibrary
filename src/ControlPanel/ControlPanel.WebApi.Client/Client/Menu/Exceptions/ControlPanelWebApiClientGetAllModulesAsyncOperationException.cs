using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientGetAllModulesAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientGetAllModulesAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientGetAllModulesAsyncOperationException(SerializationInfo? info,
                                                                               StreamingContext context) : base(info,
            context)
        {
        }

        public ControlPanelWebApiClientGetAllModulesAsyncOperationException(string? message) : base(message)
        {
        }

        public ControlPanelWebApiClientGetAllModulesAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
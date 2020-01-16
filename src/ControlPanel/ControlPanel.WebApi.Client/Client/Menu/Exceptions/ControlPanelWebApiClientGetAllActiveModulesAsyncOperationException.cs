using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException(SerializationInfo? info,
                                                                                     StreamingContext context) : base(
            info, context)
        {
        }

        public ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException(string? message) : base(message)
        {
        }

        public ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException(string? message,
                                                                                  Exception? innerException) : base(
            message, innerException)
        {
        }
    }
}
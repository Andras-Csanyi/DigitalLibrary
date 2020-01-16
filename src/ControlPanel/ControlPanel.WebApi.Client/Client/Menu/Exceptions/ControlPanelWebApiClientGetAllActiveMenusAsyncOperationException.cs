using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException(SerializationInfo info,
                                                                                   StreamingContext context) : base(
            info, context)
        {
        }

        public ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException(string message) : base(message)
        {
        }

        public ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException(string message,
                                                                                Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
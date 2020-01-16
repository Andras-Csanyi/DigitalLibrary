using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientGetAllMenusAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientGetAllMenusAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientGetAllMenusAsyncOperationException(SerializationInfo info,
                                                                             StreamingContext context) : base(info,
            context)
        {
        }

        public ControlPanelWebApiClientGetAllMenusAsyncOperationException(string message) : base(message)
        {
        }

        public ControlPanelWebApiClientGetAllMenusAsyncOperationException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
    }
}
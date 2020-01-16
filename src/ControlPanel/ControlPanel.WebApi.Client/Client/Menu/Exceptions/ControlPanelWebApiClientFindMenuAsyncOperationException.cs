using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientFindMenuAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientFindMenuAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientFindMenuAsyncOperationException(SerializationInfo info,
                                                                          StreamingContext context) : base(info,
            context)
        {
        }

        public ControlPanelWebApiClientFindMenuAsyncOperationException(string message) : base(message)
        {
        }

        public ControlPanelWebApiClientFindMenuAsyncOperationException(string message, Exception innerException) : base(
            message, innerException)
        {
        }
    }
}
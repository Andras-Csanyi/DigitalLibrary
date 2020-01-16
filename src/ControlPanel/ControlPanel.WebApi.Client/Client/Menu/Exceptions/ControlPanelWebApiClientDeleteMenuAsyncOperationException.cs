using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientDeleteMenuAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientDeleteMenuAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientDeleteMenuAsyncOperationException(SerializationInfo info,
                                                                            StreamingContext context) : base(info,
            context)
        {
        }

        public ControlPanelWebApiClientDeleteMenuAsyncOperationException(string message) : base(message)
        {
        }

        public ControlPanelWebApiClientDeleteMenuAsyncOperationException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
    }
}
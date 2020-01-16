using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientModifyMenuAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientModifyMenuAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientModifyMenuAsyncOperationException(SerializationInfo info,
                                                                            StreamingContext context) : base(info,
            context)
        {
        }

        public ControlPanelWebApiClientModifyMenuAsyncOperationException(string message) : base(message)
        {
        }

        public ControlPanelWebApiClientModifyMenuAsyncOperationException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
    }
}
// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientModifyMenuAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientModifyMenuAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientModifyMenuAsyncOperationException(SerializationInfo info,
                                                                            StreamingContext context)
            : base(info, context)
        {
        }

        public ControlPanelWebApiClientModifyMenuAsyncOperationException(string message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientModifyMenuAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
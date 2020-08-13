// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientDeleteMenuAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientDeleteMenuAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientDeleteMenuAsyncOperationException(SerializationInfo info,
                                                                            StreamingContext context)
            : base(info, context)
        {
        }

        public ControlPanelWebApiClientDeleteMenuAsyncOperationException(string message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientDeleteMenuAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException(SerializationInfo info,
                                                                                   StreamingContext context)
            : base(info, context)
        {
        }

        public ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException(string message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException(string message,
                                                                                Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
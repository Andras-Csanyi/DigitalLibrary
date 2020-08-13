// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException(SerializationInfo? info,
                                                                                     StreamingContext context)
            : base(info, context)
        {
        }

        public ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException(string? message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException(string? message,
                                                                                  Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
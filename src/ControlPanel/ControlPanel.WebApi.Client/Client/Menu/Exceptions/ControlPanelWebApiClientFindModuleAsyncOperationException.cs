// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientFindModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientFindModuleAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientFindModuleAsyncOperationException(SerializationInfo? info,
                                                                            StreamingContext context)
            : base(info,
                context)
        {
        }

        public ControlPanelWebApiClientFindModuleAsyncOperationException(string? message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientFindModuleAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
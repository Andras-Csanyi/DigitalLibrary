namespace DigitalLibrary.IaC.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientFindModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientFindModuleAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientFindModuleAsyncOperationException(SerializationInfo? info,
                                                                            StreamingContext context) : base(info,
            context)
        {
        }

        public ControlPanelWebApiClientFindModuleAsyncOperationException(string? message) : base(message)
        {
        }

        public ControlPanelWebApiClientFindModuleAsyncOperationException(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}
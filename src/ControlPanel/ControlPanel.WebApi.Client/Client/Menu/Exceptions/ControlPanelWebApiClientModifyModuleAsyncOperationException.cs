namespace DigitalLibrary.IaC.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientModifyModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientModifyModuleAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientModifyModuleAsyncOperationException(SerializationInfo? info,
                                                                              StreamingContext context) : base(info,
            context)
        {
        }

        public ControlPanelWebApiClientModifyModuleAsyncOperationException(string? message) : base(message)
        {
        }

        public ControlPanelWebApiClientModifyModuleAsyncOperationException(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}
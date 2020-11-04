namespace DigitalLibrary.MasterData.WebApi.Client.ResponseObjects
{
    using System;

    public class WebApiClientResponseObject<T>
    {
        public string ErrorMessage { get; set; }

        public Exception Exception { get; set; }
        
        public T Result { get; set; }
        
        public bool IsFailed { get; set; }
    }
}
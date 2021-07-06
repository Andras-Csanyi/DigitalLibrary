namespace DiLibHttpClientResponseObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class DilibHttpClientResponse<T>
    {
        public string ExceptionMessage { get; set; }

        public Exception Exception { get; set; }

        public T Result { get; set; }

        public bool IsSuccess { get; set; }

        public int HttpStatusCode { get; set; }

        public string ErrorDetails { get; set; }
    }
}

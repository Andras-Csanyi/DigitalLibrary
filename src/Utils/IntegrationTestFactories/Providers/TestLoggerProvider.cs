namespace DigitalLibrary.Utils.IntegrationTestFactories.Providers
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.Extensions.Logging;

    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class TestLoggerProvider : ILoggerProvider
    {
        private ITestOutputHelper _outputHelper;

        public TestLoggerProvider(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper
                         ?? throw new ArgumentNullException($"No {nameof(outputHelper)} provided.");
        }

        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName) => new TestLogger(
            categoryName, _outputHelper);
    }
}
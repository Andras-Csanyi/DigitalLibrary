namespace DigitalLibrary.Utils.IntegrationTestFactories.Providers
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    using Xunit.Abstractions;

    // https://stackoverflow.com/questions/61673470/getting-ef-core-to-output-sql-statements-to-xunits-itestoutputhelper
    public class TestLogger : ILogger
    {
        private string _categoryName;

        private ITestOutputHelper _testOutputHelper;

        public TestLogger(string categoryName, ITestOutputHelper testOutputHelper)
        {
            _categoryName = categoryName
                ?? throw new ArgumentNullException($"No {nameof(categoryName)} is provided.");
            _testOutputHelper = testOutputHelper
                ?? throw new ArgumentNullException($"No {nameof(testOutputHelper)} is provided.");
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            _testOutputHelper.WriteLine(formatter(state, exception));
        }

        public bool IsEnabled(LogLevel logLevel) => _categoryName == DbLoggerCategory.Database.Command.Name;

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}
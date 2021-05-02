namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    /// <inheritdoc />
    [ExcludeFromCodeCoverage]
    public class SourceFormatFactory : ISourceFormatFactory
    {
        private readonly IStringHelper _stringHelper;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SourceFormatFactory" /> class.
        /// </summary>
        /// <param name="stringHelper">SourceFormatFactory instance.</param>
        public SourceFormatFactory(IStringHelper stringHelper)
        {
            _stringHelper = stringHelper;
        }

        /// <inheritdoc />
        public SourceFormat Create<T>(T instance)
            where T : ISourceFormatDomainObject
        {
            Check.IsNotNull(instance);

            SourceFormat sourceFormat = new SourceFormat
            {
                Name = _stringHelper.GetNamePropertyString(instance.Name),
                Desc = _stringHelper.GetDescPropertyString(instance.Desc),
                IsActive = Convert.ToInt32(instance.IsActive),
            };

            return sourceFormat;
        }
    }
}
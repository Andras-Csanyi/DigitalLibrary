namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    /// <inheritdoc />
    public class SourceFormatFactory : ISourceFormatFactory
    {
        private readonly IStringHelper _stringHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceFormatFactory"/> class.
        /// </summary>
        /// <param name="stringHelper">SourceFormatFactory instance.</param>
        public SourceFormatFactory(IStringHelper stringHelper)
        {
            _stringHelper = stringHelper;
        }

        /// <inheritdoc/>
        public SourceFormat Create(ThereIsASourceFormatDomainObjectEntity instance)
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
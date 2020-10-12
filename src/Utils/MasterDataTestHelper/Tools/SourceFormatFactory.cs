namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    public interface ISourceFormatFactory
    {
        Task<SourceFormat> Create(string name);

        Task<SourceFormat> Create(ThereIsADomainObjectEntity instance);
    }

    public class SourceFormatFactory : ISourceFormatFactory
    {
        private readonly IStringHelper _stringHelper;

        public SourceFormatFactory(IStringHelper stringHelper)
        {
            _stringHelper = stringHelper;
        }

        public async Task<SourceFormat> Create(string name)
        {
            SourceFormat result = new SourceFormat
            {
                Name = name,
                Desc = _stringHelper.GetRandomString(4),
            };
            return result;
        }

        public async Task<SourceFormat> Create(ThereIsADomainObjectEntity instance)
        {
            Check.IsNotNull(instance);

            SourceFormat sourceFormat = new SourceFormat
            {
                Name = instance.NameProperty ?? _stringHelper.GetRandomString(4),
                Desc = instance.DescProperty ?? _stringHelper.GetRandomString(4),
                IsActive = Convert.ToInt32(instance.IsActiveProperty),
            };

            return sourceFormat;
        }
    }
}
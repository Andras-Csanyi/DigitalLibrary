namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using DigitalLibrary.MasterData.DomainModel;

    public interface ISourceFormatFactory
    {
        SourceFormat Create(string name);
    }

    public class SourceFormatFactory : ISourceFormatFactory
    {
        private readonly IStringHelper _stringHelper;

        public SourceFormatFactory(IStringHelper stringHelper)
        {
            _stringHelper = stringHelper;
        }

        public SourceFormat Create(string name)
        {
            SourceFormat result = new SourceFormat
            {
                Name = name,
                Desc = _stringHelper.GetRandomString(4),
            };
            return result;
        }
    }
}
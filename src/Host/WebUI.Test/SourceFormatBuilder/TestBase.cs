namespace WebUI.Test.SourceFormatBuilder
{
    using DigitalLibrary.MasterData.WebApi.Client;

    using Moq;

    public class TestBase
    {
        protected Mock<IMasterDataHttpClient> _masterDataWebApiClientMock = new Mock<IMasterDataHttpClient>();
    }
}
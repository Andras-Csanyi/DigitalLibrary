namespace DigitalLibrary.Ui.WebUI.Test.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FluentAssertions;

    using MasterData.DomainModel;

    using WebUi.Services;

    using Xunit;

    public class DomainEntityHelperService_Should
    {
        [Fact]
        public async Task Asd()
        {
            IDomainEntityHelperService service = new DomainEntityHelperService();

            List<Dimension> list = new List<Dimension>
            {
                new Dimension(),
                new Dimension(),
                new Dimension()
            };

            List<Dimension> result = await service.AddNulloToListAsFirstItem(list)
               .ConfigureAwait(false);

            result.Count.Should().Be(4);
        }
    }
}
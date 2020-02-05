namespace DigitalLibrary.Ui.WebUi.Services
{
    using System;
    using System.Threading.Tasks;

    public class SourceFormatBuilderService
    {
        public event Func<Task> Notify;

        public async Task Update()
        {
            await Notify.Invoke().ConfigureAwait(false);
        }
    }
}
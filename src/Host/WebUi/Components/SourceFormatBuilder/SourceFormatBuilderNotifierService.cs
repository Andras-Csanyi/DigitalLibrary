// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System;
    using System.Threading.Tasks;

    public class SourceFormatBuilderNotifierService
    {
        public event Func<Task> Notify;

        public async Task UpdateSourceFormatBuilder()
        {
            if (Notify != null)
            {
                await Notify.Invoke().ConfigureAwait(false);
            }
        }
    }
}
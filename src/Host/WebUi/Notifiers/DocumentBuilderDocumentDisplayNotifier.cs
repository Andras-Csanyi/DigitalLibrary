// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.Ui.WebUi.Notifiers
{
    using System;
    using System.Threading.Tasks;

    public class DocumentBuilderDocumentDisplayNotifier
    {
        public event Func<long, Task> Notify;

        public async Task Update(long sourceFormatId)
        {
            Console.WriteLine($"{nameof(sourceFormatId)}: {sourceFormatId}");
            if (Notify != null)
            {
                await Notify.Invoke(sourceFormatId).ConfigureAwait(false);
            }
            else
            {
                Console.WriteLine($"{nameof(Notify)} is null.");
            }
        }
    }
}
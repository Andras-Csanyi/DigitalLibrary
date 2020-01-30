namespace DigitalLibrary.Ui.WebUi.Notifiers
{
    using System;
    using System.Threading.Tasks;

    public class DocumentBuilderDocumentDisplayNotifier
    {
        public long SelectedSourceFormatId { get; private set; }

        public event Action OnChange;

        public async Task Update(long sourceFormatId)
        {
            SelectedSourceFormatId = sourceFormatId;
            Console.WriteLine($"{nameof(SelectedSourceFormatId)}: {SelectedSourceFormatId}");
            await NotifyStateChanged().ConfigureAwait(false);
        }

        private async Task NotifyStateChanged()
        {
            if (OnChange == null)
            {
                Console.WriteLine("OnChange is null");
            }
            else
            {
                OnChange.Invoke();
            }
        }
    }
}
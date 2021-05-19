// <copyright file="DocumentBuilderDocumentDisplayNotifier.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

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

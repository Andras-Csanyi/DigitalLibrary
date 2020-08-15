// <copyright file="SourceFormatBuilderNotifierService.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

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
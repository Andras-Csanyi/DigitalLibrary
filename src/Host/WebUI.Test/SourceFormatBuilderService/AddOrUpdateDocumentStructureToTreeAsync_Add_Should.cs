namespace WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;
    using DigitalLibrary.Ui.WebUi.Services;

    using FluentAssertions;

    using Moq;

    using Xunit;

    public class AddOrUpdateDocumentStructureToTreeAsync_Add_Should : TestBase
    {
        [Fact]
        public async Task AddItem_ToRootDimension()
        {
        }

        [Fact]
        public async Task AddItemTo_FirstLevel_EmptyLengthList()
        {
        }

        /// <summary>
        /// Until this: https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        /// is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_FirstLevel_ListHasMultipleItems()
        {
        }

        /// <summary>
        /// Until this: https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        /// is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_SecondLevel_EmptyList()
        {
        }

        /// <summary>
        /// Until this: https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        /// is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_SecondLevel_LastHasMultipleItems()
        {
        }

        /// <summary>
        /// Until this: https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        /// is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_WhenAnItemIsAdded()
        {
        }
    }
}
namespace DigitalLibrary.Ui.WebUi.Components.Grids
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BlazorStrap;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.MasterData.WebApi.Client;

    using FluentValidation;

    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public partial class DimensionGrid
    {
        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        [Inject]
        public IMasterDataValidators MasterDataValidators { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        private List<Dimension> _dimensions = new List<Dimension>();

        private BSModal _newDimensionModal;

        private BSModal _editDimensionModal;

        private Dimension _newDimension = new Dimension();

        private Dimension _editedDimension = new Dimension();

        private Dimension _deleteDimension = new Dimension();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await PopulateDimensionsAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task PopulateDimensionsAsync()
        {
            _dimensions = await MasterDataHttpClient.GetDimensionsAsync().ConfigureAwait(false);
        }

        private async Task CancelNewDimensionAction()
        {
            _newDimension = new Dimension();
            _newDimensionModal.Hide();
        }

        private async Task OpenNewDimensionModal()
        {
            if (_newDimension == null)
            {
                _newDimension = new Dimension();
            }

            _newDimensionModal.Show();
        }

        private async Task AddDimensionHandler()
        {
            await JsRuntime.InvokeAsync<string>("console.log", _newDimension).ConfigureAwait(false);
            try
            {
                await MasterDataValidators.DimensionValidator.ValidateAndThrowAsync(
                        _newDimension,
                        ruleSet: ValidatorRulesets.AddNewDimension)
                   .ConfigureAwait(false);
                await MasterDataHttpClient.AddDimensionAsync(_newDimension)
                   .ConfigureAwait(false);
                await PopulateDimensionsAsync().ConfigureAwait(false);
                await HideNewDimensionModalAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task HideNewDimensionModalAsync()
        {
            _newDimensionModal.Hide();
        }

        private async Task HideEditDimensionModalAsync()
        {
            _editDimensionModal.Hide();
        }

        private async Task EditDimensionHandler()
        {
            try
            {
                await MasterDataValidators.DimensionValidator.ValidateAndThrowAsync(
                        _editedDimension,
                        ruleSet: ValidatorRulesets.UpdateDimension)
                   .ConfigureAwait(false);
                await MasterDataHttpClient.UpdateDimensionAsync(_editedDimension).ConfigureAwait(false);
                await PopulateDimensionsAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task DeleteDimensionAction(Dimension dimension)
        {
        }

        private async Task CancelEditDimensionAction()
        {
            _editedDimension = new Dimension();
            await HideEditDimensionModalAsync().ConfigureAwait(false);
        }

        private async Task EditDimensionAction(Dimension dimension)
        {
            _editedDimension = dimension;
            await OpenEditDimensionModal().ConfigureAwait(false);
        }

        private async Task OpenEditDimensionModal()
        {
            _editDimensionModal.Show();
        }
    }
}
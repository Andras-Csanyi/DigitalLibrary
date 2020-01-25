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
        private Dimension _deleteDimension = new Dimension();

        private BSModal _deleteDimensionModal;

        private List<Dimension> _dimensions = new List<Dimension>();

        private BSModal _editDimensionModal;

        private Dimension _editedDimension = new Dimension();

        private Dimension _newDimension = new Dimension();

        private BSModal _newDimensionModal;

        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        [Inject]
        public IMasterDataValidators MasterDataValidators { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

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

        private async Task CancelNewDimensionActionAsync()
        {
            _newDimension = new Dimension();
            _newDimensionModal.Hide();
        }

        private async Task OpenNewDimensionModalAsync()
        {
            if (_newDimension == null)
            {
                await SetNewDimensionToDefaultAsync().ConfigureAwait(false);
            }

            _newDimensionModal.Show();
        }

        private async Task AddDimensionHandlerAsync()
        {
            try
            {
                await ValidateNewDimensionAsync().ConfigureAwait(false);
                await SendNewDimensionToBackendAsync().ConfigureAwait(false);
                await PopulateDimensionsAsync().ConfigureAwait(false);
                await HideNewDimensionModalAsync().ConfigureAwait(false);
                await SetNewDimensionToDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task SetNewDimensionToDefaultAsync()
        {
            _newDimension = new Dimension();
        }

        private async Task SendNewDimensionToBackendAsync()
        {
            await MasterDataHttpClient.AddDimensionAsync(_newDimension)
               .ConfigureAwait(false);
        }

        private async Task ValidateNewDimensionAsync()
        {
            await MasterDataValidators.DimensionValidator.ValidateAndThrowAsync(
                    _newDimension,
                    ruleSet: ValidatorRulesets.AddNewDimension)
               .ConfigureAwait(false);
        }

        private async Task HideNewDimensionModalAsync()
        {
            _newDimensionModal.Hide();
        }

        private async Task HideEditDimensionModalAsync()
        {
            _editDimensionModal.Hide();
        }

        private async Task HideDeleteDimensionModalAsync()
        {
            _deleteDimensionModal.Hide();
        }

        private async Task EditDimensionHandlerAsync()
        {
            try
            {
                await ValidateEditedDimensionAsync().ConfigureAwait(false);
                await SendEditedDimensionToBackendAsync().ConfigureAwait(false);
                await PopulateDimensionsAsync().ConfigureAwait(false);
                await HideEditDimensionModalAsync().ConfigureAwait(false);
                await SetEditedDimensionToDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task SetEditedDimensionToDefaultAsync()
        {
            _editedDimension = new Dimension();
        }

        private async Task SendEditedDimensionToBackendAsync()
        {
            await MasterDataHttpClient.UpdateDimensionAsync(_editedDimension).ConfigureAwait(false);
        }

        private async Task ValidateEditedDimensionAsync()
        {
            await MasterDataValidators.DimensionValidator.ValidateAndThrowAsync(
                    _editedDimension,
                    ruleSet: ValidatorRulesets.UpdateDimension)
               .ConfigureAwait(false);
        }

        private async Task DeleteDimensionActionAsync(Dimension dimension)
        {
            _deleteDimension = dimension;
            await OpenDeleteModalAsync().ConfigureAwait(false);
        }

        private async Task OpenDeleteModalAsync()
        {
            _deleteDimensionModal.Show();
        }

        private async Task CancelEditDimensionHandlerAsync()
        {
            _editedDimension = new Dimension();
            await HideEditDimensionModalAsync().ConfigureAwait(false);
        }

        private async Task EditDimensionActionAsync(Dimension dimension)
        {
            _editedDimension = dimension;
            await OpenEditDimensionModalAsync().ConfigureAwait(false);
        }

        private async Task OpenEditDimensionModalAsync()
        {
            _editDimensionModal.Show();
        }

        private async Task DeleteDimensionHandlerAsync()
        {
            try
            {
                await ValidateDimensionToBeDeletedAsync().ConfigureAwait(false);
                await SendDimensionToBeDeletedToBackendAsync().ConfigureAwait(false);
                await HideDeleteDimensionModalAsync().ConfigureAwait(false);
                await SetDeleteDimensionToDefaultAsync().ConfigureAwait(false);
                await PopulateDimensionsAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task SendDimensionToBeDeletedToBackendAsync()
        {
            await MasterDataHttpClient.DeleteDimensionAsync(_deleteDimension)
               .ConfigureAwait(false);
        }

        private async Task ValidateDimensionToBeDeletedAsync()
        {
            await MasterDataValidators.DimensionValidator.ValidateAndThrowAsync(
                    _deleteDimension,
                    ruleSet: ValidatorRulesets.DeleteDimension)
               .ConfigureAwait(false);
        }

        private async Task SetDeleteDimensionToDefaultAsync()
        {
            _deleteDimension = new Dimension();
        }

        private async Task CancelDeleteDimensionHandlerAsync()
        {
            await HideDeleteDimensionModalAsync().ConfigureAwait(false);
            await SetDeleteDimensionToDefaultAsync().ConfigureAwait(false);
        }
    }
}
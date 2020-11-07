// <copyright file="DimensionStructuresGrid.razor.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Components.Grids
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BlazorStrap;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.MasterData.Web.Api.Client.Interfaces;

    using FluentValidation;
    using FluentValidation.Results;

    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public partial class DimensionStructuresGrid
    {
        private BSModal _addNewModalWindow;

        private DimensionStructure _deleteDimensionStructure = new DimensionStructure();

        private BSModal _deleteModalWindow;

        private List<Dimension> _dimensions = new List<Dimension>();

        private List<DimensionStructure> _dimensionStructures = new List<DimensionStructure>();

        private DimensionStructure _editedDimensionStructure = new DimensionStructure();

        private BSModal _editModalWindow;

        private DimensionStructure _newDimensionStructure = new DimensionStructure();

        private List<SourceFormat> _sourceFormats = new List<SourceFormat>();

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        [Inject]
        public IMasterDataValidators MasterDataValidators { get; set; }

        private async Task CancelAddNewHandler()
        {
            _addNewModalWindow.Hide();
            _newDimensionStructure = new DimensionStructure();
        }

        private async Task CancelDeleteHandler()
        {
            _deleteDimensionStructure = null;
            _deleteModalWindow.Hide();
        }

        public async Task CancelEditHandler()
        {
            _editedDimensionStructure = new DimensionStructure();
            _editModalWindow.Hide();
        }

        private async Task DeleteHandler()
        {
            try
            {
                await MasterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                        _deleteDimensionStructure,
                        ruleSet: ValidatorRulesets.DeleteDimensionStructure)
                   .ConfigureAwait(false);
                await MasterDataHttpClient.DeleteDimensionStructureAsync(_deleteDimensionStructure)
                   .ConfigureAwait(false);
                await PopulateDimensionStructures().ConfigureAwait(false);
                _deleteModalWindow.Hide();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await PopulateDimensionStructures().ConfigureAwait(false);
                await PopulateTopDimensionStructures().ConfigureAwait(false);
                await PopulateDimensions().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task OpenAddWindowAction()
        {
            if (_newDimensionStructure == null)
            {
                _newDimensionStructure = new DimensionStructure();
            }

            _addNewModalWindow.Show();
        }

        private async Task OpenDeleteWindowAction(DimensionStructure dimensionStructure)
        {
            _deleteDimensionStructure = dimensionStructure;
            _deleteModalWindow.Show();
        }

        private async Task OpenEditWindowAction(DimensionStructure dimensionStructure)
        {
            _editedDimensionStructure = dimensionStructure;
            _editModalWindow.Show();
        }

        private async Task PopulateDimensions()
        {
            _dimensions = new List<Dimension>();
            _dimensions.Add(new Dimension { Name = "-- Select One --" });
            List<Dimension> result = await MasterDataHttpClient.GetDimensionsAsync().ConfigureAwait(false);
            _dimensions.AddRange(result);
        }

        private async Task PopulateDimensionStructures()
        {
            _dimensionStructures = await MasterDataHttpClient.GetDimensionStructuresAsync().ConfigureAwait(false);
        }

        private async Task PopulateTopDimensionStructures()
        {
            _sourceFormats = new List<SourceFormat>();
            _sourceFormats.Add(new SourceFormat { Name = "-- Select One --" });
            // List<SourceFormat> result = await MasterDataHttpClient
            //    .GetSourceFormatsAsync()
            //    .ConfigureAwait(false);
            // _sourceFormats.AddRange(result);
        }

        private async Task SaveDimensionStructureHandler()
        {
            ValidationResult validationResult = await MasterDataValidators
               .DimensionStructureValidator
               .ValidateAsync(_newDimensionStructure)
               .ConfigureAwait(false);

            // TODO: it must go to a common error message display component
            if (validationResult.IsValid == false)
            {
                IList<ValidationFailure> validationErrorMessages = validationResult.Errors;
                Console.WriteLine(validationErrorMessages);
            }

            await MasterDataHttpClient.AddDimensionStructureAsync(_newDimensionStructure)
               .ConfigureAwait(false);
            await PopulateDimensionStructures().ConfigureAwait(false);
            _newDimensionStructure = new DimensionStructure();
            _addNewModalWindow.Hide();
            await InvokeAsync(StateHasChanged).ConfigureAwait(false);
        }

        private async Task UpdateDimensionStructureHandler()
        {
            try
            {
                await MasterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                        _editedDimensionStructure,
                        ruleSet: ValidatorRulesets.UpdateSourceFormat)
                   .ConfigureAwait(false);
                await MasterDataHttpClient.UpdateDimensionStructureAsync(_editedDimensionStructure)
                   .ConfigureAwait(false);
                await PopulateDimensionStructures().ConfigureAwait(false);
                _editModalWindow.Hide();
                await InvokeAsync(StateHasChanged).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
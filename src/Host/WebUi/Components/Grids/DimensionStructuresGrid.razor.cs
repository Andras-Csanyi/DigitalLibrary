using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorStrap;
using DigitalLibrary.IaC.MasterData.DomainModel.DomainModel;
using DigitalLibrary.IaC.MasterData.Validators.Validators;
using DigitalLibrary.IaC.MasterData.WebApi.Client.Client;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DigitalLibrary.Ui.WebUi.Components.Grids
{
    public partial class DimensionStructuresGrid
    {
        private BSModal _addNewModalWindow;

        private List<DimensionStructure> _dimensionStructures = new List<DimensionStructure>();

        private DimensionStructure _newDimensionStructure = new DimensionStructure();

        private List<DimensionStructure> _topDimensionStructures = new List<DimensionStructure>();

        private List<Dimension> _dimensions = new List<Dimension>();

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
                await PopulateDimensionStructures();
                await PopulateTopDimensionStructures().ConfigureAwait(false);
                await PopulateDimensions().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task PopulateDimensionStructures()
        {
            _dimensionStructures = await MasterDataHttpClient.GetDimensionStructuresAsync().ConfigureAwait(false);
        }

        private async Task OpenAddWindowAction()
        {
            if (_newDimensionStructure == null)
            {
                _newDimensionStructure = new DimensionStructure();
            }

            _addNewModalWindow.Show();
        }

        private async Task CancelAddNewHandler()
        {
            _addNewModalWindow.Hide();
            _newDimensionStructure = new DimensionStructure();
        }

        private async Task SaveDimensionStructureHandler()
        {
            Console.WriteLine($"dim list size: {_dimensionStructures.Count}");
            await JsRuntime.InvokeAsync<string>("console.log", _newDimensionStructure).ConfigureAwait(false);
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
            await PopulateTopDimensionStructures().ConfigureAwait(false);
            await PopulateDimensionStructures().ConfigureAwait(false);
            await PopulateDimensions().ConfigureAwait(false);
            _newDimensionStructure = new DimensionStructure();
            _addNewModalWindow.Hide();
            Console.WriteLine($"size: {_dimensionStructures.Count}");
            await InvokeAsync(StateHasChanged).ConfigureAwait(false);
        }

        private async Task PopulateDimensions()
        {
            _dimensions = new List<Dimension>();
            _dimensions.Add(new Dimension { Name = "-- Select One --" });
            List<Dimension> result = await MasterDataHttpClient.GetDimensionsWithoutStructure().ConfigureAwait(false);
            _dimensions.AddRange(result);
        }

        private async Task PopulateTopDimensionStructures()
        {
            _topDimensionStructures = new List<DimensionStructure>();
            _topDimensionStructures.Add(new DimensionStructure { Name = "-- Select One --" });
            List<DimensionStructure> result = await MasterDataHttpClient
                .GetTopDimensionStructuresAsync()
                .ConfigureAwait(false);
            _topDimensionStructures.AddRange(result);
        }
    }
}
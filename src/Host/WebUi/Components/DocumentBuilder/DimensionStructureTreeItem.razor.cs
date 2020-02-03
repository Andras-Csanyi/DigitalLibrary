using DimensionStructureIds = MasterData.BusinessLogic.ViewModels.DimensionStructureIds;

namespace DigitalLibrary.Ui.WebUi.Components.DocumentBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Components;

    public partial class DimensionStructureTreeItem
    {
        [Parameter]
        public DimensionStructure DimensionStructure { get; set; }

        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        private List<DimensionStructure> _dimensionStructures = new List<DimensionStructure>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (DimensionStructure.ChildDimensionStructureDimensionStructures.Any())
                {
                    DimensionStructureIds dimensionStructureIds = new DimensionStructureIds();
                    dimensionStructureIds.Ids = DimensionStructure.ChildDimensionStructureDimensionStructures
                       .Select(p => p.ChildDimensionStructureId)
                       .ToList();
                    _dimensionStructures = await MasterDataHttpClient.GetDimensionStructuresAsync(
                            dimensionStructureIds)
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
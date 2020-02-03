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

    public partial class DimensionStructureTreeDisplay
    {
        private List<DimensionStructure> _dimensionStructures = new List<DimensionStructure>();

        private DimensionStructure _rootDimensionStructureWithChildren = new DimensionStructure();

        [Parameter]
        public DimensionStructure RootDimensionStructure { get; set; }

        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (RootDimensionStructure.Id != 0)
                {
                    _rootDimensionStructureWithChildren = await MasterDataHttpClient
                       .GetDimensionStructureById(RootDimensionStructure)
                       .ConfigureAwait(false);

                    if (_rootDimensionStructureWithChildren.ChildDimensionStructureDimensionStructures.Any())
                    {
                        DimensionStructureIds dimensionStructureIds = new DimensionStructureIds();
                        dimensionStructureIds.Ids = _rootDimensionStructureWithChildren
                           .ChildDimensionStructureDimensionStructures
                           .Select(p => p.ChildDimensionStructureId)
                           .ToList();
                        _dimensionStructures = await MasterDataHttpClient.GetDimensionStructuresAsync(
                                dimensionStructureIds)
                           .ConfigureAwait(false);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
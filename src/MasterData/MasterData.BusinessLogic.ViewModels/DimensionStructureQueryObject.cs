namespace DigitalLibrary.MasterData.BusinessLogic.ViewModels
{
    using System.Collections.Generic;

    public class DimensionStructureQueryObject
    {
        public long GetDimensionsStructuredById { get; set; }

        public List<long> Ids { get; set; }

        public bool IncludeChildrenWhenGetDimensionStructureById { get; set; }
    }
}
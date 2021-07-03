namespace DigitalLibrary.MasterData.BusinessLogic.ViewModels
{
    /// <summary>
    /// View model object to add the specified <see cref="DimensionStructureNode"/> entity
    /// to <see cref="SourceFormat"/> as root DimensionStructureNode.
    /// </summary>
    public class AddRootDimensionStructureNodeViewModel
    {
        public long SourceFormatId { get; set; }

        public long DimensionStructureNodeId { get; set; }
    }
}

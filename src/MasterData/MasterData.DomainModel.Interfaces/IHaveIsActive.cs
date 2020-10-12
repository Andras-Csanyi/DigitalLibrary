namespace DigitalLibrary.MasterData.DomainModel.Interfaces
{
    public interface IHaveIsActive
    {
        /// <summary>
        /// Gets or sets value of IsActive. It indicates whether the given Entity is active or not.
        /// Inactive means logically deleted.
        /// </summary>
        public int IsActive { get; set; }
    }
}